<#
.SYNOPSIS
  Runs the dotnet code-analysis toolchain: build warnings and analyzers, format check,
  vulnerable/deprecated packages, then tests with coverage.
.PARAMETER SkipTests
  Skip the test and coverage step.
.PARAMETER Fix
  Apply `dotnet format` fixes instead of only checking.
#>
[CmdletBinding()]
param(
  [switch]$SkipTests,
  [switch]$Fix
)

$ErrorActionPreference = 'Continue'
$root = Split-Path -Parent $PSScriptRoot
$sln = Join-Path $root 'EightQueens.sln'
$results = [ordered]@{}

function Invoke-Step([string]$Name, [scriptblock]$Body) {
  Write-Host "`n=== $Name ===" -ForegroundColor Cyan
  & $Body
  $script:results[$Name] = ($LASTEXITCODE -eq 0)
}

Push-Location $root
try {
  Invoke-Step 'Build + analyzers' {
    dotnet build $sln --configuration Release --no-incremental -warnaserror /p:TreatWarningsAsErrors=true
  }

  Invoke-Step 'Format' {
    if ($Fix) { dotnet format $sln } else { dotnet format $sln --verify-no-changes --verbosity diagnostic }
  }

  Invoke-Step 'Vulnerable packages' {
    $out = dotnet list $sln package --vulnerable --include-transitive 2>&1 | Out-String
    Write-Host $out
    if ($out -match 'has the following vulnerable packages') { $global:LASTEXITCODE = 1 } else { $global:LASTEXITCODE = 0 }
  }

  Invoke-Step 'Deprecated packages' {
    $out = dotnet list $sln package --deprecated --include-transitive 2>&1 | Out-String
    Write-Host $out
    # Legacy is tolerated (xunit v2 is flagged in favour of v3, a deliberate choice); CriticalBugs or Other fail
    $bad = $out -split "`n" | Where-Object { $_ -match '^\s*>\s' -and $_ -match '\b(CriticalBugs|Other)\b' }
    if ($bad) { Write-Host "Deprecated for a non-Legacy reason:`n$($bad -join "`n")" -ForegroundColor Red; $global:LASTEXITCODE = 1 } else { $global:LASTEXITCODE = 0 }
  }

  if (-not $SkipTests) {
    Invoke-Step 'Tests + coverage' {
      Remove-Item -Recurse -Force (Join-Path $root 'TestResults') -ErrorAction SilentlyContinue
      dotnet test $sln --configuration Release --no-build --collect:'XPlat Code Coverage' --settings coverage.runsettings --results-directory TestResults
    }

    if (Get-Command reportgenerator -ErrorAction SilentlyContinue) {
      reportgenerator "-reports:TestResults/**/coverage.cobertura.xml" "-targetdir:coveragereport" "-reporttypes:Html;TextSummary" | Out-Null
      Get-Content (Join-Path $root 'coveragereport/Summary.txt') -ErrorAction SilentlyContinue | Select-Object -First 12
    }
  }
}
finally {
  Pop-Location
}

Write-Host "`n=== Summary ===" -ForegroundColor Cyan
foreach ($k in $results.Keys) {
  $label = if ($results[$k]) { 'PASS' } else { 'FAIL' }
  $color = if ($results[$k]) { 'Green' } else { 'Red' }
  Write-Host ("{0,-24} {1}" -f $k, $label) -ForegroundColor $color
}
if ($results.Values -contains $false) { exit 1 }

# Code Analysis Guidelines

How code is analyzed in this repository, and how to run it. Everything below uses tools that ship with the .NET SDK, plus one NuGet analyzer package and two tools you may already have installed.

## Quick start

```powershell
pwsh tools/analyze.ps1             # run every step
pwsh tools/analyze.ps1 -SkipTests  # skip the test and coverage step
pwsh tools/analyze.ps1 -Fix        # apply dotnet format fixes instead of only checking
```

The script exits with code 1 if any step fails, and prints a PASS/FAIL summary at the end.

Prerequisites:

- .NET SDK 8 or later (CI uses 8.0.x; the script has also been run on the .NET 10 SDK).
- PowerShell 7 (`pwsh`).
- Optional: `reportgenerator` for the HTML coverage report (`dotnet tool install -g dotnet-reportgenerator-globaltool`).

## What the script runs

| Step | Command | Fails when |
|---|---|---|
| Build + analyzers | `dotnet build --configuration Release --no-incremental -warnaserror` | Any compiler, CA or IDE warning at or above the severity set in `.editorconfig` |
| Format | `dotnet format --verify-no-changes` | Any file differs from what `dotnet format` would produce |
| Vulnerable packages | `dotnet list package --vulnerable --include-transitive` | Any direct or transitive package has a known vulnerability |
| Deprecated packages | `dotnet list package --deprecated --include-transitive` | A package is deprecated for `CriticalBugs` or `Other` (see below) |
| Tests + coverage | `dotnet test --collect:"XPlat Code Coverage" --settings coverage.runsettings` | Any test fails |

After the tests, if `reportgenerator` is installed, the script writes an HTML report to `coveragereport/` (git-ignored) and prints a text summary. The script removes `TestResults/` before each run.

### The deprecated-packages rule

Packages deprecated only as `Legacy` are tolerated. The test projects use xunit v2, which NuGet flags as `Legacy` in favour of xunit v3. xunit has no LTS line, and v3 needs net472 or later, so it cannot run on the current net462 test project. Staying on 2.9.x is a deliberate choice until the projects are retargeted.

Only rows starting with `>` are inspected, and both top-level and transitive packages are covered. Revisit this rule if the projects move to net472 or later or to modern .NET.

## How it is configured

### `Directory.Build.props`

Applies to every project in the solution:

- `AnalysisLevel` is `latest-recommended`, which enables the recommended set of CA rules.
- `EnforceCodeStyleInBuild` is `true`, so IDE style rules (IDExxxx) run during `dotnet build` and not only in the editor.
- `Microsoft.CodeAnalysis.NetAnalyzers` is referenced as a package. The SDK only bundles the CA analyzers for net5.0 and later, so net462 projects need the package. It is version 8.0.0, matching the CI SDK.
- `_SkipUpgradeNetAnalyzersNuGetWarning` is `true`. Newer SDKs warn that they carry newer analyzers than the 8.0.0 package, which would break `-warnaserror` for no useful reason.
- `RestorePackagesWithLockFile` was already set; adding the package updated both `packages.lock.json` files.

### `.editorconfig`

- Basic formatting: UTF-8, 4-space indent (2 for project, resource, YAML and JSON files), final newline, trimmed trailing whitespace.
- C# style preferences, mostly at `suggestion` severity: no `this.` qualification, explicit types for built-ins, braces required, block-scoped namespaces, camelCase private fields.
- `**/*.Designer.cs` is marked `generated_code = true` and has analyzer diagnostics turned off, since WinForms designer output is not edited by hand.
- In `EightQueens.Tests`, CA1707 (underscores in names) and CA1822 (member could be static) are turned off to fit xunit conventions.

To change a rule's severity, add a line such as `dotnet_diagnostic.CA1305.severity = warning` under the right section of `.editorconfig`.

### `coverage.runsettings`

Unchanged by this work. It uses Coverlet's cobertura output and excludes the test assembly, xunit, and `*.Designer.cs` files.

## How this was set up

1. Surveyed the options. In order of effort: compiler warnings, .NET analyzers (CA rules), code-style rules (IDE rules via `.editorconfig`), `dotnet format`, `dotnet list package`, and Coverlet coverage. Third-party analyzers (Roslynator, StyleCop, Sonar) and external services were left for later.
2. Added the analyzer settings to `Directory.Build.props` and the `.editorconfig`.
3. Wrote `tools/analyze.ps1` to run all steps and print one summary.
4. Ran the script. The first run failed on formatting, so `dotnet format` was applied (see below) and the script was re-run until every step passed.
5. Tuned the package steps: the `NetAnalyzers` upgrade warning was suppressed, then the deprecated-packages check was changed to tolerate `Legacy` and to include transitive packages.

### Formatting changes this produced

`dotnet format` rewrote `CheckSolution.cs`, `Form1.cs`, `Program.cs` and `Properties/AssemblyInfo.cs`:

- Spacing fixes such as `if(` to `if (`, and spaces after commas in index expressions.
- A UTF-8 byte-order mark was removed from `Form1.cs`, `Program.cs` and `AssemblyInfo.cs`.
- Git may warn that line endings will be normalized to CRLF the next time it touches these files. This comes from `.gitattributes`, not from the formatting change.

## Baseline

At the time of writing:

- Build, format, vulnerable-package and deprecated-package steps all pass.
- All 10 tests pass.
- Line coverage is 19.3% (63 of 325 coverable lines); the form logic is the main gap.
- The only deprecated packages are xunit v2 packages and `System.Collections.Immutable` 1.5.0, all flagged `Legacy`.

## CI

`.github/workflows/ci.yml` runs `./tools/analyze.ps1 -SkipTests` after the build, so analyzer warnings, formatting drift and vulnerable or non-Legacy deprecated packages fail the pipeline. Tests and coverage keep their own step.

## Not done yet

- No coverage threshold is enforced.
- No third-party analyzers (Roslynator, StyleCop, SonarAnalyzer) have been added.
- The transitive-deprecation check has only been tested against the current packages and against a simulated row, not against a real `CriticalBugs` package.

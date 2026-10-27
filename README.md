# EightQueens

An interactive teaching project that solves the classic **8-queens puzzle** with three different approaches and visualizes the results, so you can *see* how algorithm choice changes the size of the search space and the running time.

## Learning objectives

After working through this project you should be able to:

* State the 8-queens problem and the constraints that a valid solution must satisfy.
* Explain how restricting the search space (blind placement → one queen per row → permutations) reduces the work by many orders of magnitude.
* Compute the size of each search space.
* Read and interpret empirical timing results, and recognise the limits of the measurement (timer resolution).
* Describe Heap's algorithm for generating permutations.

## Background: the problem

Place 8 queens on an 8×8 chessboard so that no two queens attack each other. A queen attacks along its row, its column, and both diagonals. A placement is therefore valid only if **no two queens share a row, a column, or a diagonal**.

The code checks these constraints in `CheckHorizontal`, `CheckVertical` and `CheckDiagonal` (`Form1.cs`), and validates a whole board with `CheckSolution`.

## The three approaches

Each approach prunes the search space further than the last.

| # | Approach | Idea | Search space | Method in `Form1.cs` |
|---|----------|------|--------------|----------------------|
| 1 | **Brute force: blind** | Drop 8 queens on any of the 64 squares | 64!/56! (≈ 1.8 × 10¹⁴) | `FindSolutionBruteForce` |
| 2 | **Brute force: 1 queen per row** | A row can hold only one queen, so choose a column for each row | 8⁸ = 16,777,216 | `FindSolutionBruteForce1onEachRow` |
| 3 | **Permutations** | Each row *and* column holds exactly one queen, so a solution is a permutation of the columns 0–7 | 8! = 40,320 | `FindSolutionPermutations` |

**Key insight:** every added piece of problem knowledge (a row holds at most one queen; a column holds at most one queen) removes whole classes of invalid boards before we ever test them.

### Discussion questions

1. Why is the blind search space 64!/56! and not 64⁸?
2. Why does the permutation approach still need to check diagonals?
3. By what factor does each step shrink the search space?

## Running the application

This is a Windows Forms app (.NET Framework 4.6.2). Open `EightQueens.sln` in Visual Studio and run it.

The UI offers the following modes:

* **Brute Force: blind**
  * Run once for a specific seed.
  * Run the predefined testbench. *Note: the total measured execution time is ~20–30 minutes.*
* **Brute Force: 1 queen for each row**
  * Run the optimized method for a specific seed.
  * Run the predefined testbench.
* **Permutations**
  * Run the permutations method for a specific seed.
  * Run the predefined testbench.
* **Testing mode**
  * Run all testbenches sequentially.

The seed controls the random choices the search makes. Seeds are predefined for the testbenches so results are **reproducible**.

## Building, running and testing

The project is a Windows Forms application targeting .NET Framework 4.6.2, in SDK-style projects.

### Requirements

* Windows
* The .NET SDK (the `dotnet` command), which restores the NuGet packages on the first build
* The .NET Framework 4.6.2 targeting pack (included in Visual Studio's ".NET desktop development" workload, or installed separately as the .NET Framework 4.6.2 Developer Pack)

### Build

From the repository root, run:

```powershell
dotnet build EightQueens.sln
```

Useful variations:

```powershell
dotnet build EightQueens.sln -c Release
```

```powershell
dotnet build EightQueens.sln --no-incremental
```

To build with MSBuild instead (for example from a "Developer PowerShell for VS"), the Visual Studio installation also needs the ".NET SDK" component, because the projects are SDK-style:

```powershell
msbuild EightQueens.sln /restore /p:Configuration=Debug
```

### Run

The executable is written to `EightQueens\bin\Debug\net462\EightQueens.exe` (or `bin\Release` for a Release build):

```powershell
.\EightQueens\bin\Debug\net462\EightQueens.exe
```

### Test

The unit tests (xUnit.net) live in the `EightQueens.Tests` project and check the Queen conflict detection, including that exactly 92 of the 8! = 40,320 permutations are valid solutions. Run them from the repository root:

```powershell
dotnet test EightQueens.sln
```

### Code coverage

Run the tests with the coverage collector, then turn the resulting Cobertura XML into an HTML report with [ReportGenerator](https://github.com/danielpalme/ReportGenerator) (installed once with `dotnet tool install -g dotnet-reportgenerator-globaltool`):

```powershell
dotnet test --collect:"XPlat Code Coverage" --settings coverage.runsettings
```

```powershell
reportgenerator -reports:"EightQueens.Tests\TestResults\*\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

Open `coveragereport\index.html` to browse the report.

## Sample output

**Testing mode** (seeds 1–15, 15 iterations per method):

![Sample testing-mode execution](https://github.com/TsiamDev/EightQueens/blob/master/EightQueens/Resources/sampleTestsExecution.png?raw=true)

**A single solution** found by the *1 queen for each row* method with seed = 10:

![Sample single solution](https://github.com/TsiamDev/EightQueens/blob/master/EightQueens/Resources/sampleSingleTest.png?raw=true)

## Reading the timing results

* The permutations approach has a start-up cost of a few milliseconds to generate all permutations of [0:7]. After that, execution times are negligible, around 5–10 ms.
* Where the time label on the left of the tab control (always visible) shows **0 ms**, the true time is not zero. It is simply below the timer's resolution (about 5–10 ms).

## Going deeper: Heap's algorithm

The permutations approach generates all permutations of N numbers recursively using **Heap's algorithm** (`heapPermutation` in `Form1.cs`). Reference: [GeeksforGeeks: Heap's algorithm for generating permutations](https://www.geeksforgeeks.org/heaps-algorithm-for-generating-permutations/).

## Exercises

1. Run each single-seed mode and compare the displayed times.
2. Run the testbenches and explain the differences in the bar charts using the search-space sizes above.
3. Change the seed and observe how the blind and one-per-row methods vary, while permutations stays nearly constant.
4. Modify the code to count how many boards each method checks before finding a solution.

## Extension ideas

* Add a **DFS with backtracking** approach, which prunes a partial board as soon as it contains a conflict. This should beat the permutations approach.
* Measure elapsed time with higher precision (nanosecond scale), for example with `System.Diagnostics.Stopwatch`.

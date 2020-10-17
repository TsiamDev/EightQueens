# EightQueens

This project solves the 8-queens puzzle with 3 different approaches and visualizes the data

There exist the following modes: 
  * Brute Force: blind - Search Space: 64!/56!
    * Execute the brute force method once, for a specific seed
    * Execute the predefined testbench for the brute force method (Note: the total measured execution times are ~20-30 mins)
  * Brute Force: 1 Queen for each row - Search Space: 8^8
    * Execute the brute force method optimization for a specific seed
    * Execute the predefined testbench for the brute force method
  * Permutations: - Search Space: 8!
    * Execute the permutations method for a specific seed
    * Execute the predefined testbench for the permutations method
  * Testing mode
    *Execute all testbenches sequentially

This is a sample run of the testing mode (for seed = [1:15] & 15 iterations for each method)

The seed used was predefined in order to produce, reproducible results.

![alt text](https://github.com/TsiamDev/EightQueens/blob/master/EightQueens/Resources/sampleTestsExecution.png?raw=true)

This is the representation of solution found for <1 Queen for each row> method with a seed = 10

![alt text](https://github.com/TsiamDev/EightQueens/blob/master/EightQueens/Resources/sampleSingleTest.png?raw=true)

# Notes on measured times

* The permutations approach needs an initialization period of a few milliseconds to generate all the possible permutations of the numbers [0:7], 
but after that the execution times are negligible in the order of 5-10 ms
* Wherever the measured time displayed on the left of the tab control (labels on the left side that are visible at all times) is 0ms, 
the time elapsed isn't actually 0ms, it is simply beyond the resolution of the timer (which is in the order of 5-10 ms)

# Notes on the permutations approach

* Heap's algorithm was used for generating the Tree that contains all possible permutations of N numbers in its' leaves, and can be found here:
https://www.geeksforgeeks.org/heaps-algorithm-for-generating-permutations/

# TODO suggestions

* Another optimization on the permutations approach: DFS with backtracking. 
* Find a way (library?) to measure the elapsed time with greater precision (in the order of ns?)

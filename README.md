# EightQueens

This project solves the 8-queens puzzle with a brute force approach and visualizes the data

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

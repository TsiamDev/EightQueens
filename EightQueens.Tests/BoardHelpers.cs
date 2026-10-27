using System.Collections.Generic;

namespace EightQueens.Tests
{
    //Helpers shared by the tests for building boards and enumerating placements
    internal static class BoardHelpers
    {
        internal const int Size = 8;

        //Builds the board and queenPos arrays the way Form1 does, from (row, column) pairs
        internal static bool PlacementHasConflict(params int[][] queens)
        {
            // Create the solution board
            int[,] board = new int[Size, Size];
            int[,] queenPos = new int[2, queens.Length];
            for (int i = 0; i < queens.Length; i++)
            {
                board[queens[i][0], queens[i][1]] = 1;
                queenPos[0, i] = queens[i][0];
                queenPos[1, i] = queens[i][1];
            }
            // Check the created board for conflicting queen positions
            return CheckSolution.HasConflict(board, queenPos);
        }

        //One Queen per row: columns[row] is the column of that row's Queen
        internal static bool HasConflictOneQueenPerRow(int[] columns)
        {
            int[][] queens = new int[columns.Length][];
            for (int row = 0; row < columns.Length; row++)
            {
                queens[row] = new[] { row, columns[row] };
            }
            return PlacementHasConflict(queens);
        }

        internal static IEnumerable<int[]> Permutations(int n)
        {
            return Permute(new int[n], new bool[n], 0);
        }

        private static IEnumerable<int[]> Permute(int[] current, bool[] used, int index)
        {
            if (index == current.Length)
            {
                yield return (int[])current.Clone();
                yield break;
            }
            for (int value = 0; value < current.Length; value++)
            {
                if (used[value])
                {
                    continue;
                }
                used[value] = true;
                current[index] = value;
                foreach (int[] permutation in Permute(current, used, index + 1))
                {
                    yield return permutation;
                }
                used[value] = false;
            }
        }
    }
}

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightQueens.Tests
{
    [TestClass]
    public class CheckSolutionTests
    {
        private const int Size = 8;

        //Builds the board and queenPos arrays the way Form1 does, from (row, column) pairs
        private static bool HasConflict(params int[][] queens)
        {
            int[,] board = new int[Size, Size];
            int[,] queenPos = new int[2, queens.Length];
            for (int i = 0; i < queens.Length; i++)
            {
                board[queens[i][0], queens[i][1]] = 1;
                queenPos[0, i] = queens[i][0];
                queenPos[1, i] = queens[i][1];
            }
            return new CheckSolution().HasConflict(board, queenPos);
        }

        //One Queen per row: columns[row] is the column of that row's Queen
        private static bool HasConflictOneQueenPerRow(int[] columns)
        {
            int[][] queens = new int[columns.Length][];
            for (int row = 0; row < columns.Length; row++)
            {
                queens[row] = new[] { row, columns[row] };
            }
            return HasConflict(queens);
        }

        [TestMethod]
        public void KnownSolution_HasNoConflict()
        {
            Assert.IsFalse(HasConflictOneQueenPerRow(new[] { 0, 4, 7, 5, 2, 6, 1, 3 }));
        }

        [TestMethod]
        public void TwoQueensOnTheSameRow_Conflict()
        {
            Assert.IsTrue(HasConflict(new[] { 3, 1 }, new[] { 3, 6 }));
        }

        [TestMethod]
        public void TwoQueensOnTheSameColumn_Conflict()
        {
            Assert.IsTrue(HasConflict(new[] { 1, 4 }, new[] { 6, 4 }));
        }

        [TestMethod]
        public void TwoQueensOnTheSameDiagonal_Conflict()
        {
            //Both directions of the main diagonal, then both directions of the anti-diagonal
            Assert.IsTrue(HasConflict(new[] { 2, 2 }, new[] { 5, 5 }));
            Assert.IsTrue(HasConflict(new[] { 5, 5 }, new[] { 2, 2 }));
            Assert.IsTrue(HasConflict(new[] { 2, 5 }, new[] { 5, 2 }));
            Assert.IsTrue(HasConflict(new[] { 5, 2 }, new[] { 2, 5 }));
        }

        [TestMethod]
        public void QueensAKnightsMoveApart_NoConflict()
        {
            Assert.IsFalse(HasConflict(new[] { 0, 0 }, new[] { 1, 2 }));
        }

        [TestMethod]
        public void AllPermutations_Contain92Solutions()
        {
            //Every one-Queen-per-row placement without a column clash is a permutation of 0..7,
            //so enumerating them independently of the app's own permutation code gives 8! = 40,320 boards
            int total = 0;
            int solutions = 0;
            foreach (int[] permutation in Permutations(Size))
            {
                total++;
                if (!HasConflictOneQueenPerRow(permutation))
                {
                    solutions++;
                }
            }

            Assert.AreEqual(40320, total);
            Assert.AreEqual(92, solutions);
        }

        private static IEnumerable<int[]> Permutations(int n)
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

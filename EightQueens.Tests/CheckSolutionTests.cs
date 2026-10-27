using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EightQueens.Tests.BoardHelpers;

namespace EightQueens.Tests
{
    [TestClass]
    public class CheckSolutionTests
    {
        [TestMethod]
        public void KnownSolution_HasNoConflict()
        {
            Assert.IsFalse(HasConflictOneQueenPerRow(new[] { 0, 4, 7, 5, 2, 6, 1, 3 }));
        }

        [TestMethod]
        public void TwoQueensOnTheSameRow_Conflict()
        {
            Assert.IsTrue(PlacementHasConflict(new[] { 3, 1 }, new[] { 3, 6 }));
        }

        [TestMethod]
        public void TwoQueensOnTheSameColumn_Conflict()
        {
            Assert.IsTrue(PlacementHasConflict(new[] { 1, 4 }, new[] { 6, 4 }));
        }

        [TestMethod]
        public void TwoQueensOnTheSameDiagonal_Conflict()
        {
            //Both directions of the main diagonal, then both directions of the anti-diagonal
            Assert.IsTrue(PlacementHasConflict(new[] { 2, 2 }, new[] { 5, 5 }));
            Assert.IsTrue(PlacementHasConflict(new[] { 5, 5 }, new[] { 2, 2 }));
            Assert.IsTrue(PlacementHasConflict(new[] { 2, 5 }, new[] { 5, 2 }));
            Assert.IsTrue(PlacementHasConflict(new[] { 5, 2 }, new[] { 2, 5 }));
        }

        [TestMethod]
        public void QueensAKnightsMoveApart_NoConflict()
        {
            Assert.IsFalse(PlacementHasConflict(new[] { 0, 0 }, new[] { 1, 2 }));
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
    }
}

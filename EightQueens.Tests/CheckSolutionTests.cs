using Xunit;
using static EightQueens.Tests.BoardHelpers;

namespace EightQueens.Tests
{
    public class CheckSolutionTests
    {
        [Fact]
        public void KnownSolution_HasNoConflict()
        {
            Assert.False(HasConflictOneQueenPerRow(new[] { 0, 4, 7, 5, 2, 6, 1, 3 }));
        }

        [Fact]
        public void TwoQueensOnTheSameRow_Conflict()
        {
            Assert.True(PlacementHasConflict(new[] { 3, 1 }, new[] { 3, 6 }));
        }

        [Fact]
        public void TwoQueensOnTheSameColumn_Conflict()
        {
            Assert.True(PlacementHasConflict(new[] { 1, 4 }, new[] { 6, 4 }));
        }

        [Fact]
        public void TwoQueensOnTheSameDiagonal_Conflict()
        {
            //Both directions of the main diagonal, then both directions of the anti-diagonal
            Assert.True(PlacementHasConflict(new[] { 2, 2 }, new[] { 5, 5 }));
            Assert.True(PlacementHasConflict(new[] { 5, 5 }, new[] { 2, 2 }));
            Assert.True(PlacementHasConflict(new[] { 2, 5 }, new[] { 5, 2 }));
            Assert.True(PlacementHasConflict(new[] { 5, 2 }, new[] { 2, 5 }));
        }

        [Fact]
        public void QueensAKnightsMoveApart_NoConflict()
        {
            Assert.False(PlacementHasConflict(new[] { 0, 0 }, new[] { 1, 2 }));
        }

        [Fact]
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

            Assert.Equal(40320, total);
            Assert.Equal(92, solutions);
        }
    }
}

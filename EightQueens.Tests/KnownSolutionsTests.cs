using System.Collections.Generic;
using System.Linq;
using Xunit;
using static EightQueens.Tests.BoardHelpers;

namespace EightQueens.Tests
{
    public class KnownSolutionsTests
    {
        //All 92 solutions of the eight queens puzzle. Each string lists, row by row, the column
        //(0-7) of that row's Queen, so "04752613" is the first solution in lexicographic order.
        //Source: the 11l solution output on Rosetta Code, "N-queens problem"
        //https://rosettacode.org/wiki/N-queens_problem (a1..h8 notation converted to 0-based columns).
        //Cross-checked: the set is exactly what independent enumeration finds (see the tests below),
        //and Wikipedia's "Eight queens puzzle" gives the same total (11 x 8 + 1 x 4 = 92)
        //https://en.wikipedia.org/wiki/Eight_queens_puzzle
        private static readonly string[] KnownSolutions =
        {
            "04752613",
            "05726314",
            "06357142",
            "06471352",
            "13572064",
            "14602753",
            "14630752",
            "15063724",
            "15720364",
            "16257403",
            "16470352",
            "17502463",
            "20647135",
            "24170635",
            "24175360",
            "24603175",
            "24730615",
            "25147063",
            "25160374",
            "25164073",
            "25307461",
            "25317460",
            "25703641",
            "25704613",
            "25713064",
            "26174035",
            "26175304",
            "27360514",
            "30471625",
            "30475261",
            "31475026",
            "31625704",
            "31625740",
            "31640752",
            "31746025",
            "31750246",
            "35041726",
            "35716024",
            "35720641",
            "36074152",
            "36271405",
            "36415027",
            "36420571",
            "37025164",
            "37046152",
            "37420615",
            "40357162",
            "40731625",
            "40752613",
            "41357206",
            "41362750",
            "41506372",
            "41703625",
            "42057136",
            "42061753",
            "42736051",
            "46027531",
            "46031752",
            "46137025",
            "46152037",
            "46152073",
            "46302751",
            "47302516",
            "47306152",
            "50417263",
            "51602473",
            "51603742",
            "52064713",
            "52073164",
            "52074136",
            "52460317",
            "52470316",
            "52613704",
            "52617403",
            "52630714",
            "53047162",
            "53174602",
            "53602417",
            "53607142",
            "57130642",
            "60275314",
            "61307425",
            "61520374",
            "62057413",
            "62714053",
            "63147025",
            "63175024",
            "64205713",
            "71306425",
            "71420635",
            "72051463",
            "73025164"        };

        // Converts string to int[] by subtracting the value of the char '0'.
        private static int[] Parse(string solution)
        {
            return solution.Select(c => c - '0').ToArray();
        }

        [Fact]
        public void KnownSolutions_AreTheExpected92Solutions_DistinctBoards()
        {
            Assert.Equal(92, KnownSolutions.Length);
            Assert.Equal(92, KnownSolutions.Distinct().Count());
            foreach (string solution in KnownSolutions)
            {
                // Checks if solution has Length=8
                Assert.True(solution.Length == Size, "Wrong length: " + solution);
                // Checks if solution has all [0-7] integers exactly once, in any order
                Assert.True(Enumerable.Range(0, Size).SequenceEqual(Parse(solution).OrderBy(column => column)), "Not a permutation of 0-7: " + solution);
            }
        }

        [Fact]
        public void EveryKnownSolution_HasNoConflict()
        {
            foreach (string solution in KnownSolutions)
            {
                Assert.False(HasConflictOneQueenPerRow(Parse(solution)),
                    "Known solution reported as a conflict: " + solution);
            }
        }

        [Fact]
        public void EnumeratedSolutions_AreExactlyTheKnownSolutions()
        {
            //Nothing is missing from the list and nothing extra is accepted by CheckSolution
            HashSet<string> found = new HashSet<string>(
                Permutations(Size)
                    .Where(p => !HasConflictOneQueenPerRow(p))
                    .Select(p => string.Concat(p)));

            Assert.True(found.SetEquals(KnownSolutions));
        }

        [Fact]
        public void KnownSolutions_FormTwelveFundamentalSolutions()
        {
            //Wikipedia: 12 fundamental solutions, 11 with 8 variants and 1 symmetric one with 4 (11 x 8 + 4 = 92)
            HashSet<string> remaining = new HashSet<string>(KnownSolutions);
            List<int> classSizes = new List<int>();

            while (remaining.Count > 0)
            {
                HashSet<string> variants = new HashSet<string>(Symmetries(Parse(remaining.First())));
                Assert.True(variants.IsSubsetOf(remaining), "Symmetric variant is not a known solution");
                remaining.ExceptWith(variants);
                classSizes.Add(variants.Count);
            }

            Assert.Equal(12, classSizes.Count);
            Assert.Equal(11, classSizes.Count(size => size == 8));
            Assert.Equal(1, classSizes.Count(size => size == 4));
        }

        //The 4 rotations and their mirror images, as strings in the same format as KnownSolutions
        private static IEnumerable<string> Symmetries(int[] columns)
        {
            List<int[]> queens = columns.Select((column, row) => new[] { row, column }).ToList();
            for (int mirror = 0; mirror < 2; mirror++)
            {
                for (int rotation = 0; rotation < 4; rotation++)
                {
                    int[] board = new int[Size];
                    foreach (int[] queen in queens)
                    {
                        board[queen[0]] = queen[1];
                    }
                    yield return string.Concat(board);
                    queens = queens.Select(q => new[] { q[1], Size - 1 - q[0] }).ToList();
                }
                queens = queens.Select(q => new[] { q[0], Size - 1 - q[1] }).ToList();
            }
        }
    }
}

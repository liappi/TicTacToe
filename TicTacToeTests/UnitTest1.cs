using System;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToeTests {
    public class UnitTest1 {
        
        private readonly ITestOutputHelper output;
        
        public UnitTest1(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void ShouldReturnEmptyBoard() {
            var ticTacToe = new TicTacToe();
            var result = ticTacToe.Play();
            
            Assert.Same(result, "..." +
                                "..." +
                                "...");
        }

        [Theory]
        [InlineData(1, 1, 'X', "X.." +
                               "..." +
                               "...")]
        [InlineData(2, 1, 'X', ".X." +
                               "..." +
                               "...")]
        [InlineData(2, 2, 'O', "..." +
                               ".O." +
                               "...")]
        public void GivenPositionAndTokenShouldSetTokenAtThatPositionOnBoard(int x, int y, char c, string expected) {
            var ticTacToe = new TicTacToe();
            var actual = ticTacToe.MakeMove(x, y, c);

            output.WriteLine("Actual: " + actual);
            output.WriteLine("Expected: " + expected);
            
            Assert.True(expected.Equals(actual));
        }


        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(2, 1, true)]
        [InlineData(4, 1, false)]
        public void GivenPositionShouldReturnTrueIfPositionIsPossibleOnBoard(int x, int y, bool expected) {
            var ticTacToe = new TicTacToe();
            
        }
    }

    public class TicTacToe {
        public string Play() {
            return "..." +
                   "..." +
                   "...";
        }

        public string MakeMove(int x, int y, char c) {
            StringBuilder result = new StringBuilder("..." +
                                                     "..." +
                                                     "...");

            result[(x - 1) + (y - 1) * 3] = c;

            return result.ToString();
        }
    }
}
using System;
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
            var actual = ticTacToe.inputValidator.PositionPossible(x, y);
            
            Assert.True(expected.Equals(actual));
        }

        [Theory]
        [InlineData(1, 1, "..." +
                          "..." +
                          "...", true)]
        [InlineData(1, 1, "X.." +
                          "..." +
                          "...", false)]
        [InlineData(2, 1, "X.." +
                          "..." +
                          "...", true)]
        public void GivenPositionShouldReturnTrueIfPositionIsFree(int x, int y, string initialBoard, bool expected) {
            var ticTacToe = new TicTacToe();

            var actual = ticTacToe.inputValidator.PositionFree(x, y, initialBoard);
            Assert.True(expected.Equals(actual));
        }
        
        
    }
}
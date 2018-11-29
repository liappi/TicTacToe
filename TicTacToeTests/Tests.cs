using System;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TicTacToe;
using Xunit;
using Xunit.Abstractions;

namespace TicTacToeTests {
    public class Tests {
        
        private readonly ITestOutputHelper output;
        
        public Tests(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void ShouldReturnEmptyBoard() {
            var ticTacToe = new Game();
            var result = ticTacToe.board;
            
            Assert.Equal(result, "..." +
                                 "..." +
                                 "...");
        }

        [Theory]
        [InlineData(1, 1, 'X', "..." +
                               "..." +
                               "...", "X.." +
                                      "..." +
                                      "...")]
        [InlineData(1, 1, 'O', "..." +
                               "..." +
                               "...", "O.." +
                                      "..." +
                                      "...")]
        [InlineData(2, 2, 'O', "X.." +
                               "..." +
                               "...", "X.." +
                                      ".O." +
                                      "...")]
        public void GivenPositionShouldSetCurrentPlayerTokenAtThatPositionOnBoard(int x, int y, char token, string initialBoard, string expected) {
            var player = new Player(token);
            var actual = player.MakeMove(x, y, initialBoard);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(2, 1, true)]
        [InlineData(4, 1, false)]
        public void GivenPositionShouldReturnTrueIfPositionIsPossibleOnBoard(int x, int y, bool expected) {
            var inputValidator = new InputValidator();
            var actual = inputValidator.HasPositionPossible(x, y);
            Assert.Equal(expected, actual);
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
            var inputValidator = new InputValidator();
            var actual = inputValidator.HasPositionFree(x, y, initialBoard);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("XXX" +
                    "..." +
                    "...", 'X', true)]
        [InlineData("X.." +
                    "X.." +
                    "X..", 'X', true)]
        [InlineData("X.." +
                    ".X." +
                    "..X", 'X', true)]
        [InlineData("XX." +
                    "..." +
                    "...", 'X', false)]
        [InlineData("XXO" +
                    "XOO" +
                    "..X", 'O', false)]
        public void GivenBoardAndPlayerTokenShouldReturnTrueIfAPlayerHasWon(string board, char token, bool expected) {
            var winChecker = new WinChecker();
            var actual = winChecker.PlayerHasWon(board, token);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldSwitchCurrentPlayer() {
            var ticTacToe = new Game();
            ticTacToe.NextPlayer();
            var actual = ticTacToe.currentPlayer;
            var expected = ticTacToe.players[1];
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("q", true)]
        [InlineData("r", false)]
        [InlineData("1,2", false)]
        public void GivenQAsPlayerInputShouldReturnHasBeenQuit(string input, bool expected) {
            var game = new Game();
            var actual = game.playerHasQuit(input);
            Assert.Equal(expected, actual);
        }
        
    }
}
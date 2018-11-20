using System;
using System.Text;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests {
    [TestFixture]
    public class Tests {
        [Test]
        public void PlayerInputIsInvalidWhenThereIsNoComma() {
            var gameBoard = new GameBoard();
            var inputValidator = new InputValidator(gameBoard);
            
            Assert.False(inputValidator.playerInputIsValid("11"));
        }

        [Test]
        public void ShouldReturnEmpty() {
            var game = new TicTacToe();
            
            var result = game.Play();

            Assert.AreEqual("..." +
                            "..." +
                            "...", result);
        }

        [Test]
        public void GivenPositionAndTokenShouldPlaceTokenAtThatPositionOnBoard() {
            var game = new TicTacToe();

            var result = game.MakeMove(1, 'X', "..." +
                                               "..." +
                                               "...");
            
            Assert.AreEqual(".X." +
                            "..." +
                            "...", result);
        }
    }

    public class TicTacToe {
        public string Play() {
            return "..." +
                   "..." +
                   "...";
        }

        public string MakeMove(int position, char token, string board) {
            var outputBoard = new StringBuilder(board) {[position] = token};
            return outputBoard.ToString();
        }
    }
}
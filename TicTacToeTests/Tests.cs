using System;
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
    }
}
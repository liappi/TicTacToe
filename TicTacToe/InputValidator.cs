using System;

namespace TicTacToe {
    public class InputValidator {
        private GameBoard gameBoard;

        public InputValidator(GameBoard gameBoard) {
            this.gameBoard = gameBoard;
        }

        public bool playerHasQuit(string input) {
            return input.Equals("q");
        }
        
        public bool playerInputIsValid(string input) {
            if (!input.Contains(",")) return false;
            
            var coordinates = input.Split(',');
            var col = Convert.ToInt32(coordinates[0]);
            var row = Convert.ToInt32(coordinates[1]);

            return row <= GameBoard.dimension && row > 0 && col <= GameBoard.dimension && col > 0 && gameBoard.board[row - 1, col - 1].Equals('.');
        }
    }
}
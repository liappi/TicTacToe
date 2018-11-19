namespace TicTacToe {
    public class InputValidator {
        private GameBoard gameBoard;

        public InputValidator(GameBoard gameBoard) {
            this.gameBoard = gameBoard;
        }
        
        public bool playerInputIsValid(int row, int col) {
            return row <= GameBoard.dimension && row > 0 &&
                   col <= GameBoard.dimension && col > 0 &&
                   gameBoard.board[row - 1, col - 1].Equals('.');
        }
    }
}
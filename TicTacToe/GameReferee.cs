namespace TicTacToe {
    public class GameReferee {
        public GameBoard gameBoard;

        public GameReferee(GameBoard gameBoard) {
            this.gameBoard = gameBoard;
        }
        
        public bool hasRowWin(char c) {
            for (var i = 0; i < GameBoard.dimension; i++) {
                if (gameBoard.board[i, 0].Equals(c) &&
                    gameBoard.board[i, 1].Equals(c) &&
                    gameBoard.board[i, 2].Equals(c) ) {
                    return true;
                }
            }
    
            return false;
        }

        public bool hasColumnWin(char c) {
            for (var j = 0; j < GameBoard.dimension; j++) {
                if (gameBoard.board[0, j].Equals(c) &&
                    gameBoard.board[1, j].Equals(c) &&
                    gameBoard.board[2, j].Equals(c) ) {
                    return true;
                }
            }
    
            return false;
        }

        public bool hasDiagonalWin(char c) {
            return (gameBoard.board[0, 0].Equals(c) && gameBoard.board[1, 1].Equals(c) && gameBoard.board[2, 2].Equals(c)) ||
                   (gameBoard.board[0, 2].Equals(c) && gameBoard.board[1, 1].Equals(c) && gameBoard.board[2, 0].Equals(c));
        }

        public bool gameIsDrawn() {
            for (var i = 0; i < GameBoard.dimension; i++) {
                for (var j = 0; j < GameBoard.dimension; j++) {
                    if (gameBoard.board[i, j].Equals('.')) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
namespace TicTacToe {
    public class WinChecker {
        public bool PlayerHasWon(string board, char token) {
            return HasColumnWin(board, token) || HasRowWin(board, token) || HasDiagonalWin(board, token);
        }

        private bool HasRowWin(string board, char token) {
            var dimension = 3;
            for (var row = 0; row < dimension; row++) {
                if (board[3 * row] == token && board[3 * row + 1] == token && board[3 * row + 2] == token) {
                    return true;
                }
            }

            return false;
        }
        
        private bool HasColumnWin(string board, char token) {
            var dimension = 3;

            for (var col = 0; col < dimension; col++) {
                if (board[col] == token && board[col + 3] == token && board[col + 6] == token) {
                    return true;
                }
            }

            return false;
        }
        
        private bool HasDiagonalWin(string board, char token) {
            return board[0] == token && board[4] == token && board[8] == token;
        }
    }
}
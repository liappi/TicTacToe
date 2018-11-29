namespace TicTacToe {
    public class InputValidator {
        public bool HasPositionPossible(int x, int y) {
            var dimension = 3;

            return x < dimension && y < dimension && x > 0 && y > 0;
        }

        public bool HasPositionFree(int x, int y, string board) {
            return board[MapPositionToBoard(x, y)].Equals('.');
        }

        public static int MapPositionToBoard(int x, int y) {
            return x - 1 + (y - 1) * 3;
        }
    }
}
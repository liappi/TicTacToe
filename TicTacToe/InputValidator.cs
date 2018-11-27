namespace TicTacToe {
    public class InputValidator {
        public bool PositionPossible(int x, int y) {
            var dimension = 3;

            return x < dimension && y < dimension && x > 0 && y > 0;
        }

        public bool PositionFree(int x, int y, string board) {
            return board[FindPositionAsElementInString(x, y)].Equals('.');
        }

        public static int FindPositionAsElementInString(int x, int y) {
            return x - 1 + (y - 1) * 3;
        }
    }
}
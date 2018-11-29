using System.Text;

namespace TicTacToe {
    public class Player {
        private char token;

        public Player(char token) {
            this.token = token;
        }
        
        public string MakeMove(int x, int y, string board) {
            StringBuilder result = new StringBuilder(board);
            result[InputValidator.MapPositionToBoard(x, y)] = token;

            return result.ToString();
        }
    }
}
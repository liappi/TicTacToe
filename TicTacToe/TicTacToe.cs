using System.Text;
using TicTacToe;

namespace TicTacToeTests {
    public class TicTacToe {
        public InputValidator inputValidator;

        public TicTacToe() {
            inputValidator = new InputValidator();
        }
        
        public string Play() {
            return "..." +
                   "..." +
                   "...";
        }

        public string MakeMove(int x, int y, char c) {
            StringBuilder result = new StringBuilder("..." +
                                                     "..." +
                                                     "...");

            result[inputValidator.FindPositionAsElementInString(x, y)] = c;

            return result.ToString();
        }
    }
}
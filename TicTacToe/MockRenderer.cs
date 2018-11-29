using System.Collections.Generic;

namespace TicTacToe {
    public class MockRenderer : IRenderer {
        public string GetPlayerInput(string input) {
            return input;
        }

        public string GetPlayerInput() {
            return "";
        }

        public void Print(string message) {
            return;
        }
    }
}
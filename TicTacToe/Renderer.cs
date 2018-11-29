using System;

namespace TicTacToe {
    public class Renderer : IRenderer {
        public string GetPlayerInput() {
            return Console.ReadLine();
        }

        public void Print(string message) {
            throw new NotImplementedException();
        }
    }
}
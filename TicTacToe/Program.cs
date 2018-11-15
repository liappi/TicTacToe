using System;
using System.Runtime.InteropServices;

namespace TicTacToe {
    internal class Program {
        public static void Main(string[] args) {
            var game = new Game();
            game.Start();
        }
    }
}
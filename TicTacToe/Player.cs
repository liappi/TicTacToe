using System;

namespace TicTacToe {
    public class Player {
        
        public int playerNumber;
        public int row;
        public int col;
        public bool inputValid;

        public Player(int playerNumber) {
            this.playerNumber = playerNumber;
            inputValid = false;
        }

        public void getPlayerInput() {
            Console.WriteLine("Enter your input:");
            
            Console.Write("row:");
            row = int.Parse(Console.ReadLine());
            Console.Write("col:");
            col = int.Parse(Console.ReadLine());
        }
    }
}
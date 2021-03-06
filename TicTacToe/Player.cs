using System;
using System.Linq;

namespace TicTacToe {
    public class Player {
        
        public int playerNumber;
        public int row;
        public int col;
        public bool inputValid;
        public bool givenUp;
        private char symbol;

        public Player(int playerNumber) {
            this.playerNumber = playerNumber;
            inputValid = false;
            givenUp = false;

            if (playerNumber.Equals(1)) {
                symbol = 'X';
            } else if (playerNumber.Equals(2)) {
                symbol = 'O';
            }
        }

        public void getPlayerInput() {
            Console.Write($"Player {playerNumber}, enter a coord x,y to place your {symbol} or enter 'q' to give up: ");

            var input = Console.ReadLine();

            if (input.Equals("q")) {
                givenUp = true;
            } 
            else if (input.Contains(",")) {
                updateRowAndCol(input);
            }
            else {
                col = 0;
                row = 0;
            }
        }

        private void updateRowAndCol(string input) {
            var coordinates = input.Split(',');
            col = Convert.ToInt32(coordinates[0]);
            row = Convert.ToInt32(coordinates[1]);
        }
    }
}
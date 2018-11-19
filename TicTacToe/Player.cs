using System;

namespace TicTacToe {
    public class Player {
        
        public int row;
        public int col;
        public bool inputValid;
        public bool givenUp;
        public char symbol;
        public string input;

        public Player(char symbol) {
            inputValid = false;
            givenUp = false;
            this.symbol = symbol;
        }

        private void updateRowAndCol(string input) {
            var coordinates = input.Split(',');
            col = Convert.ToInt32(coordinates[0]);
            row = Convert.ToInt32(coordinates[1]);
        }
    }
}
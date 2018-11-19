using System;

namespace TicTacToe {
    public class Player {
        public bool inputValid;
        public bool givenUp;
        public char symbol;
        public string input;

        public Player(char symbol) {
            inputValid = false;
            givenUp = false;
            this.symbol = symbol;
        }
    }
}
using System.Collections.Generic;

namespace TicTacToe {
    public class Game {
        public InputValidator inputValidator;
        public WinChecker winChecker;
        public string board;
        public List<Player> players;
        public Player currentPlayer;
        public int currentPlayerIndex;

        public Game() {
            inputValidator = new InputValidator();
            winChecker = new WinChecker();
            players = new List<Player> {new Player('X'), new Player('O')};

            currentPlayerIndex = 0;
            currentPlayer = players[currentPlayerIndex];
            
            board = "..." +
                    "..." +
                    "...";
        }

        public void NextPlayer() {
            if (currentPlayerIndex < players.Count - 1) {
                currentPlayerIndex++;
            }
            else {
                currentPlayerIndex = 0;
            }

            currentPlayer = players[currentPlayerIndex];
        }
    }
}
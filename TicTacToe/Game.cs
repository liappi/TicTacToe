using System;
using System.Collections.Generic;

namespace TicTacToe {
    public class Game {
        private bool gameEnded;
        private GameBoard gameBoard;
        private List<Player> players;
        private GameReferee gameReferee;
        private InputValidator inputValidator;
        private Renderer renderer;
        private int currentPlayerIndex;
        private Player currentPlayer;

        public Game() {
            gameEnded = false;
            
            gameBoard = new GameBoard();
            players = new List<Player>();
            gameReferee = new GameReferee(gameBoard);
            inputValidator = new InputValidator(gameBoard);
            renderer = new Renderer();
            
            players.Add(new Player('X'));
            players.Add(new Player('O'));

            currentPlayerIndex = 0;
            currentPlayer = players[currentPlayerIndex];
        }

        public void Start() {
            renderer.printWelcomeMessage();
            renderer.displayGameBoard(gameBoard);

            while (!gameEnded) {
                currentPlayer = players[currentPlayerIndex];
                var input = renderer.getPlayerInput(currentPlayerIndex, currentPlayer);

                if (inputValidator.playerHasQuit(input)) {
                    renderer.printQuitMessage(currentPlayerIndex);
                    return;
                }

                input = elicitValidInputIfInputInvalid(input);
                renderer.printInputAcceptedMessage();
                gameBoard.updateGameBoardWithPlayerInput(currentPlayer.symbol, input);
                
                renderer.displayGameBoard(gameBoard);
                
                updateGameWinCondition();
                
                nextTurn();
            }
        }

        string elicitValidInputIfInputInvalid(string input) {
            while (!inputValidator.playerInputIsValid(input)) {
                renderer.printInvalidInputMessage();
                input = renderer.getPlayerInput(currentPlayerIndex, currentPlayer);
            }

            return input;
        }

        void updateGameWinCondition() {
            if (gameReferee.gameIsDrawn()) {
                gameEnded = true;
                Console.WriteLine("The game is a draw.");
            }
            else if (gameReferee.playerHasWon('X')) {
                gameEnded = true;
                Console.WriteLine("The winner is player one.");
            }
            else if (gameReferee.playerHasWon('O')) {                 
                gameEnded = true;
                Console.WriteLine("The winner is player two.");
            }
        }

        void nextTurn() {
            if (currentPlayerIndex < players.Count - 1) {
                currentPlayerIndex++;
            }
            else {
                currentPlayerIndex = 0;
            }
        }
    }
}
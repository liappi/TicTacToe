using System;
using System.Collections.Generic;

namespace TicTacToe {
    public class Game {
        private bool gameEnded;
        private GameBoard gameBoard;
        private List<Player> players;
        private Player playerWithCurrentTurn;
        private GameReferee gameReferee;
        private InputValidator inputValidator;
        private Renderer renderer;
        private int playerIndex;

        public Game() {
            gameEnded = false;
            
            gameBoard = new GameBoard();
            players = new List<Player>();
            gameReferee = new GameReferee(gameBoard);
            inputValidator = new InputValidator(gameBoard);
            renderer = new Renderer();
            
            players.Add(new Player('X'));
            players.Add(new Player('O'));

            playerIndex = 0;
            playerWithCurrentTurn = players[playerIndex];
        }

        public void Start() {
            renderer.printWelcomeMessage();
            renderer.displayGameBoard(gameBoard);

            while (!gameEnded) {
                
                
                
                while (!playerWithCurrentTurn.inputValid) {
                    renderer.getPlayerInput(playerWithCurrentTurn);

                    if (playerWithCurrentTurn.givenUp) {
                        Console.WriteLine("Player has given up.");
                        return;
                    }

                    if (inputValidator.playerInputIsValid(playerWithCurrentTurn.input)) {
                        Console.WriteLine("Move accepted, here's the current board:");
                        
                        playerWithCurrentTurn.inputValid = true;
                        gameBoard.updateGameBoardWithPlayerInput(playerWithCurrentTurn.symbol,
                            playerWithCurrentTurn.input);
                    }
                    else {
                        Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                    }
                }

                playerWithCurrentTurn.inputValid = false;
                renderer.displayGameBoard(gameBoard);
                updateGameWinCondition();
                
                nextTurn();
            }
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
            if (playerIndex < players.Count - 1) {
                playerIndex++;
            }
            else {
                playerIndex = 0;
            }

            playerWithCurrentTurn = players[playerIndex];
        }
    }
}
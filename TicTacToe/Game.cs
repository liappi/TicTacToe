using System;
using System.Collections.Generic;

namespace TicTacToe {
    public class Game {
        private bool gameEnded;
        private GameBoard gameBoard;
        private List<Player> players;
//        private Player playerWithCurrentTurn;
        private GameReferee gameReferee;
        private InputValidator inputValidator;
        private Renderer renderer;
        private int currentPlayerIndex;

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
        }

        public void Start() {
            renderer.printWelcomeMessage();
            renderer.displayGameBoard(gameBoard);

            while (!gameEnded) {
                
                
                
                while (!players[currentPlayerIndex].inputValid) {
                    renderer.getPlayerInput(players[currentPlayerIndex]);

                    if (inputValidator.playerHasQuit(players[currentPlayerIndex].input)) {
                        renderer.printQuitMessage(currentPlayerIndex);
                    }

                    if (inputValidator.playerInputIsValid(players[currentPlayerIndex].input)) {
                        renderer.printInputAcceptedMessage();
                        
                        players[currentPlayerIndex].inputValid = true;
                        gameBoard.updateGameBoardWithPlayerInput(players[currentPlayerIndex].symbol,
                            players[currentPlayerIndex].input);
                    }
                    else {
                        renderer.printInvalidInputMessage();
                    }
                }

                players[currentPlayerIndex].inputValid = false;
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
            if (currentPlayerIndex < players.Count - 1) {
                currentPlayerIndex++;
            }
            else {
                currentPlayerIndex = 0;
            }
        }
    }
}
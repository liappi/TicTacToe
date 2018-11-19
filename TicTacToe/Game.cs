using System;
using System.Collections.Generic;

namespace TicTacToe {
    public class Game {
        private bool gameEnded;
        private GameBoard gameBoard;
        private List<Player> players;
        private Player playerWithCurrentTurn;

        public Game() {
            gameEnded = false;
            
            gameBoard = new GameBoard();
            players = new List<Player>();
            
            players.Add(new Player('X'));
            players.Add(new Player('O'));

            playerWithCurrentTurn = players[0];
        }

        public void Start() {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Here's the current board:");

            gameBoard.displayGameBoard();

            while (!gameEnded) {

                while (!playerWithCurrentTurn.inputValid) {
                    playerWithCurrentTurn.getPlayerInput();

                    if (playerWithCurrentTurn.givenUp) {
                        Console.WriteLine($"Player has given up.");
//                        Console.WriteLine($"Player {playerWithCurrentTurn.playerNumber} has given up.");
                        return;
                    }

                    if (gameBoard.playerInputIsValid(playerWithCurrentTurn.row, playerWithCurrentTurn.col)) {
                        Console.WriteLine("Move accepted, here's the current board:");
                        
                        playerWithCurrentTurn.inputValid = true;
                        gameBoard.updateGameBoardWithPlayerInput(playerWithCurrentTurn.symbol,
                            playerWithCurrentTurn.row, playerWithCurrentTurn.col);
                    }
                    else {
                        Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                    }
                }

                playerWithCurrentTurn.inputValid = false;
                gameBoard.displayGameBoard();
                updateGameWinCondition();
                
                nextTurn();

            }
//            End();
        }
        
        bool playerHasWon(char c) {
            return gameBoard.hasRowWin(c) || 
                   gameBoard.hasColumnWin(c) ||
                   gameBoard.hasDiagonalWin(c);
        }

        void updateGameWinCondition() {
            if (gameBoard.gameIsDrawn()) {
                gameEnded = true;
                Console.WriteLine("The game is a draw.");
            }
            else if (playerHasWon('X')) {
                gameEnded = true;
                Console.WriteLine("The winner is player one.");
            }
            else if (playerHasWon('O')) {                 
                gameEnded = true;
                Console.WriteLine("The winner is player two.");
            }
        }

        void nextTurn() {
            if (playerWithCurrentTurn.Equals(players[0])) {
                playerWithCurrentTurn = players[1];
            }
            else if (playerWithCurrentTurn.Equals(players[1])) {
                playerWithCurrentTurn = players[0];
            }
        }
    }
}
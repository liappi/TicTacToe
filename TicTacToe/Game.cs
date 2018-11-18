using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    public class Game {
        private enum Winner {
            None,
            Player1,
            Player2
        }
        
        private bool gameEnded;
        private Winner winner;
        private GameBoard gameBoard;
//        private Player player1;
//        private Player player2;
        private List<Player> players;
        private Player playerWithCurrentTurn;

        public Game() {
            gameEnded = false;
            winner = Winner.None;
            
            gameBoard = new GameBoard();
            
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
            End();
        }
        
        bool playerHasWon(char c) {
            return gameBoard.hasRowWin(c) || 
                   gameBoard.hasColumnWin(c) ||
                   gameBoard.hasDiagonalWin(c);
        }

        void updateGameWinCondition() {
            if (gameBoard.gameIsDrawn()) {
                gameEnded = true;
            }
            else if (playerHasWon('X')) {
                gameEnded = true;
                winner = Winner.Player1;
            }
            else if (playerHasWon('O')) {                 
                gameEnded = true;
                winner = Winner.Player2;
            }
        }

        void nextTurn() {
            if (playerWithCurrentTurn.Equals(player1)) {
                playerWithCurrentTurn = player2;
            }
            else if (playerWithCurrentTurn.Equals(player2)) {
                playerWithCurrentTurn = player1;
            }
        }

        private void End() {
            if (winner == Winner.None)
                Console.WriteLine("The game is a draw.");
            else if (winner == Winner.Player1)
                Console.WriteLine("The winner is player one.");
            else if (winner == Winner.Player2) 
                Console.WriteLine("The winner is player two.");
        }
        
    }
}
using System;

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
        private Player player1;
        private Player player2;
        private Player playerWithCurrentTurn;

        public Game() {
            gameEnded = false;
            winner = Winner.None;
            
            gameBoard = new GameBoard();
            player1 = new Player(1);
            player2 = new Player(2);

            playerWithCurrentTurn = player1;
        }

        public void Start() {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Here's the current board:");

            gameBoard.displayGameBoard();

            while (!gameEnded) {

                while (!playerWithCurrentTurn.inputValid) {
                    playerWithCurrentTurn.getPlayerInput();

                    if (playerWithCurrentTurn.givenUp) {
                        Console.WriteLine($"Player {playerWithCurrentTurn.playerNumber} has given up.");
                        return;
                    }

                    if (gameBoard.playerInputIsValid(playerWithCurrentTurn.row, playerWithCurrentTurn.col)) {
                        Console.WriteLine("Move accepted, here's the current board:");
                        
                        playerWithCurrentTurn.inputValid = true;
                        gameBoard.updateGameBoardWithPlayerInput(playerWithCurrentTurn.playerNumber,
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
        
        bool player1HasWon() {
            return playerHasWon('X');
        }

        bool player2HasWon() {
            return playerHasWon('O');
        }

        bool playerHasWon(char c) {
            return gameBoard.rowIsFilledWithSameCharacter(c) || 
                   gameBoard.columnIsFilledWithSameCharacter(c) ||
                   gameBoard.diagonalIsFilledWithSameCharacter(c);
        }

        void updateGameWinCondition() {
            if (gameBoard.gameIsDrawn()) {
                gameEnded = true;
            }
            else if (player1HasWon()) {
                gameEnded = true;
                winner = Winner.Player1;
            }
            else if (player2HasWon()) {                 
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
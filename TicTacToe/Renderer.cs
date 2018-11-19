using System;

namespace TicTacToe {
    public class Renderer {

        public Renderer() {
            
        }

        public void printWelcomeMessage() {
            Console.WriteLine("Welcome to Tic Tac Toe!");
        }

        public void printQuitMessage(int currentPlayerIndex) {
            Console.WriteLine($"Player {currentPlayerIndex + 1} has quit.");
        }

        public void printInputAcceptedMessage() {
            Console.WriteLine("Move accepted.");
        }

        public void printInvalidInputMessage() {
            Console.WriteLine("Oh no, a piece is already at this place! Try again...");
        }

        public void printGameDrawnMessage() {
            Console.WriteLine("The game is a draw.");
        }
        
        public void printWinnerMessage(int currentPlayerIndex) {
            Console.WriteLine($"The winner is Player {currentPlayerIndex + 1}");
        }
        
        public string getPlayerInput(int currentPlayerIndex, Player player) {
            Console.Write($"Player {currentPlayerIndex}, Enter a coord x,y to place your {player.symbol} or enter 'q' to give up: ");
            return Console.ReadLine();
        }
        
        public void displayGameBoard(GameBoard gameBoard) {
            Console.WriteLine("Here's the current board:");
            for (var i = 0; i < GameBoard.dimension; i++) {
                for (var j = 0; j < GameBoard.dimension; j++) {
                    Console.Write(gameBoard.board[i, j]);
                }

                Console.Write("\n");
            }
        }

    }
}
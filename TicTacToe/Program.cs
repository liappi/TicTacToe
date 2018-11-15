using System;
using System.Runtime.InteropServices;

namespace TicTacToe {
    internal class Program {
        public static void Main(string[] args) {
            var gameBoard = new GameBoard();
            var player1 = new Player(1);
            var player2 = new Player(2);

            var playerWithCurrentTurn = player1;

            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Here's the current board:");

            gameBoard.displayGameBoard();

            while (!gameBoard.gameEnded) {
                
                while (!player1.inputValid && !gameBoard.gameEnded) {
                    
                    player1.getPlayerInput();
                    
                    if (gameBoard.playerInputIsValid(player1.row, player1.col)) {
                        player1.inputValid = true;
                        gameBoard.updateGameBoardWithPlayerInput(player1.playerNumber, player1.row, player1.col);
                    }
                    else {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }               
                player1.inputValid = false;
                gameBoard.displayGameBoard();
                gameBoard.updateGameWinCondition();
                
                while (!player2.inputValid && !gameBoard.gameEnded) {
                    
                    player2.getPlayerInput();
                    
                    if (gameBoard.playerInputIsValid(player2.row, player2.col)) {
                        player2.inputValid = true;
                        gameBoard.updateGameBoardWithPlayerInput(player2.playerNumber, player2.row, player2.col);
                    }
                    else {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }                
                player2.inputValid = false;
                gameBoard.displayGameBoard();
                gameBoard.updateGameWinCondition();
            }

            if (gameBoard.winner.Equals(GameBoard.Winner.None)) {
                Console.WriteLine("The game has been drawn.");
            }
            else if (gameBoard.winner.Equals(GameBoard.Winner.Player1)) {
                Console.WriteLine("The winner is player one.");
            }
            else if (gameBoard.winner.Equals(GameBoard.Winner.Player2)) {
                Console.WriteLine("The winner is player two.");
            }
            
        }
    }
}
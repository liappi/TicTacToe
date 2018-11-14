using System;

namespace TicTacToe {
    internal class Program {
        public static void Main(string[] args) {
            var gameBoard = new GameBoard();
            var player1 = new Player(1);
            var player2 = new Player(2);

            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Here's the current board:");

            gameBoard.displayGameBoard();

            while (!gameBoard.gameEnded) {
                player1.getPlayerInput();

//                while (!player1.inputValid) {
//                    
//                }

                if (gameBoard.playerInputIsValid(player1.row, player1.col)) {
                    gameBoard.updateGameBoardWithPlayerInput(player1.playerNumber, player1.row, player1.col);
                }
                else {
                    Console.WriteLine("Invalid input.");
                }

                gameBoard.displayGameBoard();

                player2.getPlayerInput();

                if (gameBoard.playerInputIsValid(player2.row, player2.col)) {
                    gameBoard.updateGameBoardWithPlayerInput(player2.playerNumber, player2.row, player2.col);
                }
                else {
                    Console.WriteLine("Invalid input.");
                }

                gameBoard.displayGameBoard();
            }
        }
    }
}
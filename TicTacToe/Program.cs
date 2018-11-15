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

                while (!playerWithCurrentTurn.inputValid) {
                    playerWithCurrentTurn.getPlayerInput();
                    
                    if (gameBoard.playerInputIsValid(playerWithCurrentTurn.row, playerWithCurrentTurn.col)) {
                        playerWithCurrentTurn.inputValid = true;
                        gameBoard.updateGameBoardWithPlayerInput(playerWithCurrentTurn.playerNumber, playerWithCurrentTurn.row, playerWithCurrentTurn.col);
                    }
                    else {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }
                playerWithCurrentTurn.inputValid = false;
                gameBoard.displayGameBoard();
                gameBoard.updateGameWinCondition();

                if (playerWithCurrentTurn.Equals(player1)) {
                    playerWithCurrentTurn = player2;
                }
                else if (playerWithCurrentTurn.Equals(player2)) {
                    playerWithCurrentTurn = player1;
                }
            }

            if (gameBoard.winner == GameBoard.Winner.None)
                Console.WriteLine("The game has been drawn.");
            else if (gameBoard.winner == GameBoard.Winner.Player1)
                Console.WriteLine("The winner is player one.");
            else if (gameBoard.winner == GameBoard.Winner.Player2) Console.WriteLine("The winner is player two.");
        }
    }
}
using System;

namespace TicTacToe {
    public class GameBoard {
        public char[,] board;
        public const int dimension = 3;
       
        public GameBoard() {
            board = new char[dimension, dimension];

            for (var i = 0; i < dimension; i++) {
                for (var j = 0; j < dimension; j++) {
                    board[i, j] = '.';
                }
            }
        }

        public void displayGameBoard() {
            for (var i = 0; i < dimension; i++) {
                for (var j = 0; j < dimension; j++) {
                    Console.Write(board[i, j]);
                }

                Console.Write("\n");
            }
        }

        public void updateGameBoardWithPlayerInput(char symbol, string input) {
            var coordinates = input.Split(',');
            var col = Convert.ToInt32(coordinates[0]);
            var row = Convert.ToInt32(coordinates[1]);
            
            board[row - 1, col - 1] = symbol;
        }
    }
}
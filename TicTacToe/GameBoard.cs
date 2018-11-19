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

        public void updateGameBoardWithPlayerInput(char symbol, int row, int col) {
            board[row - 1, col - 1] = symbol;
        }
    }
}
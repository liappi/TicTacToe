using System;
using Microsoft.SqlServer.Server;

namespace TicTacToe {
    public class GameBoard {
        private char[,] board;
        const int dimension = 3;
        public bool gameEnded;

        public GameBoard() {
            board = new char[dimension, dimension];
            gameEnded = false;

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

        public bool playerInputIsValid(int row, int col) {
            if (row <= dimension && row > 0 &&
                col <= dimension && col > 0 &&
                board[row - 1, col - 1].Equals('.')) {
                return true;
            }

            return false;
        }

        public void updateGameBoardWithPlayerInput(int player, int row, int col) {
            if (player == 1) {
                board[row - 1, col - 1] = 'X';
            }
            else if (player == 2) {
                board[row - 1, col - 1] = 'O';
            }
        }
    }
}
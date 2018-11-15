using System;
using Microsoft.SqlServer.Server;

namespace TicTacToe {
    public class GameBoard {

        public enum Winner {
            None,
            Player1,
            Player2
        };

        private char[,] board;
        const int dimension = 3;
        public bool gameEnded;
        public Winner winner;
        
       
        public GameBoard() {
            board = new char[dimension, dimension];
            gameEnded = false;
            winner = Winner.None;

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

        public void updateGameWinCondition() {
            if (gameIsDrawn()) {
                gameEnded = true;
            }
            else if (rowIsFilledWithSameCharacter('X') || 
                    columnIsFilledWithSameCharacter('X') || 
                    diagonalIsFilledWithSameCharacter('X')) {

                gameEnded = true;
                winner = Winner.Player1;
            }
            else if (rowIsFilledWithSameCharacter('O') || 
                     columnIsFilledWithSameCharacter('O') || 
                     diagonalIsFilledWithSameCharacter('O')) {
                    
                gameEnded = true;
                winner = Winner.Player2;
            }
        }


        private bool rowIsFilledWithSameCharacter(char c) {
            for (var i = 0; i < dimension; i++) {
                if (board[i, 0].Equals(c) &&
                    board[i, 1].Equals(c) &&
                    board[i, 2].Equals(c) ) {
                    return true;
                }
            }
    
            return false;
        }

        private bool columnIsFilledWithSameCharacter(char c) {
            for (var j = 0; j < dimension; j++) {
                if (board[0, j].Equals(c) &&
                    board[1, j].Equals(c) &&
                    board[2, j].Equals(c) ) {
                    return true;
                }
            }
    
            return false;
        }

        private bool diagonalIsFilledWithSameCharacter(char c) {
            return (board[0, 0].Equals(c) && board[1, 1].Equals(c) && board[2, 2].Equals(c)) ||
                   (board[0, 2].Equals(c) && board[1, 1].Equals(c) && board[2, 0].Equals(c));
        }

        private bool gameIsDrawn() {
            for (var i = 0; i < dimension; i++) {
                for (var j = 0; j < dimension; j++) {
                    if (board[i, j] != '.') {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
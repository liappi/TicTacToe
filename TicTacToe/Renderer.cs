using System;

namespace TicTacToe {
    public class Renderer {

        public Renderer() {
            
        }
        
        public void getPlayerInput(Player player) {
            Console.Write($"Enter a coord x,y to place your {player.symbol} or enter 'q' to give up: ");
            player.input = Console.ReadLine();
        }
        
        public void displayGameBoard(GameBoard gameBoard) {
            for (var i = 0; i < GameBoard.dimension; i++) {
                for (var j = 0; j < GameBoard.dimension; j++) {
                    Console.Write(gameBoard.board[i, j]);
                }

                Console.Write("\n");
            }
        }

    }
}
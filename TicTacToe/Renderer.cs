using System;

namespace TicTacToe {
    public class Renderer {

        public Renderer() {
            
        }
        
        public void getPlayerInput(Player player) {
            Console.Write($"Enter a coord x,y to place your {player.symbol} or enter 'q' to give up: ");
            player.input = Console.ReadLine();
        }
    }
}
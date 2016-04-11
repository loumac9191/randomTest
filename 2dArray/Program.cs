using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player playerOne = new Player();
            Player playerTwo = new Player();

            Game game = new Game(board, playerOne, playerTwo);

            foreach (var item in game._board.board.ElementAt(2).Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in game._board.board.ElementAt(2).Values)
            {
                Console.WriteLine(item);
            }

            string shouldBeBlank = game._board.board.ElementAt(4).ElementAt(1).Key;
            Console.WriteLine(shouldBeBlank);

            Mover moveSomething = new Mover(game);

            Piece randomPiece = game._board.board.ElementAt(1).ElementAt(4).Value;

            //THIS IS ACTUALLY MOVING TO 3, 5 CURRENTLY
            int[] testCords = new int[]
            {
                2,
                4
            };

            moveSomething.MovePiece(game, randomPiece, testCords);

            Console.WriteLine(shouldBeBlank);
        }
    }
}

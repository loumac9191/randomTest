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
            //Board board = new Board();

            //string s = board.board.ElementAt(0).ElementAt(0).Value.Colour;
            //string s3 = board.board.ElementAt(7).ElementAt(7).Value.Colour;
            //string s2 = board.board.ElementAt(0).ElementAt(4).Value.Colour.ToString();
            //string s4 = board.board.ElementAt(6).ElementAt(3).Value.InherentValue.ToString();
            //int yAxis = 0;
            //int xAxis = 3;
            //var r = board.board.ElementAt(0);
            //var u = board.board.ElementAt(0).ElementAt(4).Value;

            //Console.WriteLine(s);
            //Console.WriteLine(s2);
            //Console.WriteLine(s3);
            //Console.WriteLine(s4);

            //int pCount = 0;

            //foreach (var piece in board.board)
            //{
            //    //How to count the pieces on the board  
            //    pCount = pCount + piece.Where(x => x.Value is Piece).Count();
            //}

            //Console.WriteLine(pCount);

            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Value);
            //}

            ////remove
            //board.board.ElementAt(yAxis).Remove(board.board.ElementAt(yAxis).ElementAt(xAxis).Key);

            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Value);
            //}

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

            Piece randomPiece = game._board.board.ElementAt(0).ElementAt(4).Value;

            int[] testCords = new int[]
            {
                4,
                1
            };

            moveSomething.MovePiece(game, randomPiece, testCords);

            Console.WriteLine(shouldBeBlank);
        }
    }
}

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
            Converter convertStuff = new Converter();

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

            //Piece randomPiece = game._board.board.ElementAt(1).ElementAt(4).Value;

            ////THIS IS ACTUALLY MOVING TO 3, 5 CURRENTLY or 3y, 4x in index
            //int[] testCords = new int[]
            //{
            //    4,
            //    5
            //};

            //moveSomething.MovePiece(game, randomPiece, testCords);

            //Piece pawn1 = game._board.board.ElementAt(1).ElementAt(7).Value;

            //int[] testCords3 = new int[]
            //{
            //    4,
            //    8
            //};

            //moveSomething.MovePiece(game, pawn1, testCords3);

            //Console.WriteLine(shouldBeBlank);

            //int[] testCords4 = new int[]
            //{
            //    5,
            //    7
            //};

            //moveSomething.MovePiece(game, pawn1, testCords4);

            //Piece randomPiece2 = game._board.board.ElementAt(0).ElementAt(7).Value;

            ////THIS IS ACTUALLY MOVING TO 2, 7 in index
            //int[] testCords2 = new int[]
            //{
            //    3,
            //    8
            //};

            //moveSomething.MovePiece(game, randomPiece2, testCords2);

            //Console.WriteLine("Hello");

            //int[] testCords5 = new int[]
            //{
            //    4,
            //    8
            //};

            //moveSomething.MovePiece(game, randomPiece2, testCords5);


            string typeOfPiece = game._board.board.ElementAt(0).ElementAt(2).Value.GetType().ToString();

            string testString = "e7";

            int[] testIntArray = convertStuff.ConvertBoardPositionToCoordinate(testString);

            Console.WriteLine(typeOfPiece);
            Console.WriteLine(testIntArray);

            Piece d7 = game._board.board.ElementAt(1).ElementAt(3).Value;
            Piece e2 = game._board.board.ElementAt(6).ElementAt(4).Value;
            Piece c8 = game._board.board.ElementAt(0).ElementAt(2).Value;
            Piece a2 = game._board.board.ElementAt(6).ElementAt(0).Value;

            int[] d7ToD5 = new int[]
            {
                4,
                4
            };
            moveSomething.MovePiece(game, d7, d7ToD5);

            int[] e2ToE3 = new int[]
            {
                6,
                5
            };
            moveSomething.MovePiece(game, e2, e2ToE3);

            int[] c8ToG4 = new int[]
            {
                5,
                7
            };
            moveSomething.MovePiece(game, c8, c8ToG4);

            int[] a2ToA3 = new int[]
            {
                6,
                1
            };
            moveSomething.MovePiece(game, a2, a2ToA3);

            int[] g4ToD1 = new int[]
            {
                8,
                4
            };
            moveSomething.MovePiece(game, c8,g4ToD1);

            Console.WriteLine("Hello");
        }
    }
}

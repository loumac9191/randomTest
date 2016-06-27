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


            //****************************************SECOND MOVE******************************************

            //string typeOfPiece = game._board.board.ElementAt(0).ElementAt(2).Value.GetType().ToString();

            //string testString = "e7";

            //int[] testIntArray = convertStuff.ConvertBoardPositionToCoordinate(testString);

            //Console.WriteLine(typeOfPiece);
            //Console.WriteLine(testIntArray);

            //Piece d7 = game._board.board.ElementAt(1).ElementAt(3).Value;
            //Piece e2 = game._board.board.ElementAt(6).ElementAt(4).Value;
            //Piece c8 = game._board.board.ElementAt(0).ElementAt(2).Value;
            //Piece a2 = game._board.board.ElementAt(6).ElementAt(0).Value;

            //int[] d7ToD5 = new int[]
            //{
            //    4,
            //    4
            //};
            //moveSomething.MovePiece(game, d7, d7ToD5);

            //int[] e2ToE3 = new int[]
            //{
            //    6,
            //    5
            //};
            //moveSomething.MovePiece(game, e2, e2ToE3);

            //int[] c8ToG4 = new int[]
            //{
            //    5,
            //    7
            //};
            //moveSomething.MovePiece(game, c8, c8ToG4);

            //int[] a2ToA3 = new int[]
            //{
            //    6,
            //    1
            //};
            //moveSomething.MovePiece(game, a2, a2ToA3);

            //int[] g4ToD1 = new int[]
            //{
            //    8,
            //    4
            //};
            //moveSomething.MovePiece(game, c8,g4ToD1);


            //***********************************************************************************************
            //***********************************************FOOLS MATE * *************************************
            //***********************************************************************************************
            //string typeOfPiece = game._board.board.ElementAt(0).ElementAt(2).Value.GetType().ToString();

            //string testString = "e7";

            //int[] testIntArray = convertStuff.ConvertBoardPositionToCoordinate(testString);

            //Console.WriteLine(typeOfPiece);
            //Console.WriteLine(testIntArray);

            //Piece e7 = game._board.board.ElementAt(1).ElementAt(4).Value;
            //Piece e2 = game._board.board.ElementAt(6).ElementAt(4).Value;
            //Piece d8 = game._board.board.ElementAt(0).ElementAt(3).Value;
            //Piece g2 = game._board.board.ElementAt(6).ElementAt(5).Value;

            //int[] e2ToE3 = new int[]
            //{
            //    6,
            //    5
            //};
            //moveSomething.MovePiece(e2, e2ToE3);

            //int[] e7ToE5 = new int[]
            //{
            //    4,
            //    5
            //};
            //moveSomething.MovePiece(e7, e7ToE5);

            //int[] g2Tog4 = new int[]
            //{
            //    5,
            //    6
            //};
            //moveSomething.MovePiece(g2, g2Tog4);

            //int[] d8ToH4 = new int[]
            //{
            //    5,
            //    8
            //};
            //moveSomething.MovePiece(d8, d8ToH4);
            //Console.WriteLine("end");


            //Console.WriteLine("Hello");
            //Console.ReadLine();
            ////*****************************************************************************
            ////*************************TARRASCH VS ECKART 1889 ****************************
            ////*****************************************************************************
            Piece e2 = game._board.board.ElementAt(6).ElementAt(4).Value;
            Piece e7 = game._board.board.ElementAt(1).ElementAt(4).Value;
            int[] e2ToE4 = new int[]
            {
                5,
                5
            };
            //1
            moveSomething.MovePiece(e2, e2ToE4);
            int[] e7ToE6 = new int[]
            {
                3,
                5
            };
            //2
            moveSomething.MovePiece(e7, e7ToE6);
            Piece d2 = game._board.board.ElementAt(6).ElementAt(3).Value;
            int[] d2ToD4 = new int[]
            {
                5,
                4
            };
            //3
            moveSomething.MovePiece(d2, d2ToD4);
            Piece d7 = game._board.board.ElementAt(1).ElementAt(3).Value;
            int[] d7ToD5 = new int[]
            {
                4,
                4
            };
            //4
            moveSomething.MovePiece(d7, d7ToD5);
            Piece b1 = game._board.board.ElementAt(7).ElementAt(1).Value;
            int[] b1ToD2 = new int[]
            {
                7,
                4
            };
            //5
            moveSomething.MovePiece(b1, b1ToD2);
            Piece g8 = game._board.board.ElementAt(0).ElementAt(6).Value;
            int[] g8ToF6 = new int[]
            {
                3,
                6
            };
            //6
            moveSomething.MovePiece(g8, g8ToF6);
            int[] e4ToE5 = new int[]
            {
                4,
                5
            };
            //7
            moveSomething.MovePiece(e2, e4ToE5);
            int[] f6ToD7 = new int[]
            {
                2,
                4
            };
            //8
            moveSomething.MovePiece(g8, f6ToD7);
            Piece f1 = game._board.board.ElementAt(7).ElementAt(5).Value;
            int[] f1ToD3 = new int[]
            {
                6,
                4
            };
            //9
            moveSomething.MovePiece(f1, f1ToD3);
            Piece c7 = game._board.board.ElementAt(1).ElementAt(2).Value;
            int[] c7ToC5 = new int[]
            {
                4,
                3
            };
            //10
            moveSomething.MovePiece(c7, c7ToC5);
            Piece c2 = game._board.board.ElementAt(6).ElementAt(2).Value;
            int[] c2ToC3 = new int[]
            {
                6,
                3
            };
            //11
            moveSomething.MovePiece(c2, c2ToC3);
            Piece b8 = game._board.board.ElementAt(0).ElementAt(1).Value;
            int[] b8ToC6 = new int[]
            {
                3,
                3
            };
            //12
            moveSomething.MovePiece(b8, b8ToC6);
            Piece g1 = game._board.board.ElementAt(7).ElementAt(6).Value;
            int[] g1ToE2 = new int[]
            {
                7,
                5
            };
            //13
            moveSomething.MovePiece(g1, g1ToE2);
            Piece d8 = game._board.board.ElementAt(0).ElementAt(3).Value;
            int[] d8ToB6 = new int[]
            {
                3,
                2
            };
            //14
            moveSomething.MovePiece(d8, d8ToB6);
            int[] d2ToF3 = new int[]
            {
                6,
                6
            };
            //15
            moveSomething.MovePiece(b1, d2ToF3);
            Piece f8 = game._board.board.ElementAt(0).ElementAt(5).Value;
            int[] f8ToE7 = new int[]
            {
                2,
                5
            };
            //16
            moveSomething.MovePiece(f8, f8ToE7);
            Piece e1 = game._board.board.ElementAt(7).ElementAt(4).Value;
            int[] e1ToG1 = new int[]
            {
                8,
                7
            };
            //17 ** CASTLING *
            moveSomething.MovePiece(e1, e1ToG1);
            Piece e8 = game._board.board.ElementAt(0).ElementAt(4).Value;
            int[] e8ToG8 = new int[]
            {
                1,
                7
            };
            //18 ** CASTLING
            moveSomething.MovePiece(e8, e8ToG8);
            int[] e2ToF4 = new int[]
            {
                5,
                6
            };
            //19
            moveSomething.MovePiece(g1, e2ToF4);
            int[] c6ToD8 = new int[]
            {
                1,
                4
            };
            //20
            moveSomething.MovePiece(b8, c6ToD8);
            Piece d1 = game._board.board.ElementAt(7).ElementAt(3).Value;
            int[] d1ToC2 = new int[]
            {
                7,
                3
            };
            //21
            moveSomething.MovePiece(d1, d1ToC2);
            Piece f7 = game._board.board.ElementAt(1).ElementAt(5).Value;
            int[] f7ToF5 = new int[]
            {
                4,
                6
            };
            //22
            moveSomething.MovePiece(f7, f7ToF5);
            //EN PASSANT HERE
            //next move
            int[] e5ToF6 = new int[]
            {
                3,
                6
            };
            //23 EN PASSANT **EVERYTHING BREAKS HERE
            moveSomething.MovePiece(e2, e5ToF6);
            int[] d7ToF6 = new int[]
            {
                3,
                6
            };
            //24
            moveSomething.MovePiece(g8, d7ToF6);
            int[] f3ToG5 = new int[]
            {
                4,
                7
            };
            //25
            moveSomething.MovePiece(b1, f3ToG5);
            Piece g7 = game._board.board.ElementAt(1).ElementAt(6).Value;
            int[] g7ToG6 = new int[]
            {
                3,
                7
            };
            //26
            moveSomething.MovePiece(g7, g7ToG6);
            int[] d3ToG6 = new int[]
            {
                3,
                7
            };
            //27
            moveSomething.MovePiece(f1, d3ToG6);
            Piece h7 = game._board.board.ElementAt(1).ElementAt(7).Value;
            int[] h7ToG6 = new int[]
            {
                3,
                7
            };
            //28
            moveSomething.MovePiece(h7, h7ToG6);
            int[] c2ToG6 = new int[]
            {
                3,
                7
            };
            //29
            moveSomething.MovePiece(d1, c2ToG6);
            int[] g8ToH8 = new int[]
            {
                1,
                8
            };
            //30
            moveSomething.MovePiece(e8, g8ToH8);
            int[] g6ToH6 = new int[]
            {
                3,
                8
            };
            //31
            moveSomething.MovePiece(d1, g6ToH6);
            int[] h8ToG8 = new int[]
            {
                1,
                7
            };
            //32
            moveSomething.MovePiece(e8, h8ToG8);
            int[] f4ToG6 = new int[]
            {
                3,
                7
            };
            //33
            //CHECKMATE
            moveSomething.MovePiece(g1, f4ToG6);
            Console.WriteLine("end");
        }
    }
}

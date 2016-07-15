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
            string typeOfPiece = game._board.board.ElementAt(0).ElementAt(2).Value.GetType().ToString();

            string testString = "e7";

            int[] testIntArray = convertStuff.ConvertBoardPositionToCoordinate(testString);

            Console.WriteLine(typeOfPiece);
            Console.WriteLine(testIntArray);

            Piece e7 = game._board.board.ElementAt(1).ElementAt(4).Value;
            Piece f2 = game._board.board.ElementAt(6).ElementAt(5).Value;
            Piece d8 = game._board.board.ElementAt(0).ElementAt(3).Value;
            Piece g2 = game._board.board.ElementAt(6).ElementAt(6).Value;

            int[] f2Tof3 = new int[]
            {
                6,
                6
            };
            moveSomething.MovePiece(f2, f2Tof3);

            int[] e7ToE5 = new int[]
            {
                4,
                5
            };
            moveSomething.MovePiece(e7, e7ToE5);

            int[] g2ToG4 = new int[]
            {
                5,
                7
            };
            moveSomething.MovePiece(g2, g2ToG4);

            int[] d8ToH4 = new int[]
            {
                5,
                8
            };
            moveSomething.MovePiece(d8, d8ToH4);
            Console.WriteLine("end");


            Console.WriteLine("Hello");
            Console.ReadLine();
            //////*****************************************************************************
            //////*************************TARRASCH VS ECKART 1889 ****************************
            //////*****************************************************************************
            //Piece e2 = game._board.board.ElementAt(6).ElementAt(4).Value;
            //Piece e7 = game._board.board.ElementAt(1).ElementAt(4).Value;
            //int[] e2ToE4 = new int[]
            //{
            //    5,
            //    5
            //};
            ////1
            //moveSomething.MovePiece(e2, e2ToE4);
            //int[] e7ToE6 = new int[]
            //{
            //    3,
            //    5
            //};
            ////2
            //moveSomething.MovePiece(e7, e7ToE6);
            //Piece d2 = game._board.board.ElementAt(6).ElementAt(3).Value;
            //int[] d2ToD4 = new int[]
            //{
            //    5,
            //    4
            //};
            ////3
            //moveSomething.MovePiece(d2, d2ToD4);
            //Piece d7 = game._board.board.ElementAt(1).ElementAt(3).Value;
            //int[] d7ToD5 = new int[]
            //{
            //    4,
            //    4
            //};
            ////4
            //moveSomething.MovePiece(d7, d7ToD5);
            //Piece b1 = game._board.board.ElementAt(7).ElementAt(1).Value;
            //int[] b1ToD2 = new int[]
            //{
            //    7,
            //    4
            //};
            ////5
            //moveSomething.MovePiece(b1, b1ToD2);
            //Piece g8 = game._board.board.ElementAt(0).ElementAt(6).Value;
            //int[] g8ToF6 = new int[]
            //{
            //    3,
            //    6
            //};
            ////6
            //moveSomething.MovePiece(g8, g8ToF6);
            //int[] e4ToE5 = new int[]
            //{
            //    4,
            //    5
            //};
            ////7
            //moveSomething.MovePiece(e2, e4ToE5);
            //int[] f6ToD7 = new int[]
            //{
            //    2,
            //    4
            //};
            ////8
            //moveSomething.MovePiece(g8, f6ToD7);
            //Piece f1 = game._board.board.ElementAt(7).ElementAt(5).Value;
            //int[] f1ToD3 = new int[]
            //{
            //    6,
            //    4
            //};
            ////9
            //moveSomething.MovePiece(f1, f1ToD3);
            //Piece c7 = game._board.board.ElementAt(1).ElementAt(2).Value;
            //int[] c7ToC5 = new int[]
            //{
            //    4,
            //    3
            //};
            ////10
            //moveSomething.MovePiece(c7, c7ToC5);
            //Piece c2 = game._board.board.ElementAt(6).ElementAt(2).Value;
            //int[] c2ToC3 = new int[]
            //{
            //    6,
            //    3
            //};
            ////11
            //moveSomething.MovePiece(c2, c2ToC3);
            //Piece b8 = game._board.board.ElementAt(0).ElementAt(1).Value;
            //int[] b8ToC6 = new int[]
            //{
            //    3,
            //    3
            //};
            ////12
            //moveSomething.MovePiece(b8, b8ToC6);
            //Piece g1 = game._board.board.ElementAt(7).ElementAt(6).Value;
            //int[] g1ToE2 = new int[]
            //{
            //    7,
            //    5
            //};
            ////13
            //moveSomething.MovePiece(g1, g1ToE2);
            //Piece d8 = game._board.board.ElementAt(0).ElementAt(3).Value;
            //int[] d8ToB6 = new int[]
            //{
            //    3,
            //    2
            //};
            ////14
            //moveSomething.MovePiece(d8, d8ToB6);
            //int[] d2ToF3 = new int[]
            //{
            //    6,
            //    6
            //};
            ////15
            //moveSomething.MovePiece(b1, d2ToF3);
            //Piece f8 = game._board.board.ElementAt(0).ElementAt(5).Value;
            //int[] f8ToE7 = new int[]
            //{
            //    2,
            //    5
            //};
            ////16
            //moveSomething.MovePiece(f8, f8ToE7);
            //Piece e1 = game._board.board.ElementAt(7).ElementAt(4).Value;
            //int[] e1ToG1 = new int[]
            //{
            //    8,
            //    7
            //};
            ////17 ** CASTLING *
            //moveSomething.MovePiece(e1, e1ToG1);
            //Piece e8 = game._board.board.ElementAt(0).ElementAt(4).Value;
            //int[] e8ToG8 = new int[]
            //{
            //    1,
            //    7
            //};
            ////18 ** CASTLING
            //moveSomething.MovePiece(e8, e8ToG8);
            //int[] e2ToF4 = new int[]
            //{
            //    5,
            //    6
            //};
            ////19
            //moveSomething.MovePiece(g1, e2ToF4);
            //int[] c6ToD8 = new int[]
            //{
            //    1,
            //    4
            //};
            ////20
            //moveSomething.MovePiece(b8, c6ToD8);
            //Piece d1 = game._board.board.ElementAt(7).ElementAt(3).Value;
            //int[] d1ToC2 = new int[]
            //{
            //    7,
            //    3
            //};
            ////21
            //moveSomething.MovePiece(d1, d1ToC2);
            //Piece f7 = game._board.board.ElementAt(1).ElementAt(5).Value;
            //int[] f7ToF5 = new int[]
            //{
            //    4,
            //    6
            //};
            ////22
            //moveSomething.MovePiece(f7, f7ToF5);
            ////EN PASSANT HERE
            ////next move
            //int[] e5ToF6 = new int[]
            //{
            //    3,
            //    6
            //};
            ////23 EN PASSANT **EVERYTHING BREAKS HERE
            //moveSomething.MovePiece(e2, e5ToF6);
            //int[] d7ToF6 = new int[]
            //{
            //    3,
            //    6
            //};
            ////24
            //moveSomething.MovePiece(g8, d7ToF6);
            //int[] f3ToG5 = new int[]
            //{
            //    4,
            //    7
            //};
            ////25
            //moveSomething.MovePiece(b1, f3ToG5);
            //Piece g7 = game._board.board.ElementAt(1).ElementAt(6).Value;
            //int[] g7ToG6 = new int[]
            //{
            //    3,
            //    7
            //};
            ////26
            //moveSomething.MovePiece(g7, g7ToG6);
            //int[] d3ToG6 = new int[]
            //{
            //    3,
            //    7
            //};
            ////27
            //moveSomething.MovePiece(f1, d3ToG6);
            //Piece h7 = game._board.board.ElementAt(1).ElementAt(7).Value;
            //int[] h7ToG6 = new int[]
            //{
            //    3,
            //    7
            //};
            ////28
            //moveSomething.MovePiece(h7, h7ToG6);
            //int[] c2ToG6 = new int[]
            //{
            //    3,
            //    7
            //};
            ////29
            //moveSomething.MovePiece(d1, c2ToG6);
            //int[] g8ToH8 = new int[]
            //{
            //    1,
            //    8
            //};
            ////30
            //moveSomething.MovePiece(e8, g8ToH8);
            //int[] g6ToH6 = new int[]
            //{
            //    3,
            //    8
            //};
            ////31
            //moveSomething.MovePiece(d1, g6ToH6);
            //int[] h8ToG8 = new int[]
            //{
            //    1,
            //    7
            //};
            ////32
            //moveSomething.MovePiece(e8, h8ToG8);
            //int[] f4ToG6 = new int[]
            //{
            //    3,
            //    7
            //};
            ////33
            ////CHECKMATE
            //moveSomething.MovePiece(g1, f4ToG6);
            //Console.WriteLine("end");
            ////////*****************************************************************************
            ////////*************************OLCUM VS TSERETELI 2009 ****************************
            ////////*****************************************************************************
            //List<SortedDictionary<string, Piece>> Game = game._board.board;
            ////1
            //Piece e2 = Game.ElementAt(6).ElementAt(4).Value;
            //int[] e2ToE4 = new int[]
            //{
            //    5,
            //    5
            //};
            //moveSomething.MovePiece(e2, e2ToE4);
            ////2
            //Piece c7 = Game.ElementAt(1).ElementAt(2).Value;
            //int[] c7Toc5 = new int[]
            //{
            //    4,
            //    3
            //};
            //moveSomething.MovePiece(c7, c7Toc5);
            ////3
            //Piece g1 = Game.ElementAt(7).ElementAt(6).Value;
            //int[] g1ToF3 = new int[]
            //{
            //    6,
            //    6
            //};
            //moveSomething.MovePiece(g1, g1ToF3);
            ////4
            //Piece b8 = Game.ElementAt(0).ElementAt(1).Value;
            //int[] b8ToC6 = new int[]
            //{
            //    3,
            //    3
            //};
            //moveSomething.MovePiece(b8, b8ToC6);
            ////5
            //Piece f1 = Game.ElementAt(7).ElementAt(5).Value;
            //int[] f1ToB5 = new int[]
            //{
            //    4,
            //    2
            //};
            //moveSomething.MovePiece(f1, f1ToB5);
            ////6
            //Piece g7 = Game.ElementAt(1).ElementAt(6).Value;
            //int[] g7ToG6 = new int[]
            //{
            //    3,
            //    7
            //};
            //moveSomething.MovePiece(g7, g7ToG6);
            ////7
            //int[] b5ToC6 = new int[]
            //{
            //    3,
            //    3
            //};
            //moveSomething.MovePiece(f1, b5ToC6);
            ////8
            //Piece d7 = Game.ElementAt(1).ElementAt(3).Value;
            //int[] d7ToC6 = new int[]
            //{
            //    3,
            //    3
            //};
            //moveSomething.MovePiece(d7, d7ToC6);
            ////9
            //Piece h2 = Game.ElementAt(6).ElementAt(7).Value;
            //int[] h2ToH3 = new int[]
            //{
            //    6,
            //    8
            //};
            //moveSomething.MovePiece(h2, h2ToH3);
            ////10
            //Piece f8 = Game.ElementAt(0).ElementAt(5).Value;
            //int[] f8ToG7 = new int[]
            //{
            //    2,
            //    7
            //};
            //moveSomething.MovePiece(f8, f8ToG7);
            ////11
            //Piece d2 = Game.ElementAt(6).ElementAt(3).Value;
            //int[] d2ToD3 = new int[]
            //{
            //    6,
            //    4
            //};
            //moveSomething.MovePiece(d2, d2ToD3);
            ////12
            //Piece e7 = Game.ElementAt(1).ElementAt(4).Value;
            //int[] e7ToE5 = new int[]
            //{
            //    4,
            //    5
            //};
            //moveSomething.MovePiece(e7, e7ToE5);
            ////13
            //Piece c1 = Game.ElementAt(7).ElementAt(2).Value;
            //int[] c1ToE3 = new int[]
            //{
            //    6,
            //    5
            //};
            //moveSomething.MovePiece(c1, c1ToE3);
            ////14
            //Piece d8 = Game.ElementAt(0).ElementAt(3).Value;
            //int[] d8ToE7 = new int[]
            //{
            //    2,
            //    5
            //};
            //moveSomething.MovePiece(d8, d8ToE7);
            ////15
            //Piece b1 = Game.ElementAt(7).ElementAt(1).Value;
            //int[] b1ToC3 = new int[]
            //{
            //    6,
            //    3
            //};
            //moveSomething.MovePiece(b1, b1ToC3);
            ////16
            //Piece g8 = Game.ElementAt(0).ElementAt(6).Value;
            //int[] g8ToF6 = new int[]
            //{
            //    3,
            //    6
            //};
            //moveSomething.MovePiece(g8, g8ToF6);
            ////17
            //Piece e1 = Game.ElementAt(7).ElementAt(4).Value;
            //int[] e1ToF1 = new int[]
            //{
            //    8,
            //    7
            //};
            ////CASTLING
            //moveSomething.MovePiece(e1, e1ToF1);
            ////18
            //int[] g6ToD7 = new int[]
            //{
            //    2,
            //    4
            //};
            //moveSomething.MovePiece(g8, g6ToD7);
            ////19
            //Piece d1 = Game.ElementAt(7).ElementAt(3).Value;
            //int[] d1ToD2 = new int[]
            //{
            //    7,
            //    4
            //};
            //moveSomething.MovePiece(d1, d1ToD2);
            ////20
            //int[] d7ToF8 = new int[]
            //{
            //    1,
            //    6
            //};
            //moveSomething.MovePiece(g8, d7ToF8);
            ////21
            //int[] e3ToH6 = new int[]
            //{
            //    3,
            //    8
            //};
            //moveSomething.MovePiece(c1, e3ToH6);
            ////22
            //Piece f7 = Game.ElementAt(1).ElementAt(5).Value;
            //int[] f7ToF6 = new int[]
            //{
            //    3,
            //    6
            //};
            //moveSomething.MovePiece(f7, f7ToF6);
            ////23
            //int[] h6ToG7 = new int[]
            //{
            //    2,
            //    7
            //};
            //moveSomething.MovePiece(c1, h6ToG7);
            ////24
            //int[] e7ToG7 = new int[]
            //{
            //    2,
            //    7
            //};
            //moveSomething.MovePiece(d8, e7ToG7);
            ////25
            //int[] d2ToE3 = new int[]
            //{
            //    6,
            //    5
            //};
            //moveSomething.MovePiece(d1, d2ToE3);
            ////26
            //int[] f8ToE6 = new int[]
            //{
            //    3,
            //    5
            //};
            //moveSomething.MovePiece(g8, f8ToE6);
            ////27
            //int[] c3ToE2 = new int[]
            //{
            //    7,
            //    5
            //};
            //moveSomething.MovePiece(b1, c3ToE2);
            ////28
            //int[] g6ToG5 = new int[]
            //{
            //    4,
            //    7
            //};
            //moveSomething.MovePiece(g7, g6ToG5);
            ////29
            //int[] e2ToG3 = new int[]
            //{
            //    6,
            //    7
            //};
            //moveSomething.MovePiece(b1, e2ToG3);
            ////30
            //int[] e6ToF4 = new int[]
            //{
            //    5,
            //    6
            //};
            //moveSomething.MovePiece(g8, e6ToF4);
            ////31
            //int[] e3ToC5 = new int[]
            //{
            //    4,
            //    3
            //};
            //moveSomething.MovePiece(d1, e3ToC5);
            ////32
            //int[] g5ToG4 = new int[]
            //{
            //    5,
            //    7
            //};
            //moveSomething.MovePiece(g7, g5ToG4);
            ////33
            //int[] h3ToG4 = new int[]
            //{
            //    5,
            //    7
            //};
            //moveSomething.MovePiece(h2, h3ToG4);
            ////34
            //Piece c8 = Game.ElementAt(0).ElementAt(2).Value;
            //int[] c8ToG4 = new int[]
            //{
            //    5,
            //    7
            //};
            //moveSomething.MovePiece(c8, c8ToG4);
            ////35
            //int[] f3ToD2 = new int[]
            //{
            //    7,
            //    4
            //};
            //moveSomething.MovePiece(g1, f3ToD2);
            ////36
            //Piece h7 = Game.ElementAt(1).ElementAt(7).Value;
            //int[] h7ToH5 = new int[]
            //{
            //    4,
            //    8
            //};
            //moveSomething.MovePiece(h7, h7ToH5);
            ////37
            //int[] d2ToC4 = new int[]
            //{
            //    5,
            //    3
            //};
            //moveSomething.MovePiece(g1, d2ToC4);
            ////38
            //int[] h5ToH4 = new int[]
            //{
            //    5,
            //    8
            //};
            //moveSomething.MovePiece(h7, h5ToH4);
            ////39
            //int[] c4ToD6 = new int[]
            //{
            //    3,
            //    4
            //};
            //moveSomething.MovePiece(g1, c4ToD6);
            ////40
            //Piece e8 = Game.ElementAt(0).ElementAt(4).Value;
            //int[] e8ToD8 = new int[]
            //{
            //    1,
            //    4
            //};
            //moveSomething.MovePiece(e8, e8ToD8);
            ////41
            //int[] d6ToB7 = new int[]
            //{
            //    2,
            //    2
            //};
            //moveSomething.MovePiece(g1, d6ToB7);
            ////42
            //int[] d8ToC7 = new int[]
            //{
            //    2,
            //    3
            //};
            //moveSomething.MovePiece(e8, d8ToC7);
            ////43
            //int[] b7ToA5 = new int[]
            //{
            //    4,
            //    1
            //};
            //moveSomething.MovePiece(g1, b7ToA5);
            ////44
            //int[] g4ToD7 = new int[]
            //{
            //    2,
            //    4
            //};
            //moveSomething.MovePiece(c8, g4ToD7);
            ////45
            //int[] c5ToE3 = new int[]
            //{
            //    6,
            //    5
            //};
            //moveSomething.MovePiece(d1, c5ToE3);
            ////46
            //int[] h4ToH3 = new int[]
            //{
            //    6,
            //    8
            //};
            //moveSomething.MovePiece(h7, h4ToH3);
            ////47
            //Piece g2 = Game.ElementAt(6).ElementAt(6).Value;
            //int[] g2ToH3 = new int[]
            //{
            //    6,
            //    8
            //};
            //moveSomething.MovePiece(g2, g2ToH3);
            ////48
            //int[] f4ToH3 = new int[]
            //{
            //    6,
            //    8
            //};
            //moveSomething.MovePiece(g8, f4ToH3);
            ////CHECK AT THIS POINT
            ////49
            //int[] g1ToG2 = new int[]
            //{
            //    7,
            //    7
            //};
            //moveSomething.MovePiece(e1, g1ToG2);
            ////50
            //int[] h3ToF4 = new int[]
            //{
            //    5,
            //    6
            //};
            //moveSomething.MovePiece(g8, h3ToF4);
            ////51
            //int[] g2ToG1 = new int[]
            //{
            //    8,
            //    7
            //};
            //moveSomething.MovePiece(e1, g2ToG1);
            ////52
            //int[] f7ToH6 = new int[]
            //{
            //    3,
            //    8
            //};
            //moveSomething.MovePiece(d8, f7ToH6);
            ////52
            //Piece f1Castled = Game.ElementAt(7).ElementAt(5).Value;
            //int[] f1ToD1 = new int[]
            //{
            //    8,
            //    4
            //};
            //moveSomething.MovePiece(f1Castled, f1ToD1);
            ////53
            //int[] h6ToH2 = new int[]
            //{
            //    7,
            //    8
            //};
            //moveSomething.MovePiece(d8, h6ToH2);
            ////54
            //int[] g1ToF1 = new int[]
            //{
            //    8,
            //    6
            //};
            //moveSomething.MovePiece(e1, g1ToF1);
            ////55
            //int[] h2ToH1 = new int[]
            //{
            //    8,
            //    8
            //};
            //moveSomething.MovePiece(d8, h2ToH1);
            ////56
            //int[] g3ToH1 = new int[]
            //{
            //    8,
            //    8
            //};
            //moveSomething.MovePiece(b1, g3ToH1);
            ////57
            //Piece h8 = Game.ElementAt(0).ElementAt(7).Value;
            //int[] h8ToH1 = new int[]
            //{
            //    8,
            //    8
            //};
            ////CHECKMATE
            //moveSomething.MovePiece(h8, h8ToH1);
            ////CHECKMATE
        }
    }
}

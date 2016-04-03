using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Board
    {
        public List<Dictionary<string, Piece>> board;
        public Dictionary<string, Piece> one;
        public Dictionary<string, Piece> two;
        public Dictionary<string, Piece> three;
        public Dictionary<string, Piece> four;
        public Dictionary<string, Piece> five;
        public Dictionary<string, Piece> six;
        public Dictionary<string, Piece> seven;
        public Dictionary<string, Piece> eight;
        public Rook bRook1;
        public Rook bRook2;
        public Knight bKnight1;
        public Knight bKnight2;
        public Bishop bBishop1;
        public Bishop bBishop2;
        public King bKing;
        public Queen bQueen;
        public Pawn bPawn1;
        public Pawn bPawn2;
        public Pawn bPawn3;
        public Pawn bPawn4;
        public Pawn bPawn5;
        public Pawn bPawn6;
        public Pawn bPawn7;
        public Pawn bPawn8;
        public Rook wRook1;
        public Rook wRook2;
        public Knight wKnight1;
        public Knight wKnight2;
        public Bishop wBishop1;
        public Bishop wBishop2;
        public King wKing;
        public Queen wQueen;
        public Pawn wPawn1;
        public Pawn wPawn2;
        public Pawn wPawn3;
        public Pawn wPawn4;
        public Pawn wPawn5;
        public Pawn wPawn6;
        public Pawn wPawn7;
        public Pawn wPawn8;

        public Board()
        {
            
            board = new List<Dictionary<string, Piece>>
            {
                {
                    one = new Dictionary<string, Piece>
                    {
                        {"A", bRook1 = new Rook()},
                        {"B", bKnight1 = new Knight()},
                        {"C", bBishop1 = new Bishop()},
                        {"D", bKing = new King()},
                        {"E", bQueen = new Queen()},
                        {"F", bBishop2 = new Bishop()},
                        {"G", bKnight2 = new Knight()},
                        {"H", bRook2 = new Rook()}
                    }
                },
                {
                    two = new Dictionary<string, Piece>
                    {
                        {"A", bPawn1 = new Pawn()},
                        {"B", bPawn2 = new Pawn()},
                        {"C", bPawn3 = new Pawn()},
                        {"D", bPawn4 = new Pawn()},
                        {"E", bPawn5 = new Pawn()},
                        {"F", bPawn6 = new Pawn()},
                        {"G", bPawn7 = new Pawn()},
                        {"H", bPawn8 = new Pawn()}
                    }
                },
                {
                    three = new Dictionary<string, Piece>
                    {
                        {"A", null},
                        {"B", null},
                        {"C", null},
                        {"D", null},
                        {"E", null},
                        {"F", null},
                        {"G", null},
                        {"H", null},
                    }
                },
                {
                    four = new Dictionary<string, Piece>
                    {
                        {"A", null},
                        {"B", null},
                        {"C", null},
                        {"D", null},
                        {"E", null},
                        {"F", null},
                        {"G", null},
                        {"H", null},
                    }
                },
                {
                    five = new Dictionary<string, Piece>
                    {
                        {"A", null},
                        {"B", null},
                        {"C", null},
                        {"D", null},
                        {"E", null},
                        {"F", null},
                        {"G", null},
                        {"H", null},
                    }
                },
                {
                    six = new Dictionary<string, Piece>
                    {
                        {"A", null},
                        {"B", null},
                        {"C", null},
                        {"D", null},
                        {"E", null},
                        {"F", null},
                        {"G", null},
                        {"H", null},
                    }
                },
                {
                    seven = new Dictionary<string, Piece>
                    {
                        {"A", wPawn1 = new Pawn()},
                        {"B", wPawn2 = new Pawn()},
                        {"C", wPawn3 = new Pawn()},
                        {"D", wPawn4 = new Pawn()},
                        {"E", wPawn5 = new Pawn()},
                        {"F", wPawn6 = new Pawn()},
                        {"G", wPawn7 = new Pawn()},
                        {"H", wPawn8 = new Pawn()}
                    }
                },
                {
                    eight = new Dictionary<string, Piece>
                    {
                        {"A", wRook1 = new Rook()},
                        {"B", wKnight1 = new Knight()},
                        {"C", wBishop1 = new Bishop()},
                        {"D", wKing = new King()},
                        {"E", wQueen = new Queen()},
                        {"F", wBishop2 = new Bishop()},
                        {"G", wKnight2 = new Knight()},
                        {"H", wRook2 = new Rook()}
                    }
                }
            };            
        }
        ////KeyValuePair<string, int> yaTesting;
        //public int[][] board;

        //public Board()
        //{
        //    board = new int[8][];

        //    board[0] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[1] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[2] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[3] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[4] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[5] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[6] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[7] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //}
        ////board.GetValue(0, 7);
    }
}


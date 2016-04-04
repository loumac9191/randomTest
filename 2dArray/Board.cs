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
        public List<SortedDictionary<string, Piece>> board;
        public SortedDictionary<string, Piece> one;
        public SortedDictionary<string, Piece> two;
        public SortedDictionary<string, Piece> three;
        public SortedDictionary<string, Piece> four;
        public SortedDictionary<string, Piece> five;
        public SortedDictionary<string, Piece> six;
        public SortedDictionary<string, Piece> seven;
        public SortedDictionary<string, Piece> eight;
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
            
            board = new List<SortedDictionary<string, Piece>>
            {
                {
                    one = new SortedDictionary<string, Piece>
                    {
                        {"A", bRook1 = new Rook
                            {
                                Colour = "Black"
                            }
                        },
                        {"B", bKnight1 = new Knight
                            {
                                Colour = "Black"
                            }
                        },
                        {"C", bBishop1 = new Bishop
                            {
                                Colour = "Black"
                            }
                        },
                        {"D", bKing = new King
                            {
                                Colour = "Black"
                            }
                        },
                        {"E", bQueen = new Queen
                            {
                                Colour = "Black"
                            }
                        },
                        {"F", bBishop2 = new Bishop
                            {
                                Colour = "Black"
                            }
                        },
                        {"G", bKnight2 = new Knight
                            {
                                Colour = "Black"
                            }
                        },
                        {"H", bRook2 = new Rook
                            {
                                Colour = "Black"
                            }
                        }
                    }
                },
                {
                    two = new SortedDictionary<string, Piece>
                    {
                        {"A", bPawn1 = new Pawn
                            {
                                Colour = "Black"
                            }
                        },
                        {"B", bPawn2 = new Pawn
                            {
                                Colour = "Black"
                            }
                        },
                        {"C", bPawn3 = new Pawn
                            {
                                Colour = "Black"
                            }
                        },
                        {"D", bPawn4 = new Pawn
                            {
                                Colour = "Black"
                            }
                        },
                        {"E", bPawn5 = new Pawn
                            {
                                Colour = "Black"
                            }
                        },
                        {"F", bPawn6 = new Pawn
                            {
                                Colour = "Black"
                            }
                        },
                        {"G", bPawn7 = new Pawn
                            {
                                Colour = "Black"
                            }
                        },
                        {"H", bPawn8 = new Pawn
                            {
                                Colour = "Black"
                            }
                        }
                    }
                },
                {
                    three = new SortedDictionary<string, Piece>
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
                    four = new SortedDictionary<string, Piece>
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
                    five = new SortedDictionary<string, Piece>
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
                    six = new SortedDictionary<string, Piece>
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
                    seven = new SortedDictionary<string, Piece>
                    {
                        {"A", wPawn1 = new Pawn
                            {
                                Colour = "White"
                            }
                        },
                        {"B", wPawn2 = new Pawn
                            {
                                Colour = "White"
                            }
                        },
                        {"C", wPawn3 = new Pawn
                            {
                                Colour = "White"
                            }
                        },
                        {"D", wPawn4 = new Pawn
                            {
                                Colour = "White"
                            }
                        },
                        {"E", wPawn5 = new Pawn
                            {
                                Colour = "White"
                            }
                        },
                        {"F", wPawn6 = new Pawn
                            {
                                Colour = "White"
                            }
                        },
                        {"G", wPawn7 = new Pawn
                            {
                                Colour = "White"
                            }
                        },
                        {"H", wPawn8 = new Pawn
                            {
                                Colour = "White"
                            }
                        }
                    }
                },
                {
                    eight = new SortedDictionary<string, Piece>
                    {
                        {"A", wRook1 = new Rook
                            {
                                Colour = "White"
                            }
                        },
                        {"B", wKnight1 = new Knight
                            {
                                Colour = "White"
                            }
                        },
                        {"C", wBishop1 = new Bishop
                            {
                                Colour = "White"
                            }
                        },
                        {"D", wKing = new King
                            {
                                Colour = "White"
                            }
                        },
                        {"E", wQueen = new Queen
                            {
                                Colour = "White"
                            }
                        },
                        {"F", wBishop2 = new Bishop
                            {
                                Colour = "White"
                            }
                        },
                        {"G", wKnight2 = new Knight
                            {
                                Colour = "White"
                            }
                        },
                        {"H", wRook2 = new Rook
                            {
                                Colour = "White"
                            }
                        }
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


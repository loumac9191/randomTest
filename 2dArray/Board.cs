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
        private SortedDictionary<string, Piece> eight;
        private SortedDictionary<string, Piece> seven;
        private SortedDictionary<string, Piece> six;
        private SortedDictionary<string, Piece> five;
        private SortedDictionary<string, Piece> four;
        private SortedDictionary<string, Piece> three;
        private SortedDictionary<string, Piece> two;
        private SortedDictionary<string, Piece> one;
        private Rook bRook1;
        private Rook bRook2;
        private Knight bKnight1;
        private Knight bKnight2;
        private Bishop bBishop1;
        private Bishop bBishop2;
        private King bKing;
        private Queen bQueen;
        private Pawn bPawn1;
        private Pawn bPawn2;
        private Pawn bPawn3;
        private Pawn bPawn4;
        private Pawn bPawn5;
        private Pawn bPawn6;
        private Pawn bPawn7;
        private Pawn bPawn8;
        private Rook wRook1;
        private Rook wRook2;
        private Knight wKnight1;
        private Knight wKnight2;
        private Bishop wBishop1;
        private Bishop wBishop2;
        private King wKing;
        private Queen wQueen;
        private Pawn wPawn1;
        private Pawn wPawn2;
        private Pawn wPawn3;
        private Pawn wPawn4;
        private Pawn wPawn5;
        private Pawn wPawn6;
        private Pawn wPawn7;
        private Pawn wPawn8;

        public Board()
        {

            board = new List<SortedDictionary<string, Piece>>
            {
                {
                    eight = new SortedDictionary<string, Piece>
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
                    seven = new SortedDictionary<string, Piece>
                    {
                        {"A", bPawn1 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        },
                        {"B", bPawn2 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        },
                        {"C", bPawn3 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        },
                        {"D", bPawn4 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        },
                        {"E", bPawn5 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        },
                        {"F", bPawn6 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        },
                        {"G", bPawn7 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        },
                        {"H", bPawn8 = new Pawn
                            {
                                Colour = "Black",
                                FirstMove = true
                            }
                        }
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
                    two = new SortedDictionary<string, Piece>
                    {
                        {"A", wPawn1 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        },
                        {"B", wPawn2 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        },
                        {"C", wPawn3 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        },
                        {"D", wPawn4 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        },
                        {"E", wPawn5 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        },
                        {"F", wPawn6 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        },
                        {"G", wPawn7 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        },
                        {"H", wPawn8 = new Pawn
                            {
                                Colour = "White",
                                FirstMove = true
                            }
                        }
                    }
                },
                {
                    one = new SortedDictionary<string, Piece>
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
    }
}


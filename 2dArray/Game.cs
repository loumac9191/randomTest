﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Game
    {
        public Board _board;
        public Mover mover;
        private bool PlayerWin;
        public int xHorizontalBorder;
        public int yVerticalBorder;
        public Player _playerOne;
        public Player _playerTwo;
        private int[] coOrds;
        public List<Piece> listOfRemovedPieces;

        public Game(Board Board, Player PlayerOne, Player PlayerTwo)
        {
            _board = Board;
            _playerOne = PlayerOne;
            _playerTwo = PlayerTwo;
            mover = new Mover(this);
            //moveEval = new MoveEvaluator(this);
            PlayerWin = false;
            xHorizontalBorder = _board.board.ElementAt(0).Count();
            yVerticalBorder = _board.board.Count();
            listOfRemovedPieces = new List<Piece>();

            //Load all Black pieces to playerOne, load all White pieces to playerTwo
            foreach (var rowOfPieces in _board.board)
            {
                foreach (var piece in rowOfPieces)
                {
                    if (piece.Value == null)
                    {
                        continue;
                    }
                    else if (piece.Value.Colour == "Black")
                    {
                        piece.Value.Owner = "Player One";

                        switch (piece.Value.InherentValue)
                        {
                            case 1:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerOne.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()),"Pawn");
                                break;
                            case 2:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerOne.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Rook");
                                break;
                            case 3:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerOne.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Knight");
                                break;
                            case 4:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerOne.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Bishop");
                                break;
                            case 5:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerOne.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "King");
                                break;
                            case 6:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerOne.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Queen");
                                break;
                        }                     
                    }
                    else
                    {
                        piece.Value.Owner = "Player Two";

                        switch (piece.Value.InherentValue)
                        {
                            case 1:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerTwo.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Pawn");
                                break;
                            case 2:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerTwo.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Rook");
                                break;
                            case 3:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerTwo.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Knight");
                                break;
                            case 4:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerTwo.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Bishop");
                                break;
                            case 5:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerTwo.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "King");
                                break;
                            case 6:
                                coOrds = mover.ProvidePosition(piece.Value);
                                _playerTwo.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()), "Queen");
                                break;
                        }
                    }
                }
            }
            //Games must have some rules
            //No piece must be able to go
            //while (PlayerOne.PlayerWin == false ||
            //          PlayerTwo.PlayerWin == false)
            //{

            //}
        }

        public string Announcer(string MessageToAnnounce)
        {
            return MessageToAnnounce;
        }
    }
}

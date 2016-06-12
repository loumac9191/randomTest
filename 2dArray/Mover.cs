﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Mover : IPlayable
    {
        private Game _currentGame;
        private Converter _converter = new Converter();
        private BoardEvaluator boardEval;
        private Piece _pieceToMove;
        public SortedDictionary<string, Piece> piecesClaimed;
        //Also in Move Evaluator
        private SortedDictionary<string, Piece> pieceContainedIn;
        private int[] _moveToCoOrdinates = new int[2];
        //Move Evaluator
        //**CHANGED TO DECLARED IN THE MOVEPIECE METHOD**
        //private int currentXAxis;
        //Move Evaluator
        private int currentYAxis;
        private string coOrdAsCharacter;
        private string incumbentKey;
        private MoveEvaluator moveEval;
        private int yAxisBeforeCorrection;
        private int[] yx;
        private bool _canMove;

        public Mover(Game CurrentGame)
        {
            _currentGame = CurrentGame;
            moveEval = new MoveEvaluator(CurrentGame, this);
            boardEval = new BoardEvaluator(CurrentGame, moveEval);
            piecesClaimed = new SortedDictionary<string, Piece>();
        }

        //DON'T THINK THIS NEEDS TO BE GIVEN THE CURRENT GAME AGAIN
        public void MovePiece(Piece PieceToMove, int[] MoveToCoOrdinates)
        {
            _pieceToMove = PieceToMove;
            //When coOrdinates are given by the player it will be numbered 1-8, this WONT factor in zero indexing, therefore -1 on yValues
            //i.e I want to move x to 4, A; this would be 3, 0 in index
            _moveToCoOrdinates = MoveToCoOrdinates;
            yAxisBeforeCorrection = _moveToCoOrdinates[0];
            _moveToCoOrdinates[0] -= 1;
            _moveToCoOrdinates[1] -= 1;          

            //Current Location Variables
            int currentXAxis = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove)).Values.ToList().IndexOf(_pieceToMove);
            pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove));
            currentYAxis = _currentGame._board.board.IndexOf(pieceContainedIn);
            coOrdAsCharacter = _converter.ConvertXAxis(currentXAxis);
            incumbentKey = _converter.ConvertXAxis(_moveToCoOrdinates[1]);

            if (yAxisBeforeCorrection > _currentGame.yVerticalBorder ||
                _moveToCoOrdinates[1] > _currentGame.xHorizontalBorder)
            {
                //Need to tell the game that the move wasn't valid
                //Announcer class which talks to the game
            }
            //Perhaps this can be saved in a variable
            else if(!moveEval.MoveToDestinationPopulated(MoveToCoOrdinates))
            {
                if (moveEval.EvaluateMove(false, _pieceToMove,_moveToCoOrdinates))
                {
                    //Remove the pieceToMove from its current location
                    _currentGame._board.board.ElementAt(currentYAxis).Remove(_currentGame._board.board.ElementAt(currentYAxis).ElementAt(currentXAxis).Key);

                    //Rename the XAxis key (string)
                    RenameXAxis(currentXAxis, coOrdAsCharacter);

                    //Reorder
                    _currentGame._board.board.ElementAt(currentYAxis).OrderBy(x => x.Key);

                    //Remove the key from the pieces destination otherwise not unique
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Remove(incumbentKey);

                    //Move and Reorder
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Add(incumbentKey, _pieceToMove);
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).OrderBy(x => x.Key);

                    //bool checkMate = true
                    bool check = boardEval.Check(_pieceToMove);

                    //if (checkMate)
                    //{

                    //}
                    if (check)
                    {
                        Console.WriteLine("Wew Check");
                    }
                    //CheckMate
                }
            }
            else
            {
                if (moveEval.EvaluateMove(true, _pieceToMove, _moveToCoOrdinates))
                {
                    KeyValuePair<string, Piece> tempLocationForRemovedPiece = _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).ElementAt(_moveToCoOrdinates[1]);
                    //Remove the pieceToMove from its current location
                    _currentGame._board.board.ElementAt(currentYAxis).Remove(_currentGame._board.board.ElementAt(currentYAxis).ElementAt(currentXAxis).Key);

                    //Rename the XAxis key (string)
                    RenameXAxis(currentXAxis, coOrdAsCharacter);

                    //Reorder
                    _currentGame._board.board.ElementAt(currentYAxis).OrderBy(x => x.Key);

                    //Remove the key from the pieces destination otherwise not unique
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Remove(incumbentKey);

                    ////Remove the piece from the destination and place this in the games removed list?
                    //KeyValuePair<string, Piece> kvpForPieceRemoved = _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).ElementAt(_moveToCoOrdinates[1]);

                    //_currentGame.listOfRemovedPieces.Add(kvpForPieceRemoved.Value);

                    //Move and Reorder
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Add(incumbentKey, _pieceToMove);
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).OrderBy(x => x.Key);

                    //bool checkMate = true
                    bool check = boardEval.Check(_pieceToMove);

                    //if (checkMate)
                    //{

                    //}
                    if (check)
                    {
                        Console.WriteLine("Wew Check");
                    }
                    //CheckMate
                }
            }
        }

        public int[] ProvidePosition(Piece PositionOfPieceInQuery)
        {
            return yx = moveEval.GetPosition(PositionOfPieceInQuery);
        }

        private void RenameXAxis(int currentXAxis, string coOrdAsCharacterForRename)
        {
            switch (currentXAxis)
            {
                case 0:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 1:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 2:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 3:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 4:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 5:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 6:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 7:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
            };
        }

        public void MoveRookForCastling(int[] CoOrdinatesForMove, Rook RookToMove)
        {
            SortedDictionary<string,Piece> rookContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(RookToMove));
            int currentYAxisOfRook = _currentGame._board.board.IndexOf(rookContainedIn);
            int currentXAxisOfRook = _currentGame._board.board.Find(x => x.ContainsValue(RookToMove)).Values.ToList().IndexOf(RookToMove);
            string CoordsOfRookAsString = _converter.ConvertXAxis(currentXAxisOfRook);
            string incumbentKeyOfRook = _converter.ConvertXAxis(CoOrdinatesForMove[1]);


            //Remove the pieceToMove from its current location
            _currentGame._board.board.ElementAt(currentYAxisOfRook).Remove(_currentGame._board.board.ElementAt(currentYAxisOfRook).ElementAt(currentXAxisOfRook).Key);

            //Rename the XAxis key (string)
            RenameXAxis(currentXAxisOfRook, CoordsOfRookAsString);

            //Reorder
            _currentGame._board.board.ElementAt(currentYAxisOfRook).OrderBy(x => x.Key);

            //Remove the key from the pieces destination otherwise not unique
            _currentGame._board.board.ElementAt(CoOrdinatesForMove[0]).Remove(incumbentKeyOfRook);

            //Move and Reorder
            _currentGame._board.board.ElementAt(CoOrdinatesForMove[0]).Add(incumbentKeyOfRook, RookToMove);
            _currentGame._board.board.ElementAt(CoOrdinatesForMove[0]).OrderBy(x => x.Key);
        }

        public void RemovePawnForEnPassant(Pawn PawnToRemove, int[] PositionOfPawn)
        {
            string CoordsOfPawnAsString = _converter.ConvertXAxis(PositionOfPawn[1]);
            _currentGame._board.board.ElementAt(PositionOfPawn[0]).Remove(_currentGame._board.board.ElementAt(PositionOfPawn[0]).ElementAt(PositionOfPawn[1]).Key);
            RenameXAxis(PositionOfPawn[1], CoordsOfPawnAsString);
            _currentGame._board.board.ElementAt(PositionOfPawn[0]).OrderBy(x => x.Key);
        }

        //private void Check(Piece PieceToMove)
        //{
        //    bool check = boardEval.Check(_pieceToMove);

        //    if (check)
        //    {
        //        Console.WriteLine("Wew Check");
        //    }
        //}
    }
}

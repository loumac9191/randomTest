﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    //ADDITIONAL MOVES TO RESEARCH
    //PAWNS:
    //EN PASSENT
    //PROMOTION
    //KING:
    //CASTLING
    //**NO PIECE CAN MOVE OVER ANOTHER PIECE**
    public class MoveEvaluator
    {
        private bool _populated;
        private Game _currentGame;
        private SortedDictionary<string, Piece> pieceContainedIn;
        private Piece _pieceToEval;
        private int[] _moveToCoOrds;
        private int[] _currentPosition;
        private int[] positionResolved;
        private int[] moveToMethodStore;

        public MoveEvaluator(Game CurrentGame)
        {
            _currentGame = CurrentGame;
            positionResolved = new int[2];
        }

        public bool EvaluateMove(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        {
            //dont think need canmove
            _pieceToEval = PieceToEval;
            _moveToCoOrds = MoveToCoOrds;
            _populated = Populated;


            switch (_pieceToEval.InherentValue)
            {
                case 1:
                    _currentPosition = GetPosition(_pieceToEval);
                    //Is it the same as the starting position? Don't move
                    if (_currentPosition[0] == _moveToCoOrds[0] &&
                        _currentPosition[1] == _moveToCoOrds[1])
                    {
                        break;
                    }
                    //PAWN MOVE LOGIC
                    Pawn pawnToCheck = _pieceToEval as Pawn;
                    //Is the property FirstMove set to true or false?
                    if (pawnToCheck.FirstMove == true)
                    {
                        if (_populated == true)
                        {
                            if (((_currentPosition[0] - 1) == _moveToCoOrds[0] || (_currentPosition[0] + 1) == _moveToCoOrds[0]) &&
                                (_currentPosition[1] == _moveToCoOrds[1]))
                            {
                                return true;
                            }
                            break;
                        }
                        else if (((_currentPosition[0] - 2) == _moveToCoOrds[0] || (_currentPosition[0] + 2) == _moveToCoOrds[0] || (_currentPosition[0] + 1) == _moveToCoOrds[0] || (_currentPosition[0] - 1) == _moveToCoOrds[0]) &&
                            (_currentPosition[1] == _moveToCoOrds[1]))
                        {
                            return true;
                        }
                        break;
                    }                    
                    //If desination is populated
                    else if (_populated == true)
                    {
                        //Then check if the move is legal
                        if (((_currentPosition[0] - 1) == _moveToCoOrds[0] || (_currentPosition[0] + 1) == _moveToCoOrds[0]) &&
                            ((_currentPosition[1] - 1) == _moveToCoOrds[1] || (_currentPosition[1] + 1) == _moveToCoOrds[1]))
                        {
                            return true;
                        }
                        break;
                    }
                    else if (((_currentPosition[0] -1) == _moveToCoOrds[0] || (_currentPosition[0] +1) == _moveToCoOrds[0]) &&
                        ((_currentPosition[1] -1) == _moveToCoOrds[1] || (_currentPosition[1] +1) == _moveToCoOrds[1]))
                    {
                        return true;
                    }
                    break;                  
                case 2:
                    _currentPosition = GetPosition(_pieceToEval);
                    //Is it the same as the starting position? Don't move
                    if (_currentPosition[0] == _moveToCoOrds[0] &&
                        _currentPosition[1] == _moveToCoOrds[1])
                    {
                        break;
                    }
                    //ROOK MOVE LOGIC
                    //Need to check that the destination is not obstructed by other pieces
                    //Vertical
                    if ((_moveToCoOrds[0] > _currentPosition[0] || _moveToCoOrds[0] < _currentPosition[0]) &&
                        _moveToCoOrds[1] == _currentPosition[1])
                    {
                        //Up - **NEED TO CHECK IF THIS WORKS**
                        if (_moveToCoOrds[0] < _currentPosition[0])
                        {
                            int iterate = _moveToCoOrds[0] + _currentPosition[0] - 8;
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = _currentPosition[0] - i; 
                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[1]).Value != null)
                                {
                                    //Define the new YAxis that the piece can move to
                                    _moveToCoOrds[0] = positionTemp + 1;
                                    //If this is the same as current position, don't move
                                    if (_moveToCoOrds[0] == _currentPosition[0])
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        //NEW METHOD THAT RETURNS UPDATED
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        //Down
                        else
                        {
                            int iterate = _moveToCoOrds[0] - _currentPosition[0];
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = _currentPosition[0] + i;
                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[1]).Value != null)
                                {
                                    _moveToCoOrds[0] = positionTemp - 1;
                                    if (_moveToCoOrds[0] == _currentPosition[0])
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        //NEW METHOD THAT RETURNS UPDATED
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    //Horizontal
                    else
                    {

                    }


                    break;
                case 3:
                    //knight
                    break;
                case 4:
                    //bishop
                    break;
                case 5:
                    //king
                    break;
                case 6:
                    //queen
                    break;
            }

            return false;
        }

        public bool MoveToDestinationPopulated(int[] CoOrdinatesOfPositionToQuery)
        {
            //Check if Destination is populated
            if(_currentGame._board.board.ElementAt(CoOrdinatesOfPositionToQuery[0]).ElementAt(CoOrdinatesOfPositionToQuery[1]).Value != null)
            {
                return true;
            }
            return false;
        }

        public bool EvaluateRange()
        {
            if (true)
            {

            }
            return true;
        }

        public bool EvaluateDirection()
        {
            return true;
        }

        public int[] GetPosition(Piece PieceToQuery)
        {
            //Find the list that contains the piece
            pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(PieceToQuery));
            //Populate the array
            positionResolved[0] = _currentGame._board.board.IndexOf(pieceContainedIn);
            positionResolved[1] = _currentGame._board.board.Find(x => x.ContainsValue(PieceToQuery)).Values.ToList().IndexOf(PieceToQuery);


            //Refactored
            //int xAxisResolved;
            //int yAxisResolved;
            //positionResolved = new int[]
            //{
            //    yAxisResolved = _currentGame._board.board.IndexOf(pieceContainedIn),
            //    xAxisResolved = _currentGame._board.board.Find(x => x.ContainsValue(PieceToQuery)).Values.ToList().IndexOf(PieceToQuery)
            //};
            return positionResolved;
        }

        public void MoveToCorrection(int[] CorrectionToSendToMover)
        {
            //Send corrected coordinates to Mover to update where the piece can legally move to
        }
    }
}

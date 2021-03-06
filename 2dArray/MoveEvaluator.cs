﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class MoveEvaluator
    {
        private Game _currentGame;
        private BoardEvaluator _boardEval;
        private Mover _mover;

        public MoveEvaluator(Game CurrentGame, Mover Mover)
        {
            _mover = Mover;
            _currentGame = CurrentGame;
            _boardEval = new BoardEvaluator(_currentGame, this);
        }

        public bool EvaluateMove(bool Populated, Piece PieceToEval, int[] MoveToCoOrds, bool Simulation = false, bool CastlingCheck = false)
        {
            //**
            List<SortedDictionary<string, Piece>> CurrentBoard = _currentGame._board.board;
            //**
            int[] CurrentPosition = GetPosition(PieceToEval);
            //Is it the same as the starting position? Don't move
            if (CurrentPosition[0] == MoveToCoOrds[0] &&
                CurrentPosition[1] == MoveToCoOrds[1])
            {
                return false;
            }

            switch (PieceToEval.InherentValue)
            {
                case 1:
                    Pawn pawnToCheck = PieceToEval as Pawn;
                    if (pawnToCheck != null) { return PawnMoveLogic(CurrentPosition, Populated, pawnToCheck, MoveToCoOrds, Simulation); }
                    break;
                case 2:
                    return RookMoveLogic(CurrentPosition, Populated, PieceToEval, MoveToCoOrds, Simulation);
                case 3:
                    return KnightMoveLogic(CurrentPosition, Populated, PieceToEval, MoveToCoOrds, Simulation);
                case 4:
                    return BishopMoveLogic(CurrentPosition, Populated, PieceToEval, MoveToCoOrds, Simulation);
                case 5:
                    King kingToEval = PieceToEval as King;
                    if (kingToEval != null) { return KingMoveLogic(CurrentPosition, Populated, kingToEval, MoveToCoOrds, Simulation, CastlingCheck); }
                    break;
                case 6:
                    return QueenMoveLogic(CurrentPosition, Populated, PieceToEval, MoveToCoOrds, Simulation);
            }
            return false;
        }

        public bool MoveToDestinationPopulated(int[] CoOrdinatesOfPositionToQuery)
        {
            if (_currentGame._board.board.ElementAt(CoOrdinatesOfPositionToQuery[0]).ElementAt(CoOrdinatesOfPositionToQuery[1]).Value != null)
            {
                return true;
            }
            return false;
        }

        public int[] GetPosition(Piece PieceToQuery)
        {
            int[] positionResolved = new int[2];
            SortedDictionary<string, Piece> pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(PieceToQuery));
            positionResolved[0] = _currentGame._board.board.IndexOf(pieceContainedIn);
            positionResolved[1] = _currentGame._board.board.Find(x => x.ContainsValue(PieceToQuery)).Values.ToList().IndexOf(PieceToQuery);

            return positionResolved;
        }

        public void MoveRookForCastling(int[] CorrectionToSendToMover, Rook RookToMove, bool Simulation)
        {
            if (Simulation)
            {
                return;
            }
            _mover.MoveRookForCastling(CorrectionToSendToMover, RookToMove);
        }

        private void Promotion(Pawn PawnToMove, int[] MoveToCoOrds, int[] CurrentPosition)
        {
            //bool result = 
        }
  
        private bool PawnMoveLogic(int[] CurrentPosition, bool Populated, Pawn pawnToCheck, int[] MoveToCoOrds, bool Simulation)
        {
            List<SortedDictionary<string, Piece>> CurrentBoard = _currentGame._board.board;
            if (pawnToCheck.FirstMove == true)
            {
                if (pawnToCheck.Colour == "Black")
                {
                    //if (((MoveToCoOrds[0] - CurrentPosition[0]) == 1) &&
                    //    MoveToCoOrds[0] == 7)
                    //{
                    //    if (MoveToCoOrds[1] == CurrentPosition[1])
                    //    {
                    //        if (Populated)
                    //        {
                    //            //return false;
                    //        }
                    //        if (!Simulation)
                    //        {
                    //            ////Promotion
                    //            //Promotion(pawnToCheck, MoveToCoOrds, CurrentPosition);
                    //            //return true;
                    //        }
                    //    }
                    //    if ((MoveToCoOrds[1] == CurrentPosition[1] - 1) ||
                    //        (MoveToCoOrds[1] == CurrentPosition[1] + 1))
                    //    {
                    //        if (Populated && !Simulation)
                    //        {
                    //            if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                    //            {
                    //                ////Promotion
                    //                //Promotion(pawnToCheck, MoveToCoOrds, CurrentPosition);
                    //                //return true;
                    //            }
                    //        }
                    //        //return false;
                    //    }
                    //}
                    if (((CurrentPosition[0] + 1) == MoveToCoOrds[0] || (CurrentPosition[0] + 2) == MoveToCoOrds[0]) &&
                        CurrentPosition[1] == MoveToCoOrds[1])
                    {
                        if ((CurrentPosition[0] + 2) == MoveToCoOrds[0])
                        {
                            if (Populated)
                            {
                                return false;
                            }
                            else
                            {
                                if (Simulation)
                                {
                                    return true;
                                }
                                pawnToCheck.FirstMove = false;
                                pawnToCheck.FirstMoveWasTwoSquares = true;
                                return true;
                            }
                        }
                        else
                        {
                            if (Populated)
                            {
                                return false;
                            }
                            else
                            {
                                if (Simulation)
                                {
                                    return true;
                                }
                                pawnToCheck.FirstMove = false;
                                return true;
                            }
                        }
                    }
                    else if ((CurrentPosition[0] + 1) == MoveToCoOrds[0] &&
                    (((CurrentPosition[1] - 1) == MoveToCoOrds[1]) || (CurrentPosition[1] + 1) == MoveToCoOrds[1]))
                    {
                        //DONT NEED TO WORRY ABOUT SIMULATION HERE AS ONLY TIME SIMULATED IS WHEN IT IS POPULATED
                        if (Populated)
                        {
                            if (Simulation)
                            {
                                return true;
                            }
                            if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                            {
                                pawnToCheck.FirstMove = false;
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else if (pawnToCheck.Colour == "White")
                {
                    //if (((CurrentPosition[0] - MoveToCoOrds[0]) == 1) &&
                    //    MoveToCoOrds[0] == 0)
                    //{
                    //    if (MoveToCoOrds[1] == CurrentPosition[1])
                    //    {
                    //        if (Populated)
                    //        {
                    //            //return false;
                    //        }
                    //        if (!Simulation)
                    //        {
                    //            ////Promotion
                    //            //Promotion(pawnToCheck, MoveToCoOrds, CurrentPosition);
                    //            //return true;
                    //        }
                    //    }
                    //    if ((MoveToCoOrds[1] == CurrentPosition[1] - 1) ||
                    //        (MoveToCoOrds[1] == CurrentPosition[1] + 1))
                    //    {
                    //        if (Populated && !Simulation)
                    //        {
                    //            if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                    //            {
                    //                ////Promotion
                    //                //Promotion(pawnToCheck, MoveToCoOrds, CurrentPosition);
                    //                //return true;
                    //            }
                    //        }
                    //        //return false;
                    //    }
                    //}
                    if (((CurrentPosition[0] - 1) == MoveToCoOrds[0] || (CurrentPosition[0] - 2) == MoveToCoOrds[0]) &&
                        CurrentPosition[1] == MoveToCoOrds[1])
                    {
                        if ((CurrentPosition[0] - 2) == MoveToCoOrds[0])
                        {
                            if (Populated)
                            {
                                return false;
                            }
                            else
                            {
                                if (Simulation)
                                {
                                    return true;
                                }
                                pawnToCheck.FirstMove = false;
                                pawnToCheck.FirstMoveWasTwoSquares = true;
                                return true;
                            }
                        }
                        else
                        {
                            if (Populated)
                            {
                                return false;
                            }
                            else
                            {
                                if (Simulation)
                                {
                                    return true;
                                }
                                pawnToCheck.FirstMove = false;
                                return true;
                            }
                        }
                    }
                    else if (((CurrentPosition[1] - 1) == MoveToCoOrds[1] || (CurrentPosition[1] + 1) == MoveToCoOrds[1]) &&
                        (CurrentPosition[0] - 1) == MoveToCoOrds[0])
                    {
                        if (Populated)
                        {
                            if (Simulation)
                            {
                                return true;
                            }
                            if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                            {
                                pawnToCheck.FirstMove = false;
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            else
            {
                //Pawn must be moving forward 1 piece (dependent on colour) OR
                //Could be capturing another piece (moving diagonally)
                if (pawnToCheck.Colour == "Black")
                {
                    if ((CurrentPosition[0] + 1) == MoveToCoOrds[0])
                    {
                        if ((CurrentPosition[1] - 1) == MoveToCoOrds[1] || (CurrentPosition[1] + 1) == MoveToCoOrds[1])
                        {
                            if (Populated &&
                                CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                            {
                                if (pawnToCheck.FirstMoveWasTwoSquares &&
                                    !Simulation)
                                {
                                    pawnToCheck.FirstMoveWasTwoSquares = false;
                                }
                                return true;
                            }
                            else if (!Populated)
                            {
                                Pawn eligibleForEnPassant;
                                int[] positionOfEnPassantPawn;
                                if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(MoveToCoOrds[1]).Value != null &&
                                    CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(MoveToCoOrds[1]).Value.InherentValue == 1)
                                {
                                    eligibleForEnPassant = CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(MoveToCoOrds[1]).Value as Pawn;
                                    if (eligibleForEnPassant.FirstMoveWasTwoSquares &&
                                        !Simulation)
                                    {
                                        positionOfEnPassantPawn = GetPosition(eligibleForEnPassant);
                                        _mover.RemovePawnForEnPassant(eligibleForEnPassant, positionOfEnPassantPawn);
                                    }
                                }
                                if (pawnToCheck.FirstMoveWasTwoSquares &&
                                    !Simulation)
                                {
                                    pawnToCheck.FirstMoveWasTwoSquares = false;
                                }
                                return true;
                            }
                            return false;
                        }
                        else if (!Populated)
                        {
                            if (pawnToCheck.FirstMoveWasTwoSquares &&
                                !Simulation)
                            {
                                pawnToCheck.FirstMoveWasTwoSquares = false;
                                return true;
                            }
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (pawnToCheck.Colour == "White")
                {
                    if ((CurrentPosition[0] - 1) == MoveToCoOrds[0])
                    {
                        //Confirmed moving in correct direction
                        if ((CurrentPosition[1] - 1) == MoveToCoOrds[1] || (CurrentPosition[1] + 1) == MoveToCoOrds[1])
                        {
                            if (Populated &&
                                CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                            {
                                if (pawnToCheck.FirstMoveWasTwoSquares &&
                                    !Simulation)
                                {
                                    pawnToCheck.FirstMoveWasTwoSquares = false;
                                }
                                return true;
                            }
                            else if (!Populated)
                            {
                                Pawn eligibleForEnPassant;
                                int[] positionOfEnPassantPawn;
                                if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(MoveToCoOrds[1]).Value != null &&
                                    CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(MoveToCoOrds[1]).Value.InherentValue == 1)
                                {
                                    eligibleForEnPassant = CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(MoveToCoOrds[1]).Value as Pawn;
                                    if (eligibleForEnPassant.FirstMoveWasTwoSquares &&
                                        !Simulation)
                                    {
                                        positionOfEnPassantPawn = GetPosition(eligibleForEnPassant);
                                        _mover.RemovePawnForEnPassant(eligibleForEnPassant, positionOfEnPassantPawn);
                                    }
                                }
                                if (pawnToCheck.FirstMoveWasTwoSquares &&
                                    !Simulation)
                                {
                                    pawnToCheck.FirstMoveWasTwoSquares = false;
                                }
                                return true;
                            }
                            return false;
                        }
                        else if (!Populated)
                        {
                            if (pawnToCheck.FirstMoveWasTwoSquares &&
                                !Simulation)
                            {
                                pawnToCheck.FirstMoveWasTwoSquares = false;
                                return true;
                            }
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private bool RookMoveLogic(int[] CurrentPosition, bool Populated, Piece PieceToEval, int[] MoveToCoOrds, bool Simulation)
        {
            List<SortedDictionary<string, Piece>> CurrentBoard = _currentGame._board.board;
            if ((MoveToCoOrds[0] > CurrentPosition[0] || MoveToCoOrds[0] < CurrentPosition[0]) &&
                MoveToCoOrds[1] == CurrentPosition[1])
            {
                //Up
                if (MoveToCoOrds[0] < CurrentPosition[0])
                {
                    int iterate = CurrentPosition[0] - MoveToCoOrds[0];
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionTemp = CurrentPosition[0] - i;
                        //No piece can move over another, so if position is filled,
                        if (CurrentBoard.ElementAt(positionTemp).ElementAt(CurrentPosition[1]).Value != null)
                        {
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {

                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i == iterate)
                            {
                                return true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                //Down
                else if (MoveToCoOrds[0] > CurrentPosition[0])
                {
                    int iterate = MoveToCoOrds[0] - CurrentPosition[0];
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionTemp = CurrentPosition[0] + i;
                        if (CurrentBoard.ElementAt(positionTemp).ElementAt(CurrentPosition[1]).Value != null)
                        {
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i == iterate)
                            {
                                return true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            //Horizontal
            else
            {
                if ((MoveToCoOrds[1] > CurrentPosition[1] || MoveToCoOrds[1] < CurrentPosition[1]) &&
                    MoveToCoOrds[0] == CurrentPosition[0])
                {
                    //Right
                    if (MoveToCoOrds[1] > CurrentPosition[1])
                    {
                        int iterate = MoveToCoOrds[1] - CurrentPosition[1];
                        for (int i = 1; i <= iterate; i++)
                        {
                            int positionTemp = CurrentPosition[1] + i;
                            if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value != null)
                            {
                                if (i == iterate)
                                {
                                    if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (i == iterate)
                                {
                                    return true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    //Left
                    else
                    {
                        if (MoveToCoOrds[1] < CurrentPosition[1])
                        {
                            int iterate = CurrentPosition[1] - MoveToCoOrds[1];
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = CurrentPosition[1] - i;
                                if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value != null)
                                {
                                    if (i == iterate)
                                    {
                                        if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (i == iterate)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool KnightMoveLogic(int[] CurrentPosition, bool Populated, Piece PieceToEval, int[] MoveToCoOrds, bool Simulation)
        {
            List<SortedDictionary<string, Piece>> CurrentBoard = _currentGame._board.board;
            if (((CurrentPosition[0] + 2) == MoveToCoOrds[0] && ((CurrentPosition[1] - 1) == MoveToCoOrds[1] || (CurrentPosition[1] + 1) == MoveToCoOrds[1])) ||
                ((CurrentPosition[0] - 2) == MoveToCoOrds[0] && ((CurrentPosition[1] - 1) == MoveToCoOrds[1] || (CurrentPosition[1] + 1) == MoveToCoOrds[1])) ||
                ((CurrentPosition[1] + 2) == MoveToCoOrds[1] && ((CurrentPosition[0] - 1) == MoveToCoOrds[0] || (CurrentPosition[0] + 1) == MoveToCoOrds[0])) ||
                ((CurrentPosition[1] - 2) == MoveToCoOrds[1] && ((CurrentPosition[0] - 1) == MoveToCoOrds[0] || (CurrentPosition[0] + 1) == MoveToCoOrds[0])))
            {
                if (Simulation && Populated)
                {
                    return true;
                }
                if (Populated)
                {
                    if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private bool BishopMoveLogic(int[] CurrentPosition, bool Populated, Piece PieceToEval, int[] MoveToCoOrds, bool Simulation)
        {
            List<SortedDictionary<string, Piece>> CurrentBoard = _currentGame._board.board;
            if (CurrentPosition[1] > MoveToCoOrds[1] && CurrentPosition[0] < MoveToCoOrds[0])
            {
                int iterate = CurrentPosition[1] - MoveToCoOrds[1];
                if (iterate == (MoveToCoOrds[0] - CurrentPosition[0]))
                {
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionXTemp = new int();
                        int positionYTemp = new int();
                        positionXTemp = (CurrentPosition[1] - i);
                        positionYTemp = (CurrentPosition[0] + i);
                        if (i == iterate)
                        {
                            if (Populated)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                            {
                                return false;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (CurrentPosition[0] > MoveToCoOrds[0] && CurrentPosition[1] > MoveToCoOrds[1])
            {
                //North West
                int iterate = CurrentPosition[0] - MoveToCoOrds[0];

                if (iterate == (CurrentPosition[1] - MoveToCoOrds[1]))
                {
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionXTemp = new int();
                        int positionYTemp = new int();
                        positionXTemp = (CurrentPosition[1] - i);
                        positionYTemp = (CurrentPosition[0] - i);
                        if (i == iterate)
                        {
                            if (Populated)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                            {
                                return false;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (CurrentPosition[1] < MoveToCoOrds[1] && CurrentPosition[0] > MoveToCoOrds[0])
            {
                //North East
                int iterate = MoveToCoOrds[1] - CurrentPosition[1];

                if (iterate == (CurrentPosition[0] - MoveToCoOrds[0]))
                {
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionXTemp = new int();
                        int positionYTemp = new int();
                        positionXTemp = (CurrentPosition[1] + i);
                        positionYTemp = (CurrentPosition[0] - i);
                        if (i == iterate)
                        {
                            if (Populated)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                            {
                                return false;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (CurrentPosition[0] < MoveToCoOrds[0] && CurrentPosition[1] < MoveToCoOrds[1])
            {
                //South East
                int iterate = (MoveToCoOrds[0] - CurrentPosition[0]);
                if (iterate == (MoveToCoOrds[1] - CurrentPosition[1]))
                {
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionXTemp = new int();
                        int positionYTemp = new int();
                        positionXTemp = (CurrentPosition[1] + i);
                        positionYTemp = (CurrentPosition[0] + i);
                        if (i == iterate)
                        {
                            if (Populated)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                            {
                                return false;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool KingMoveLogic(int[] CurrentPosition, bool Populated, King kingToEval, int[] MoveToCoOrds, bool Simulation, bool CastlingCheck)
        {
            List<SortedDictionary<string, Piece>> CurrentBoard = _currentGame._board.board;
            int[] c8 = new int[] { 0, 2 };
            int[] g8 = new int[] { 0, 6 };
            int[] c1 = new int[] { 7, 2 };
            int[] g1 = new int[] { 7, 6 };

            if (kingToEval.FirstMove && !CastlingCheck &&
                ((MoveToCoOrds[1] == c8[1] && MoveToCoOrds[0] == c8[0]) ||
                (MoveToCoOrds[0] == g8[0] && MoveToCoOrds[1] == g8[1]) ||
                (MoveToCoOrds[0] == c1[0] && MoveToCoOrds[1] == c1[1]) ||
                (MoveToCoOrds[0] == g1[0] && MoveToCoOrds[1] == g1[1])))
            {
                if ((MoveToCoOrds[1] == c8[1] && MoveToCoOrds[0] == c8[0]) ||
                    (MoveToCoOrds[0] == g8[0] && MoveToCoOrds[1] == g8[1]))
                {
                    if (CurrentPosition[1] > MoveToCoOrds[1])
                    {
                        //LEFT
                        if (CurrentBoard.ElementAt(0).ElementAt(0).Value != null &&
                            CurrentBoard.ElementAt(0).ElementAt(0).Value.InherentValue == 2)
                        {
                            Rook rookAtA8 = CurrentBoard.ElementAt(0).ElementAt(0).Value as Rook;
                            if (rookAtA8.FirstMove == true)
                            {
                                int[] positionOfRook = GetPosition(rookAtA8);
                                int iterate = CurrentPosition[1] - positionOfRook[1];
                                for (int i = 1; i <= iterate; i++)
                                {
                                    int positionTemp = new int();
                                    positionTemp = CurrentPosition[1] - i;
                                    if (i == iterate)
                                    {
                                        if (!_boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, CurrentPosition))
                                        {
                                            int[] positionOfRookCastled = new int[2] { 0, 2 };
                                            rookAtA8.FirstMove = false;
                                            kingToEval.FirstMove = false;
                                            MoveRookForCastling(positionOfRookCastled, rookAtA8, Simulation);
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value == null)
                                    {
                                        if (i <= 2)
                                        {
                                            int[] simulatePosition = new int[2] { CurrentPosition[0], positionTemp };
                                            if (!_boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                            {
                                                continue;
                                            }
                                            return false;
                                        }
                                        else
                                        {
                                            Simulation = false;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (CurrentPosition[1] < MoveToCoOrds[1])
                    {
                        //RIGHT
                        if (CurrentBoard.ElementAt(0).ElementAt(7).Value != null &&
                            CurrentBoard.ElementAt(0).ElementAt(7).Value.InherentValue == 2)
                        {
                            Rook rookAtH8 = CurrentBoard.ElementAt(0).ElementAt(7).Value as Rook;
                            if (rookAtH8.FirstMove == true)
                            {
                                int[] positionOfRook = GetPosition(rookAtH8);
                                int iterate = positionOfRook[1] - CurrentPosition[1];
                                for (int i = 1; i <= iterate; i++)
                                {
                                    int positionTemp = new int();
                                    positionTemp = CurrentPosition[1] + i;
                                    if (i == iterate)
                                    {
                                        if (!_boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, CurrentPosition))
                                        {
                                            int[] positionOfRookCastled = new int[2] { 0, 5 };
                                            rookAtH8.FirstMove = false;
                                            kingToEval.FirstMove = false;
                                            MoveRookForCastling(positionOfRookCastled, rookAtH8, Simulation);
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value == null)
                                    {
                                        if (i <= 2)
                                        {
                                            int[] simulatePosition = new int[2] { CurrentPosition[0], positionTemp };
                                            if (!_boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                            {
                                                continue;
                                            }
                                            return false;
                                        }
                                        else
                                        {
                                            Simulation = false;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((MoveToCoOrds[0] == c1[0] && MoveToCoOrds[1] == c1[1]) ||
                    (MoveToCoOrds[0] == g1[0] && MoveToCoOrds[1] == g1[1]))
                {
                    if (CurrentPosition[1] > MoveToCoOrds[1])
                    {
                        //LEFT
                        if (CurrentBoard.ElementAt(7).ElementAt(0).Value != null &&
                            CurrentBoard.ElementAt(7).ElementAt(0).Value.InherentValue == 2)
                        {
                            Rook rookAtC1 = CurrentBoard.ElementAt(7).ElementAt(0).Value as Rook;
                            if (rookAtC1.FirstMove == true)
                            {
                                int[] positionOfRook = GetPosition(rookAtC1);
                                int iterate = CurrentPosition[1] - positionOfRook[1];
                                for (int i = 1; i <= iterate; i++)
                                {
                                    int positionTemp = new int();
                                    positionTemp = CurrentPosition[1] - i;
                                    if (i == iterate)
                                    {
                                        if (!_boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, CurrentPosition))
                                        {
                                            int[] positionOfRookCastled = new int[2] { 7, 2 };
                                            rookAtC1.FirstMove = false;
                                            kingToEval.FirstMove = false;
                                            MoveRookForCastling(positionOfRookCastled, rookAtC1, Simulation);
                                            return true;
                                        }
                                    }
                                    else if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value == null)
                                    {
                                        if (i <= 2)
                                        {
                                            int[] simulatePosition = new int[2] { CurrentPosition[0], positionTemp };
                                            if (!_boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                            {
                                                continue;
                                            }
                                            return false;
                                        }
                                        else
                                        {
                                            Simulation = false;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (CurrentPosition[1] < MoveToCoOrds[1])
                    {
                        //RIGHT
                        if (CurrentBoard.ElementAt(7).ElementAt(7).Value != null &&
                            CurrentBoard.ElementAt(7).ElementAt(7).Value.InherentValue == 2)
                        {
                            Rook rookAtG1 = CurrentBoard.ElementAt(7).ElementAt(7).Value as Rook;
                            if (rookAtG1.FirstMove == true)
                            {
                                int[] positionOfRook = GetPosition(rookAtG1);
                                int iterate = positionOfRook[1] - CurrentPosition[1];
                                for (int i = 1; i <= iterate; i++)
                                {
                                    int positionTemp = new int();
                                    positionTemp = CurrentPosition[1] + i;
                                    if (i == iterate)
                                    {
                                        if (!_boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, CurrentPosition))
                                        {
                                            int[] positionOfRookCastled = new int[2] { 7, 5 };
                                            rookAtG1.FirstMove = false;
                                            kingToEval.FirstMove = false;
                                            MoveRookForCastling(positionOfRookCastled, rookAtG1, Simulation);
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value == null)
                                    {
                                        if (i <= 2)
                                        {
                                            int[] simulatePosition = new int[2] { CurrentPosition[0], positionTemp };
                                            if (!_boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                            {
                                                continue;
                                            }
                                            return false;
                                        }
                                        else
                                        {
                                            Simulation = false;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (((CurrentPosition[0] + 1) == MoveToCoOrds[0] && CurrentPosition[1] == MoveToCoOrds[1]) ||
                ((CurrentPosition[0] - 1) == MoveToCoOrds[0] && CurrentPosition[1] == MoveToCoOrds[1]) ||
                ((CurrentPosition[1] + 1) == MoveToCoOrds[1] && CurrentPosition[0] == MoveToCoOrds[0]) ||
                ((CurrentPosition[1] - 1) == MoveToCoOrds[1] && CurrentPosition[0] == MoveToCoOrds[0]) ||
                ((CurrentPosition[1] - 1) == MoveToCoOrds[1] && (CurrentPosition[0] + 1) == MoveToCoOrds[0]) ||
                ((CurrentPosition[0] - 1) == MoveToCoOrds[0] && (CurrentPosition[1] - 1) == MoveToCoOrds[1]) ||
                ((CurrentPosition[1] + 1) == MoveToCoOrds[1] && (CurrentPosition[0] - 1) == MoveToCoOrds[0]) ||
                ((CurrentPosition[0] + 1) == MoveToCoOrds[0] && (CurrentPosition[1] + 1) == MoveToCoOrds[1]))
            {
                if (Populated)
                {
                    if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == kingToEval.Colour)
                    {
                        return false;
                    }
                    else
                    {
                        if (!Simulation)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                else
                {
                    if (!Simulation)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        private bool QueenMoveLogic(int[] CurrentPosition, bool Populated, Piece PieceToEval, int[] MoveToCoOrds, bool Simulation)
        {
            List<SortedDictionary<string, Piece>> CurrentBoard = _currentGame._board.board;
            if ((MoveToCoOrds[0] > CurrentPosition[0] || MoveToCoOrds[0] < CurrentPosition[0]) &&
                        MoveToCoOrds[1] == CurrentPosition[1])
            {
                //Up
                if (MoveToCoOrds[0] < CurrentPosition[0])
                {
                    int iterate = CurrentPosition[0] - MoveToCoOrds[0];
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionTemp = CurrentPosition[0] - i;
                        //No piece can move over another, so if position is filled,
                        if (CurrentBoard.ElementAt(positionTemp).ElementAt(CurrentPosition[1]).Value != null)
                        {
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i == iterate)
                            {
                                return true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                //Down
                else if (MoveToCoOrds[0] > CurrentPosition[0])
                {
                    int iterate = MoveToCoOrds[0] - CurrentPosition[0];
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionTemp = CurrentPosition[0] + i;
                        if (CurrentBoard.ElementAt(positionTemp).ElementAt(CurrentPosition[1]).Value != null)
                        {
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i == iterate)
                            {
                                return true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            //Horizontal
            else if ((MoveToCoOrds[1] > CurrentPosition[1] || MoveToCoOrds[1] < CurrentPosition[1]) &&
                MoveToCoOrds[0] == CurrentPosition[0])
            {
                //Right
                if (MoveToCoOrds[1] > CurrentPosition[1])
                {
                    int iterate = MoveToCoOrds[1] - CurrentPosition[1];
                    for (int i = 1; i <= iterate; i++)
                    {
                        int positionTemp = CurrentPosition[1] + i;
                        if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value != null)
                        {
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value.Colour == PieceToEval.Colour)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i == iterate)
                            {
                                return true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                //Left
                else
                {
                    if (MoveToCoOrds[1] < CurrentPosition[1])
                    {
                        int iterate = CurrentPosition[1] - MoveToCoOrds[1];
                        for (int i = 1; i <= iterate; i++)
                        {
                            int positionTemp = CurrentPosition[1] - i;
                            if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value != null)
                            {
                                if (i == iterate)
                                {
                                    if (CurrentBoard.ElementAt(CurrentPosition[0]).ElementAt(positionTemp).Value.Colour == PieceToEval.Colour)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (i == iterate)
                                {
                                    return true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                //Diagonal
                if (CurrentPosition[1] > MoveToCoOrds[1] && CurrentPosition[0] < MoveToCoOrds[0])
                {
                    int iterate = CurrentPosition[1] - MoveToCoOrds[1];
                    if (iterate == (MoveToCoOrds[0] - CurrentPosition[0]))
                    {
                        for (int i = 1; i <= iterate; i++)
                        {
                            int positionXTemp = new int();
                            int positionYTemp = new int();
                            positionXTemp = (CurrentPosition[1] - i);
                            positionYTemp = (CurrentPosition[0] + i);
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    return false;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (CurrentPosition[0] > MoveToCoOrds[0] && CurrentPosition[1] > MoveToCoOrds[1])
                {
                    //North West
                    int iterate = CurrentPosition[0] - MoveToCoOrds[0];

                    if (iterate == (CurrentPosition[1] - MoveToCoOrds[1]))
                    {
                        for (int i = 1; i <= iterate; i++)
                        {
                            int positionXTemp = new int();
                            int positionYTemp = new int();
                            positionXTemp = (CurrentPosition[1] - i);
                            positionYTemp = (CurrentPosition[0] - i);
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    return false;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (CurrentPosition[1] < MoveToCoOrds[1] && CurrentPosition[0] > MoveToCoOrds[0])
                {
                    //North East
                    int iterate = MoveToCoOrds[1] - CurrentPosition[1];

                    if (iterate == (CurrentPosition[0] - MoveToCoOrds[0]))
                    {
                        for (int i = 1; i <= iterate; i++)
                        {
                            int positionXTemp = new int();
                            int positionYTemp = new int();
                            positionXTemp = (CurrentPosition[1] + i);
                            positionYTemp = (CurrentPosition[0] - i);
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    return false;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (CurrentPosition[0] < MoveToCoOrds[0] && CurrentPosition[1] < MoveToCoOrds[1])
                {
                    //South East
                    int iterate = (MoveToCoOrds[0] - CurrentPosition[0]);
                    if (iterate == (MoveToCoOrds[1] - CurrentPosition[1]))
                    {
                        for (int i = 1; i <= iterate; i++)
                        {
                            int positionXTemp = new int();
                            int positionYTemp = new int();
                            positionXTemp = (CurrentPosition[1] + i);
                            positionYTemp = (CurrentPosition[0] + i);
                            if (i == iterate)
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    if (CurrentBoard.ElementAt(MoveToCoOrds[0]).ElementAt(MoveToCoOrds[1]).Value.Colour == PieceToEval.Colour)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                if (CurrentBoard.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
                                {
                                    return false;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}

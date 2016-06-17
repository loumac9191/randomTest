﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class BoardEvaluator
    {
        Game _currentGame;
        King kingForCheck;
        List<Piece> listOfPiecesForCheck;
        List<Piece> listOfEnemyPlayersPiecesForCastling;
        MoveEvaluator moveEvaluator;
        int[] kingsPosition;
        //these two lists need resetting
        List<Tuple<Piece, int[]>> listOfPiecesForCheckMateWithCurrentPosition;
        List<Tuple<Piece, int[]>> listOfCheckPiecesThatCannotBeTaken;
        //Dictionary<Piece, List<int[]>> listOfCheckPiecesAndTheirPositionsToCheck;
        List<Piece> piecesThatCanStopCheck;

        public BoardEvaluator(Game currentGame, MoveEvaluator MoveEvaluator)
        {
            _currentGame = currentGame;
            moveEvaluator = MoveEvaluator;
            listOfPiecesForCheck = new List<Piece>();
            listOfEnemyPlayersPiecesForCastling = new List<Piece>();
            listOfPiecesForCheckMateWithCurrentPosition = new List<Tuple<Piece, int[]>>();
            listOfCheckPiecesThatCannotBeTaken = new List<Tuple<Piece, int[]>>();
            //listOfCheckPiecesAndTheirPositionsToCheck = new Dictionary<Piece, List<int[]>>();
            piecesThatCanStopCheck = new List<Piece>();
        }

        private King FindOpposingKingForCheck(Piece pieceMoved)
        {
            foreach (SortedDictionary<string, Piece> row in _currentGame._board.board)
            {
                foreach (KeyValuePair<string, Piece> kvp in row)
                {
                    if (kvp.Value == null)
                    {
                        continue;
                    }

                    if (kvp.Value.InherentValue == 5 && kvp.Value.Colour != pieceMoved.Colour)
                    {
                        //ONLY WORKING FOR CHECK
                        kingForCheck = kvp.Value as King;
                    }
                    else if (kvp.Value.Colour == pieceMoved.Colour)
                    {
                        //This is adding things wrong
                        listOfPiecesForCheck.Add(kvp.Value);
                        continue;
                    }
                }
            }
            return kingForCheck;
        }

        //Is Opponent in Check After Players Move
        public bool Check(Piece pieceMoved)
        {
            ResetListsForCheck();
            ResetListForCheckMate();
            FindOpposingKingForCheck(pieceMoved);

            if (kingForCheck == null)
            {
                Console.WriteLine("Something went majorly wrong in the FindOpposingKing");
                return false;
            }

            kingsPosition = moveEvaluator.GetPosition(kingForCheck);

            foreach (Piece piece in listOfPiecesForCheck)
            {
                if (moveEvaluator.EvaluateMove(true, piece, kingsPosition))
                {
                    //Many pieces could be check
                    //Once a piece has been found that can move to the enemy king, then it is set to null
                    //Think it needs to be reset once a piece has been found that can move to the King
                    if (kingForCheck != null)
                    {
                        kingForCheck = null;
                    }
                    int[] piecesPosition = moveEvaluator.GetPosition(piece);
                    Tuple<Piece, int[]> pieceAndPosition = new Tuple<Piece, int[]>(piece, piecesPosition);
                    listOfPiecesForCheckMateWithCurrentPosition.Add(pieceAndPosition);
                    //listOfPiecesForCheckMate.Add(piece);
                }
                continue;
            }

            if (kingForCheck == null)
            {
                return true;
            }
            return false;
        }

        public bool CheckMate()
        {
            kingForCheck = _currentGame._board.board.ElementAt(kingsPosition[0]).ElementAt(kingsPosition[1]).Value as King;
            if (CheckAllPiecesThatAreCheck())
            {
                return true;
            }
            //Not sure about further checks
            return false;
        }

        private bool CheckAllPiecesThatAreCheck()
        {
            if (!CanPieceBeTaken() &&
                !CanMoveBeBlocked())
            {
                return true;
            }
            return false;
        }

        private bool CanMoveBeBlocked()
        {
            //Not sure if need this
            Dictionary<Piece, List<int[]>> listOfPiecesMoves = new Dictionary<Piece, List<int[]>>();

            //All the pieces that canMove to the King
            foreach (Tuple<Piece, int[]> piece in listOfCheckPiecesThatCannotBeTaken)
            {
                //Assuming that you cannot block a Pawn, Knight or King moving to enemy King
                if (piece.Item1.InherentValue == 1 ||
                    piece.Item1.InherentValue == 3 ||
                    piece.Item1.InherentValue == 5)
                {
                    return false;
                }
                //This leaves Bishop, Rook and Queen

                if (kingsPosition == null)
                {
                    Console.WriteLine("Kings Position is null");
                    return true;
                }

                int[] currentPosition;
                int countOfPiecesThatCanStopCheck = piecesThatCanStopCheck.Count;
                switch (piece.Item1.InherentValue)
                {
                    case 2:
                        {
                            //Rook
                            currentPosition = moveEvaluator.GetPosition(piece.Item1);
                            if (currentPosition[0] > kingsPosition[0] || currentPosition[0] < kingsPosition[0] &&
                                currentPosition[1] == kingsPosition[1])
                            {
                                if (currentPosition[0] > kingsPosition[0])
                                {
                                    //Down
                                    int iterate = currentPosition[0] - kingsPosition[0];
                                    int[] simulatedPosition = new int[2];
                                    int positionYTemp = new int();

                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionYTemp = currentPosition[0] + i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = currentPosition[1];

                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    //Assuming it must be Up
                                    int iterate = kingsPosition[0] - currentPosition[0];
                                    int[] simulatedPosition = new int[2];
                                    int positionYTemp = new int();
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionYTemp = currentPosition[0] - i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = currentPosition[1];
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                            }
                            else if (currentPosition[0] == kingsPosition[0])
                            {
                                //Assuming moving horizontal
                                if (currentPosition[1] > kingsPosition[1])
                                {
                                    //left
                                    int iterate = currentPosition[1] - kingsPosition[1];
                                    int[] simulatedPosition = new int[2];
                                    int positionXTemp = new int();
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionXTemp = currentPosition[1] - i;
                                        simulatedPosition[1] = positionXTemp;
                                        simulatedPosition[0] = currentPosition[0];
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    //Assuming must be right
                                    int iterate = kingsPosition[1] - currentPosition[1];
                                    int[] simulatedPosition = new int[2];
                                    int positionXTemp = new int();
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionXTemp = currentPosition[1] + i;
                                        simulatedPosition[1] = positionXTemp;
                                        simulatedPosition[0] = currentPosition[0];
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            //Bishop
                            currentPosition = moveEvaluator.GetPosition(piece.Item1);
                            if (currentPosition[0] < kingsPosition[0] && currentPosition[1] > kingsPosition[1])
                            {
                                //South West
                                int iterate = currentPosition[1] - kingsPosition[1];
                                int[] simulatedPosition = new int[2];
                                if (iterate == (kingsPosition[0] - currentPosition[0]))
                                {
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        int positionXTemp = new int();
                                        int positionYTemp = new int();
                                        positionXTemp = currentPosition[1] - i;
                                        positionYTemp = currentPosition[0] + i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = positionXTemp;
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                break;
                            }
                            else if (currentPosition[0] > kingsPosition[0] && currentPosition[1] > kingsPosition[1])
                            {
                                //North West
                                int iterate = currentPosition[0] - kingsPosition[0];
                                int[] simulatedPosition = new int[2];
                                if (iterate == (currentPosition[1] - kingsPosition[1]))
                                {
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        int positionXTemp = new int();
                                        int positionYTemp = new int();
                                        positionXTemp = currentPosition[1] - i;
                                        positionYTemp = currentPosition[0] - i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = positionXTemp;
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                break;

                            }
                            else if (currentPosition[0] > kingsPosition[0] && currentPosition[1] < kingsPosition[1])
                            {
                                //North East
                                int iterate = kingsPosition[1] - currentPosition[1];
                                int[] simulatedPosition = new int[2];
                                if (iterate == (currentPosition[0] - kingsPosition[0]))
                                {
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        int positionXTemp = new int();
                                        int positionYTemp = new int();
                                        positionXTemp = currentPosition[1] + i;
                                        positionYTemp = currentPosition[0] - i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = positionXTemp;
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                break;
                            }
                            else if (currentPosition[0] < kingsPosition[0] && currentPosition[1] < kingsPosition[1])
                            {
                                //South East
                                int iterate = kingsPosition[0] - currentPosition[0];
                                int[] simulatedPosition = new int[2];
                                if (iterate == (kingsPosition[1] - currentPosition[1]))
                                {
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        int positionXTemp = new int();
                                        int positionYTemp = new int();
                                        positionXTemp = currentPosition[1] + i;
                                        positionYTemp = currentPosition[0] + i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = positionXTemp;
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                break;
                            }
                            break;
                        }
                    case 6:
                        {
                            currentPosition = moveEvaluator.GetPosition(piece.Item1);
                            //Queen
                            if ((currentPosition[0] > kingsPosition[0] || currentPosition[0] < kingsPosition[0]) &&
                                currentPosition[1] == kingsPosition[1])
                            {
                                if (currentPosition[0] > kingsPosition[0])
                                {
                                    //Down
                                    int iterate = currentPosition[0] - kingsPosition[0];
                                    int[] simulatedPosition = new int[2];
                                    int positionYTemp = new int();

                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionYTemp = currentPosition[0] + i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = currentPosition[1];

                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    //Assuming it must be Up
                                    int iterate = kingsPosition[0] - currentPosition[0];
                                    int[] simulatedPosition = new int[2];
                                    int positionYTemp = new int();
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionYTemp = currentPosition[0] - i;
                                        simulatedPosition[0] = positionYTemp;
                                        simulatedPosition[1] = currentPosition[1];
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                            }
                            else if (currentPosition[0] == kingsPosition[0])
                            {
                                //Horizontal
                                if (currentPosition[1] > kingsPosition[1])
                                {
                                    //left
                                    int iterate = currentPosition[1] - kingsPosition[1];
                                    int[] simulatedPosition = new int[2];
                                    int positionXTemp = new int();
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionXTemp = currentPosition[1] - i;
                                        simulatedPosition[1] = positionXTemp;
                                        simulatedPosition[0] = currentPosition[0];
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    //Assuming must be right
                                    int iterate = kingsPosition[1] - currentPosition[1];
                                    int[] simulatedPosition = new int[2];
                                    int positionXTemp = new int();
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        positionXTemp = currentPosition[1] + i;
                                        simulatedPosition[1] = positionXTemp;
                                        simulatedPosition[0] = currentPosition[0];
                                        foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                        {
                                            if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                            {
                                                return true;
                                            }
                                            if (i == iterate &&
                                                piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                            {
                                                return false;
                                            }
                                            continue;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Diagonal
                                if (currentPosition[0] < kingsPosition[0] && currentPosition[1] > kingsPosition[1])
                                {
                                    //South West
                                    int iterate = currentPosition[1] - kingsPosition[1];
                                    int[] simulatedPosition = new int[2];
                                    if (iterate == (kingsPosition[0] - currentPosition[0]))
                                    {
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionXTemp = new int();
                                            int positionYTemp = new int();
                                            positionXTemp = currentPosition[1] - i;
                                            positionYTemp = currentPosition[0] + i;
                                            simulatedPosition[0] = positionYTemp;
                                            simulatedPosition[1] = positionXTemp;
                                            foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                            {
                                                if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                                {
                                                    return true;
                                                }
                                                if (i == iterate &&
                                                    piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                                {
                                                    return false;
                                                }
                                                continue;
                                            }
                                        }
                                    }
                                    break;
                                }
                                else if (currentPosition[0] > kingsPosition[0] && currentPosition[1] > kingsPosition[1])
                                {
                                    //North West
                                    int iterate = currentPosition[0] - kingsPosition[0];
                                    int[] simulatedPosition = new int[2];
                                    if (iterate == (currentPosition[1] - kingsPosition[1]))
                                    {
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionXTemp = new int();
                                            int positionYTemp = new int();
                                            positionXTemp = currentPosition[1] - i;
                                            positionYTemp = currentPosition[0] - i;
                                            simulatedPosition[0] = positionYTemp;
                                            simulatedPosition[1] = positionXTemp;
                                            foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                            {
                                                if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                                {
                                                    return true;
                                                }
                                                if (i == iterate &&
                                                    piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                                {
                                                    return false;
                                                }
                                                continue;
                                            }
                                        }
                                    }
                                    break;

                                }
                                else if (currentPosition[0] > kingsPosition[0] && currentPosition[1] < kingsPosition[1])
                                {
                                    //North East
                                    int iterate = kingsPosition[1] - currentPosition[1];
                                    int[] simulatedPosition = new int[2];
                                    if (iterate == (currentPosition[0] - kingsPosition[0]))
                                    {
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionXTemp = new int();
                                            int positionYTemp = new int();
                                            positionXTemp = currentPosition[1] + i;
                                            positionYTemp = currentPosition[0] - i;
                                            simulatedPosition[0] = positionYTemp;
                                            simulatedPosition[1] = positionXTemp;
                                            foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                            {
                                                if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                                {
                                                    return true;
                                                }
                                                if (i == iterate &&
                                                    piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                                {
                                                    return false;
                                                }
                                                continue;
                                            }
                                        }
                                    }
                                    break;
                                }
                                else if (currentPosition[0] < kingsPosition[0] && currentPosition[1] < kingsPosition[1])
                                {
                                    //South East
                                    int iterate = kingsPosition[0] - currentPosition[0];
                                    int[] simulatedPosition = new int[2];
                                    if (iterate == (kingsPosition[1] - currentPosition[1]))
                                    {
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionXTemp = new int();
                                            int positionYTemp = new int();
                                            positionXTemp = currentPosition[1] + i;
                                            positionYTemp = currentPosition[0] + i;
                                            simulatedPosition[0] = positionYTemp;
                                            simulatedPosition[1] = positionXTemp;
                                            foreach (Piece pieceThatCanStopCheckMate in piecesThatCanStopCheck)
                                            {
                                                if (moveEvaluator.EvaluateMove(false, pieceThatCanStopCheckMate, simulatedPosition))
                                                {
                                                    return true;
                                                }
                                                if (i == iterate &&
                                                    piecesThatCanStopCheck.Last() == pieceThatCanStopCheckMate)
                                                {
                                                    return false;
                                                }
                                                continue;
                                            }
                                        }
                                    }
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                }
            }

            return true;
        }

        private bool CanPieceBeTaken()
        {
            foreach (SortedDictionary<string, Piece> row in _currentGame._board.board)
            {
                foreach (KeyValuePair<string, Piece> kvp in row)
                {
                    if (kvp.Value == null)
                    {
                        continue;
                    }
                    if (kvp.Value.Colour == kingForCheck.Colour)
                    {
                        piecesThatCanStopCheck.Add(kvp.Value);
                    }
                    continue;
                }
            }

            foreach (Piece piece in piecesThatCanStopCheck)
            {
                foreach (Tuple<Piece, int[]> pieceCausingCheck in listOfPiecesForCheckMateWithCurrentPosition)
                {
                    if (!moveEvaluator.EvaluateMove(true, piece, pieceCausingCheck.Item2))
                    {
                        Tuple<Piece, int[]> pieceAndPosition = new Tuple<Piece, int[]>(pieceCausingCheck.Item1, pieceCausingCheck.Item2);
                        if (!listOfCheckPiecesThatCannotBeTaken.Contains(pieceAndPosition))
                        {
                            listOfCheckPiecesThatCannotBeTaken.Add(pieceAndPosition);
                        }
                    }
                    continue;
                }
            }
            if (listOfCheckPiecesThatCannotBeTaken.Count > 0)
            {
                return false;
            }
            return true;
        }

        //******************************CASTLING***********************************
        public bool IsPlayersKingInCheck(string Colour, King KingToEval, int[] PositionOfKing)
        {
            foreach (Piece piece in listOfEnemyPlayersPiecesForCastling)
            {
                if (moveEvaluator.EvaluateMove(true, piece, PositionOfKing))
                {
                    return true;
                }
                continue;
            }
            return false;
        }

        public bool CanEnemyCaptureSquare(string Colour, int[] SimulatedPosition, bool Simulated)
        {
            ResetListForCastling();
            int[] simulatedPosition = new int[2];
            simulatedPosition[0] = SimulatedPosition[0];
            simulatedPosition[1] = SimulatedPosition[1];

            if (!Simulated)
            {
                //If not simulation
                return false;
            }

            foreach (SortedDictionary<string, Piece> row in _currentGame._board.board)
            {
                foreach (KeyValuePair<string, Piece> kvp in row)
                {
                    if (kvp.Value == null)
                    {
                        continue;
                    }
                    else if (kvp.Value.Colour != Colour)
                    {
                        listOfEnemyPlayersPiecesForCastling.Add(kvp.Value);
                    }
                    continue;
                }
            }

            foreach (Piece piece in listOfEnemyPlayersPiecesForCastling)
            {
                Mover tempMove = new Mover(_currentGame);
                MoveEvaluator moveEval = new MoveEvaluator(_currentGame, tempMove);

                if (moveEval.EvaluateMove(true, piece, SimulatedPosition, true, true))
                {
                    return true;
                }
                continue;
            }
            return false;
        }

        private void ResetListsForCheck()
        {
            List<Piece> tempListToDumpPieces = new List<Piece>();
            int iterateCheck = listOfPiecesForCheck.Count();
            kingsPosition = null;

            if (iterateCheck == 0)
            {
                return;
            }

            foreach (Piece piece in listOfPiecesForCheck)
            {
                tempListToDumpPieces.Add(piece);
            }

            for (int i = 0; i <= iterateCheck; iterateCheck--)
            {
                if (iterateCheck != 0)
                {
                    Piece pieceToRemove = listOfPiecesForCheck.ElementAt(i);
                    listOfPiecesForCheck.Remove(pieceToRemove);
                }
            }
        }

        private void ResetListForCheckMate()
        {
            List<Piece> tempListToDumpPieces = new List<Piece>();
            int iteratePiecesThatCanStopCheck = piecesThatCanStopCheck.Count();
            List<Tuple<Piece, int[]>> tempListToDumpPiecesAndPositions = new List<Tuple<Piece, int[]>>();
            //Dictionary<Piece, List<int[]>> tempListToDumpPiecesAndTheirPositions = new Dictionary<Piece, List<int[]>>();
            int iterateListOfPiecesForCheckMateWithCurrentPosition = listOfPiecesForCheckMateWithCurrentPosition.Count;
            int iterateListOfCheckPiecesThatCannotBeTaken = listOfCheckPiecesThatCannotBeTaken.Count;
            //int iterateListOfCheckPiecesAndTheirPositionsToCheck = listOfCheckPiecesAndTheirPositionsToCheck.Count;


            if (iteratePiecesThatCanStopCheck != 0)
            {
                foreach (Piece piece in piecesThatCanStopCheck)
                {
                    tempListToDumpPieces.Add(piece);
                }
                for (int i = 0; i <= iteratePiecesThatCanStopCheck; iteratePiecesThatCanStopCheck--)
                {
                    if (iteratePiecesThatCanStopCheck != 0)
                    {
                        Piece pieceToRemove = piecesThatCanStopCheck.ElementAt(i);
                        piecesThatCanStopCheck.Remove(pieceToRemove);
                    }
                }
            }

            if (iterateListOfPiecesForCheckMateWithCurrentPosition != 0)
            {
                foreach (Tuple<Piece, int[]> pieceAndPosition in listOfPiecesForCheckMateWithCurrentPosition)
                {
                    Tuple<Piece, int[]> pieceAndPositionForDisposal = new Tuple<Piece, int[]>(pieceAndPosition.Item1, pieceAndPosition.Item2);
                    tempListToDumpPiecesAndPositions.Add(pieceAndPositionForDisposal);
                }
                for (int i = 0; i <= iterateListOfPiecesForCheckMateWithCurrentPosition; iterateListOfPiecesForCheckMateWithCurrentPosition--)
                {
                    if (iterateListOfPiecesForCheckMateWithCurrentPosition != 0)
                    {
                        Tuple<Piece, int[]> tupleToRemove = listOfPiecesForCheckMateWithCurrentPosition.ElementAt(i);
                        listOfPiecesForCheckMateWithCurrentPosition.Remove(tupleToRemove);
                    }
                }
            }

            if (iterateListOfCheckPiecesThatCannotBeTaken != 0)
            {
                foreach (Tuple<Piece, int[]> pieceAndPosition in listOfCheckPiecesThatCannotBeTaken)
                {
                    Tuple<Piece, int[]> pieceAndPositionForDisposal = new Tuple<Piece, int[]>(pieceAndPosition.Item1, pieceAndPosition.Item2);
                    tempListToDumpPiecesAndPositions.Add(pieceAndPositionForDisposal);
                }
                for (int i = 0; i <= iterateListOfCheckPiecesThatCannotBeTaken; iterateListOfCheckPiecesThatCannotBeTaken--)
                {
                    if (iterateListOfCheckPiecesThatCannotBeTaken != 0)
                    {
                        Tuple<Piece, int[]> tupleToRemove = listOfCheckPiecesThatCannotBeTaken.ElementAt(i);
                        listOfCheckPiecesThatCannotBeTaken.Remove(tupleToRemove);
                    }
                }
            }

            //if (iterateListOfCheckPiecesAndTheirPositionsToCheck != 0)
            //{
            //    foreach (KeyValuePair<Piece, List<int[]>> pieceAndPositions in listOfCheckPiecesAndTheirPositionsToCheck)
            //    {
            //        tempListToDumpPiecesAndTheirPositions.Add(pieceAndPositions.Key, pieceAndPositions.Value);
            //    }
            //    for (int i = 0; i <= iterateListOfCheckPiecesAndTheirPositionsToCheck; iterateListOfCheckPiecesAndTheirPositionsToCheck--)
            //    {
            //        if (iterateListOfCheckPiecesAndTheirPositionsToCheck != 0)
            //        {
            //            KeyValuePair<Piece, List<int[]>> pieceAndPositionsToRemove = listOfCheckPiecesAndTheirPositionsToCheck.ElementAt(i);
            //            listOfCheckPiecesAndTheirPositionsToCheck.Remove(pieceAndPositionsToRemove.Key);
            //        }
            //    }
            //}
        }

        private void ResetListForCastling()
        {
            int iterateEnemyPiecesForCastling = listOfEnemyPlayersPiecesForCastling.Count();
            List<Piece> tempListToDumpPieces = new List<Piece>();

            if (iterateEnemyPiecesForCastling == 0)
            {
                return;
            }

            foreach (Piece piece in listOfEnemyPlayersPiecesForCastling)
            {
                tempListToDumpPieces.Add(piece);
            }

            for (int i = 0; i <= iterateEnemyPiecesForCastling; iterateEnemyPiecesForCastling--)
            {
                if (iterateEnemyPiecesForCastling != 0)
                {
                    Piece pieceToRemove = listOfEnemyPlayersPiecesForCastling.ElementAt(i);
                    listOfEnemyPlayersPiecesForCastling.Remove(pieceToRemove);
                }
            }
        }
    }
}

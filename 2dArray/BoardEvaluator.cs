using System;
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
        List<Piece> listOfPiecesForCheckMate;
        List<Piece> listOfEnemyPlayersPiecesForCastling;
        MoveEvaluator moveEvaluator;
        int[] kingsPosition;

        public BoardEvaluator(Game currentGame, MoveEvaluator MoveEvaluator)
        {
            _currentGame = currentGame;
            moveEvaluator = MoveEvaluator;
            listOfPiecesForCheck = new List<Piece>();
            listOfPiecesForCheckMate = new List<Piece>();
            listOfEnemyPlayersPiecesForCastling = new List<Piece>();
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
                    else if(kvp.Value.Colour == pieceMoved.Colour)
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
            FindOpposingKingForCheck(pieceMoved);

            if (kingForCheck == null)
            {
                Console.WriteLine("Something went majorly wrong in the FindOpposingKing");
                return false;
            }

            bool canMove = false;
            kingsPosition = moveEvaluator.GetPosition(kingForCheck);

            foreach (Piece piece in listOfPiecesForCheck)
            {
                canMove = moveEvaluator.EvaluateMove(true, piece, kingsPosition);
                if (canMove)
                {
                    //Many pieces could be check
                    //Think it needs to be reset once a piece has been found that can move to the King
                    kingForCheck = null;
                    listOfPiecesForCheckMate.Add(piece);
                    //return true;
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
            if (CheckAllPiecesThatAreCheck())
            {
                return true;
            }
            return false;
        }

        private bool CheckAllPiecesThatAreCheck()
        {
            if (!CanMoveBeBlocked() &&
                !CanPieceBeTaken())
            {
                return true;
            }
            return false;
        }

        private bool CanMoveBeBlocked()
        {
            //NEED TO FIGURE THIS OUT
            //NEED TO HAVE:
            //THE PIECES THAT ARE CAUSING CHECK
            //NEED TO FIND THE WAY IN WHICH THEY ARE MOVING
            //CAN ANY PIECE MOVE TO THE "POSITIONS" ALONG THE WAY OF THE PIECE TAKING THE KING
            return false;
        }

        //
        private bool CanPieceBeTaken()
        {
            List<Piece> piecesThatCanStopCheck = new List<Piece>();

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

            bool canMove = false;

            foreach (Piece piece in listOfPiecesForCheckMate)
            {
                canMove = moveEvaluator.EvaluateMove(true, piece, kingsPosition);
                if (canMove)
                {
                    return true;
                }
                continue;
            }
            return false;
        }

        //******************************CASTLING***********************************
        public bool IsPlayersKingInCheck(string Colour, King KingToEval, int[] PositionOfKing)
        {
            foreach (Piece piece in listOfEnemyPlayersPiecesForCastling)
            {
                bool canMove = moveEvaluator.EvaluateMove(true, piece, PositionOfKing);
                if (canMove)
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
                bool canMove = moveEval.EvaluateMove(true, piece, SimulatedPosition, true, true);
                if (canMove)
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
            int iterateCheckMate = listOfPiecesForCheckMate.Count();           
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

            if (iterateCheckMate == 0)
            {
                return;
            }

            foreach (Piece piece in listOfPiecesForCheckMate)
            {
                tempListToDumpPieces.Add(piece);
            }

            for (int i = 0; i <= iterateCheckMate; iterateCheckMate--)
            {
                if (iterateCheckMate != 0)
                {
                    Piece pieceToRemove = listOfPiecesForCheckMate.ElementAt(i);
                    listOfPiecesForCheckMate.Remove(pieceToRemove);
                }
            }
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

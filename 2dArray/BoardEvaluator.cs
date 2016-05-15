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
        MoveEvaluator moveEvaluator;

        public BoardEvaluator(Game currentGame)
        {
            _currentGame = currentGame;
            moveEvaluator = new MoveEvaluator(_currentGame);
            listOfPiecesForCheck = new List<Piece>();
        }

        private King FindOpposingKing(Piece pieceMoved)
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

        public bool Check(Piece pieceMoved)
        {
            ResetListOfPiecesForCheck();
            FindOpposingKing(pieceMoved);

            if (kingForCheck == null)
            {
                Console.Write("Something went majorly wrong in the FindOpposingKing");
                return false;
            }

            bool canMove = false;
            int[] kingsPosition = moveEvaluator.GetPosition(kingForCheck);

            foreach (Piece piece in listOfPiecesForCheck)
            {
                if (piece.InherentValue == 6)
                {
                    Console.WriteLine("Hello");
                }
                canMove = moveEvaluator.EvaluateMove(true, piece, kingsPosition);
                if (canMove)
                {
                    //Think it needs to be reset once a piece has been found that can move to the King
                    kingForCheck = null;
                    return true;
                }
                continue;
            }
            return false;
        }

        public bool CheckMate()
        {
            return true;
        }

        private void ResetListOfPiecesForCheck()
        {
            List<Piece> tempListToDumpPieces = new List<Piece>();
            int iterate = listOfPiecesForCheck.Count();

            if (iterate == 0)
            {
                return;
            }

            foreach (Piece piece in listOfPiecesForCheck)
            {
                tempListToDumpPieces.Add(piece);     
            }

            for (int i = 0; i <= iterate; iterate--)
            {
                if (iterate != 0)
                {
                    Piece pieceToRemove = listOfPiecesForCheck.ElementAt(i);
                    listOfPiecesForCheck.Remove(pieceToRemove);
                }
            }
        }
    }
}

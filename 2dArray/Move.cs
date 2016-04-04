using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Move : IPlayable
    {
        Game _currentGame;
        Piece _pieceToMove;
        SortedDictionary<string, Piece> pieceContainedIn;
        int[] _moveToCoOrdinates;
        int[] _whereAmI;
        int xAxis;
        int yAxis;

        public void MovePiece(Game CurrentGame, Piece PieceToMove, int[] MoveToCoOrdinates)
        {
            _currentGame = CurrentGame;
            _pieceToMove = PieceToMove;
            _moveToCoOrdinates = MoveToCoOrdinates;
            xAxis = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove)).Values.ToList().IndexOf(_pieceToMove);
            pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove));
            yAxis = _currentGame._board.board.IndexOf(pieceContainedIn);

            int[] _whereAmI = new int[2] 
            {
                xAxis,
                yAxis
            };            
        }
    }
}

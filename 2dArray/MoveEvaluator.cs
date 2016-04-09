using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class MoveEvaluator
    {
        private bool _canMove;
        private Board _currentBoard;
        private SortedDictionary<string, Piece> pieceContainedIn;

        public MoveEvaluator(Board CurrentBoard)
        {
            _currentBoard = CurrentBoard;
        }

        public bool EvaluateMove(bool CanMove)
        {
            _canMove = CanMove;
            //_currentBoard.

            return _canMove;
        }

        public int[] GetPosition(Piece PieceToQuery)
        {
            //Find the list that contains the piece
            pieceContainedIn = _currentBoard.board.Find(x => x.ContainsValue(PieceToQuery));
            int xAxisResolved;
            int yAxisResolved;
            int[] positionResolved = new int[]
            {
                yAxisResolved = _currentBoard.board.IndexOf(pieceContainedIn),
                xAxisResolved = _currentBoard.board.Find(x => x.ContainsValue(PieceToQuery)).Values.ToList().IndexOf(PieceToQuery)              
            };
        
            return positionResolved;
        }
    }
}

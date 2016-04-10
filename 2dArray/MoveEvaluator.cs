using System;
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
    public class MoveEvaluator
    {
        private bool _canMove;
        private Game _currentGame;
        private SortedDictionary<string, Piece> pieceContainedIn;
        private Piece _pieceToEval;
        private int[] _moveToCoOrds;
        private int[] _currentPosition;
        private int[] positionResolved;

        public MoveEvaluator(Game CurrentGame)
        {
            _currentGame = CurrentGame;
            positionResolved = new int[2];
        }

        public bool EvaluateMove(bool CanMove, Piece PieceToEval, int[] MoveToCoOrds)
        {
            _canMove = CanMove;
            _pieceToEval = PieceToEval;
            _moveToCoOrds = MoveToCoOrds;

            switch (_pieceToEval.InherentValue)
            {
                case 1:
                    //Pawn move logic
                    if (MoveToPositionPopulated())
                    {
                        _currentPosition = GetPosition(_pieceToEval);
                        //Is is the same as the starting position? Don't move
                        if (_currentPosition[0] == _moveToCoOrds[0] &&
                            _currentPosition[1] == _moveToCoOrds[1])
                        {
                            break;
                        }
                        //Is the move valid?
                        else if (((_currentPosition[0] -1) == _moveToCoOrds[0] || (_currentPosition[0] +1) == _moveToCoOrds[0]) &&
                            ((_currentPosition[1] -1) == _moveToCoOrds[1] || (_currentPosition[1] +1) == _moveToCoOrds[1]))
                        {
                            return true;
                            //Is 
                            if (true)
                            {

                            }
                        }
                    }
                    //If not populated, then check if it's the pawns first move
                    else
                    {
                        ////first move?
                        //if ()
                        //{

                        //}
                        //else if(((_currentPosition[0] - 1) == _moveToCoOrds[0] || (_currentPosition[0] + 1) == _moveToCoOrds[0]) &&
                        //    _currentPosition[1] == _moveToCoOrds[1])
                        //{
                        //    return true;
                        //}
                    }
                    
                    break;
                case 2:
                    //rook
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

            return _canMove = false;
        }

        public bool MoveToPositionPopulated()
        {
            //Check if Destination is populated
            if(_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null)
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
    }
}

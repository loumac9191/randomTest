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
    //**NO PIECE CAN MOVE OVER ANOTHER PIECE**
    public class MoveEvaluator
    {
        private bool _populated;
        private Game _currentGame;
        private SortedDictionary<string, Piece> pieceContainedIn;
        private Piece _pieceToEval;
        private int[] _moveToCoOrds;
        private int[] _currentPosition;

        public MoveEvaluator(Game CurrentGame)
        {
            _currentGame = CurrentGame;
        }

        public bool EvaluateMove(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        {
            //dont think need canmove
            _pieceToEval = PieceToEval;
            _moveToCoOrds = MoveToCoOrds;
            _populated = Populated;

            _currentPosition = GetPosition(_pieceToEval);
            //Is it the same as the starting position? Don't move
            if (_currentPosition[0] == _moveToCoOrds[0] &&
                _currentPosition[1] == _moveToCoOrds[1])
            {
                return false;
            }

            switch (_pieceToEval.InherentValue)
            {
                case 1:
                    //PAWN MOVE LOGIC
                    Pawn pawnToCheck = _pieceToEval as Pawn;
                    if (pawnToCheck == null)
                    {
                        break;
                    }
                    //Is the property FirstMove set to true or false?
                    if (pawnToCheck.FirstMove == true)
                    {
                        if (pawnToCheck.Colour == "Black")
                        {
                            if (((_currentPosition[0] + 1) == _moveToCoOrds[0] || (_currentPosition[0] + 2) == _moveToCoOrds[0]) &&
                                _currentPosition[1] == _moveToCoOrds[1])
                            {
                                //Moving Vertically
                                if ((_currentPosition[0] + 2) == _moveToCoOrds[0])
                                {
                                    if (_populated)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        pawnToCheck.FirstMove = false;
                                        return true;
                                    }
                                }
                                else
                                {
                                    int positionTemp = _currentPosition[0] + 1;
                                    if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_moveToCoOrds[1]).Value != null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        pawnToCheck.FirstMove = false;
                                        return true;
                                    }
                                }
                            }
                            else if ((_currentPosition[0] + 1) == _moveToCoOrds[0] &&
                            (((_currentPosition[1] - 1) == _moveToCoOrds[1]) || (_currentPosition[1] + 1) == _moveToCoOrds[1]))
                            {
                                //Moving Diagonally
                                if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == pawnToCheck.Colour)
                                {
                                    break;
                                }
                                else
                                {
                                    pawnToCheck.FirstMove = false;
                                    return true;
                                }
                            }
                            break;
                        }
                        else if (pawnToCheck.Colour == "White")
                        {
                            if (((_currentPosition[0] - 1) == _moveToCoOrds[0] || (_currentPosition[0] - 2) == _moveToCoOrds[0]) &&
                                _currentPosition[1] == _moveToCoOrds[1])
                            {
                                //Moving Vertically
                                if ((_currentPosition[0] - 2) == _moveToCoOrds[0])
                                {
                                    if (_populated)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        pawnToCheck.FirstMove = false;
                                        return true;
                                    }
                                }
                                else
                                {
                                    int positionTemp = _currentPosition[0] - 1;
                                    if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_moveToCoOrds[1]).Value != null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        pawnToCheck.FirstMove = false;
                                        return true;
                                    }
                                }
                            }
                            else if (((_currentPosition[1] - 1) == _moveToCoOrds[1] || (_currentPosition[1] + 1) == _moveToCoOrds[1]) &&
                                (_currentPosition[0] - 1) == _moveToCoOrds[0])
                            {
                                //Looking to capture a piece
                                if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == pawnToCheck.Colour)
                                {
                                    break;
                                }
                                else
                                {
                                    pawnToCheck.FirstMove = false;
                                    return true;
                                }
                            }
                            break;
                        }
                    }
                    else
                    {
                        //Pawn must be moving forward 1 piece (dependent on colour) OR
                        //Could be capturing another piece (moving diagonally)
                        if (pawnToCheck.Colour == "Black")
                        {
                            if ((_currentPosition[0] + 1) == _moveToCoOrds[0])
                            {
                                //Confirmed moving in correct direction
                                if ((_currentPosition[1] - 1) == _moveToCoOrds[1] || (_currentPosition[1] + 1) == _moveToCoOrds[1])
                                {
                                    if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null &&
                                        _currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                                    {
                                        return true;
                                    }
                                    break;
                                }
                                else if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value == null)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (pawnToCheck.Colour == "White")
                        {
                            if ((_currentPosition[0] - 1) == _moveToCoOrds[0])
                            {
                                //Confirmed moving in correct direction
                                if ((_currentPosition[1] - 1) == _moveToCoOrds[1] || (_currentPosition[1] + 1) == _moveToCoOrds[1])
                                {
                                    if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null &&
                                        _currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour != pawnToCheck.Colour)
                                    {
                                        return true;
                                    }
                                    break;
                                }
                                else if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value == null)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                    break;
                case 2:
                    //ROOK MOVE LOGIC
                    //Need to check that the destination is not obstructed by other pieces
                    //Vertical
                    if ((_moveToCoOrds[0] > _currentPosition[0] || _moveToCoOrds[0] < _currentPosition[0]) &&
                        _moveToCoOrds[1] == _currentPosition[1])
                    {
                        //Up
                        if (_moveToCoOrds[0] < _currentPosition[0])
                        {
                            int iterate = _currentPosition[0] - _moveToCoOrds[0];
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = _currentPosition[0] - i;
                                //No piece can move over another, so if position is filled,
                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[1]).Value != null)
                                {
                                    if (i == iterate)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        break;
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
                        else if (_moveToCoOrds[0] > _currentPosition[0])
                        {
                            int iterate = _moveToCoOrds[0] - _currentPosition[0];
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = _currentPosition[0] + i;
                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[1]).Value != null)
                                {
                                    if (i == iterate)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        break;
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
                        if ((_moveToCoOrds[1] > _currentPosition[1] || _moveToCoOrds[1] < _moveToCoOrds[1]) &&
                            _moveToCoOrds[0] == _currentPosition[0])
                        {
                            //Right
                            if (_moveToCoOrds[1] > _currentPosition[1])
                            {
                                int iterate = _moveToCoOrds[1] - _currentPosition[1];
                                for (int i = 1; i <= iterate; i++)
                                {
                                    int positionTemp = _currentPosition[1] + i;
                                    if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value != null)
                                    {
                                        if (i == iterate)
                                        {
                                            if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value.Colour == _pieceToEval.Colour)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            break;
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
                                if (_moveToCoOrds[1] < _currentPosition[1])
                                {
                                    int iterate = _currentPosition[1] - _moveToCoOrds[1];
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        int positionTemp = _currentPosition[1] - i;
                                        if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value != null)
                                        {
                                            if (i == iterate)
                                            {
                                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value.Colour == _pieceToEval.Colour)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                break;
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
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case 3:
                    //knight
                    //MOVE LOGIC
                    if (((_currentPosition[0] + 2) == _moveToCoOrds[0] && ((_currentPosition[1] - 1) == _moveToCoOrds[1] || (_currentPosition[1] + 1) == _moveToCoOrds[1])) ||
                        ((_currentPosition[0] - 2) == _moveToCoOrds[0] && ((_currentPosition[1] - 1) == _moveToCoOrds[1] || (_currentPosition[1] + 1) == _moveToCoOrds[1])) ||
                        ((_currentPosition[1] + 2) == _moveToCoOrds[1] && ((_currentPosition[0] - 1) == _moveToCoOrds[0] || (_currentPosition[0] + 1) == _moveToCoOrds[0])) ||
                        ((_currentPosition[1] - 2) == _moveToCoOrds[1] && ((_currentPosition[0] - 1) == _moveToCoOrds[0] || (_currentPosition[0] + 1) == _moveToCoOrds[0])))
                    {
                        if (_populated)
                        {
                            if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                            {
                                break;
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
                    break;
                case 4:
                    //Bishop
                    //MOVE LOGIC
                    if (_currentPosition[1] > _moveToCoOrds[1] && _currentPosition[0] < _moveToCoOrds[0])
                    {
                        int iterate = _currentPosition[1] - _moveToCoOrds[1];
                        if (iterate == (_moveToCoOrds[0] - _currentPosition[0]))
                        {
                            for (int i = 1; i <= iterate; i++)
                            {
                                if (i == iterate)
                                {
                                    if (_populated)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
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
                                    if (_currentGame._board.board.ElementAt((_currentPosition[0] + i)).ElementAt((_currentPosition[1] - i)).Value != null)
                                    {
                                        break;
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
                            break;
                        }
                    }
                    else if (_currentPosition[0] > _moveToCoOrds[0] && _currentPosition[1] > _moveToCoOrds[1])
                    {
                        //North West
                        int iterate = _currentPosition[0] - _moveToCoOrds[0];

                        if (iterate == (_currentPosition[1] - _moveToCoOrds[1]))
                        {
                            for (int i = 1; i <= iterate; i++)
                            {
                                if (i == iterate)
                                {
                                    if (_populated)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
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
                                    if (_currentGame._board.board.ElementAt((_currentPosition[0] - i)).ElementAt((_currentPosition[1] - i)).Value != null)
                                    {
                                        break;
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
                            break;
                        }
                    }
                    else if (_currentPosition[1] < _moveToCoOrds[1] && _currentPosition[0] > _moveToCoOrds[0])
                    {
                        //North East
                        int iterate = _moveToCoOrds[1] - _currentPosition[1];

                        if (iterate == (_currentPosition[0] - _moveToCoOrds[0]))
                        {
                            for (int i = 1; i <= iterate; i++)
                            {
                                if (i == iterate)
                                {
                                    if (_populated)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
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
                                    if (_currentGame._board.board.ElementAt((_currentPosition[0] - i)).ElementAt((_currentPosition[1] = i)).Value != null)
                                    {
                                        break;
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
                            break;
                        }
                    }
                    else if (_currentPosition[0] < _moveToCoOrds[0] && _currentPosition[1] < _moveToCoOrds[1])
                    {
                        //South East
                        int iterate = (_moveToCoOrds[0] - _currentPosition[0]);
                        if (iterate == (_moveToCoOrds[1] - _currentPosition[1]))
                        {
                            for (int i = 1; i <= iterate; i++)
                            {
                                if (i == iterate)
                                {
                                    if (_populated)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
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
                                    if (_currentGame._board.board.ElementAt((_currentPosition[0] + i)).ElementAt((_currentPosition[1] + i)).Value != null)
                                    {
                                        break;
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
                            break;
                        }
                    }
                    break;
                case 5:
                    //king
                    //KING MOVE LOGIC
                    if (((_currentPosition[0] + 1) == _moveToCoOrds[0] && _currentPosition[1] == _moveToCoOrds[1]) ||
                        ((_currentPosition[0] - 1) == _moveToCoOrds[0] && _currentPosition[1] == _moveToCoOrds[1]) ||
                        ((_currentPosition[1] + 1) == _moveToCoOrds[1] && _currentPosition[0] == _moveToCoOrds[0]) ||
                        ((_currentPosition[1] - 1) == _moveToCoOrds[1] && _currentPosition[0] == _moveToCoOrds[0]) ||
                        ((_currentPosition[1] - 1) == _moveToCoOrds[1] && (_currentPosition[0] + 1) == _moveToCoOrds[0]) ||
                        ((_currentPosition[0] - 1) == _moveToCoOrds[0] && (_currentPosition[1] - 1) == _moveToCoOrds[1]) ||
                        ((_currentPosition[1] + 1) == _moveToCoOrds[1] && (_currentPosition[0] - 1) == _moveToCoOrds[0]) ||
                        ((_currentPosition[0] + 1) == _moveToCoOrds[0] && (_currentPosition[1] + 1) == _moveToCoOrds[1]))
                    {
                        if (_populated)
                        {
                            if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                            {
                                break;
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
                    //else if (CASTLING)
                    //{
                    //    //may need to go ahead of the first statement
                    //}
                    break;
                case 6:
                    //QUEEN MOVE LOGIC
                    //Vertical
                    if ((_moveToCoOrds[0] > _currentPosition[0] || _moveToCoOrds[0] < _currentPosition[0]) &&
                        _moveToCoOrds[1] == _currentPosition[1])
                    {
                        //Up
                        if (_moveToCoOrds[0] < _currentPosition[0])
                        {
                            int iterate = _currentPosition[0] - _moveToCoOrds[0];
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = _currentPosition[0] - i;
                                //No piece can move over another, so if position is filled,
                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[1]).Value != null)
                                {
                                    if (i == iterate)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        break;
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
                        else if (_moveToCoOrds[0] > _currentPosition[0])
                        {
                            int iterate = _moveToCoOrds[0] - _currentPosition[0];
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = _currentPosition[0] + i;
                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[1]).Value != null)
                                {
                                    if (i == iterate)
                                    {
                                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        break;
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
                    else if ((_moveToCoOrds[1] > _currentPosition[1] || _moveToCoOrds[1] < _moveToCoOrds[1]) &&
                        _moveToCoOrds[0] == _currentPosition[0])
                    {
                        //Right
                        if (_moveToCoOrds[1] > _currentPosition[1])
                        {
                            int iterate = _moveToCoOrds[1] - _currentPosition[1];
                            for (int i = 1; i <= iterate; i++)
                            {
                                int positionTemp = _currentPosition[1] + i;
                                if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value != null)
                                {
                                    if (i == iterate)
                                    {
                                        if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value.Colour == _pieceToEval.Colour)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        break;
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
                            if (_moveToCoOrds[1] < _currentPosition[1])
                            {
                                int iterate = _currentPosition[1] - _moveToCoOrds[1];
                                for (int i = 1; i <= iterate; i++)
                                {
                                    int positionTemp = _currentPosition[1] - i;
                                    if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value != null)
                                    {
                                        if (i == iterate)
                                        {
                                            if (_currentGame._board.board.ElementAt(positionTemp).ElementAt(_currentPosition[0]).Value.Colour == _pieceToEval.Colour)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            break;
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
                                break;
                            }
                        }
                    }
                    else
                    {
                        //Diagonal
                        if (_currentPosition[1] > _moveToCoOrds[1] && _currentPosition[0] < _moveToCoOrds[0])
                        {
                            int iterate = _currentPosition[1] - _moveToCoOrds[1];
                            if (iterate == (_moveToCoOrds[0] - _currentPosition[0]))
                            {
                                for (int i = 1; i <= iterate; i++)
                                {
                                    if (i == iterate)
                                    {
                                        if (_populated)
                                        {
                                            if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                            {
                                                break;
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
                                        if (_currentGame._board.board.ElementAt((_currentPosition[0] + i)).ElementAt((_currentPosition[1] - i)).Value != null)
                                        {
                                            break;
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
                                break;
                            }
                        }
                        else if (_currentPosition[0] > _moveToCoOrds[0] && _currentPosition[1] > _moveToCoOrds[1])
                        {
                            //North West
                            int iterate = _currentPosition[0] - _moveToCoOrds[0];

                            if (iterate == (_currentPosition[1] - _moveToCoOrds[1]))
                            {
                                for (int i = 1; i <= iterate; i++)
                                {
                                    if (i == iterate)
                                    {
                                        if (_populated)
                                        {
                                            if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                            {
                                                break;
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
                                        if (_currentGame._board.board.ElementAt((_currentPosition[0] - i)).ElementAt((_currentPosition[1] - i)).Value != null)
                                        {
                                            break;
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
                                break;
                            }
                        }
                        else if (_currentPosition[1] < _moveToCoOrds[1] && _currentPosition[0] > _moveToCoOrds[0])
                        {
                            //North East
                            int iterate = _moveToCoOrds[1] - _currentPosition[1];

                            if (iterate == (_currentPosition[0] - _moveToCoOrds[0]))
                            {
                                for (int i = 1; i <= iterate; i++)
                                {
                                    if (i == iterate)
                                    {
                                        if (_populated)
                                        {
                                            if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                            {
                                                break;
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
                                        if (_currentGame._board.board.ElementAt((_currentPosition[0] - i)).ElementAt((_currentPosition[1] = i)).Value != null)
                                        {
                                            break;
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
                                break;
                            }
                        }
                        else if (_currentPosition[0] < _moveToCoOrds[0] && _currentPosition[1] < _moveToCoOrds[1])
                        {
                            //South East
                            int iterate = (_moveToCoOrds[0] - _currentPosition[0]);
                            if (iterate == (_moveToCoOrds[1] - _currentPosition[1]))
                            {
                                for (int i = 1; i <= iterate; i++)
                                {
                                    if (i == iterate)
                                    {
                                        if (_populated)
                                        {
                                            if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == _pieceToEval.Colour)
                                            {
                                                break;
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
                                        if (_currentGame._board.board.ElementAt((_currentPosition[0] + i)).ElementAt((_currentPosition[1] + i)).Value != null)
                                        {
                                            break;
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
                                break;
                            }
                        }
                        break;
                    }
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

        public int[] GetPosition(Piece PieceToQuery)
        {
            int[] positionResolved = new int[2];
            //Find the list that contains the piece
            pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(PieceToQuery));
            //Populate the array
            positionResolved[0] = _currentGame._board.board.IndexOf(pieceContainedIn);
            positionResolved[1] = _currentGame._board.board.Find(x => x.ContainsValue(PieceToQuery)).Values.ToList().IndexOf(PieceToQuery);

            return positionResolved;
        }

        public void MoveToCorrection(int[] CorrectionToSendToMover)
        {
            //Send corrected coordinates to Mover to update where the piece can legally move to
        }
    }
}

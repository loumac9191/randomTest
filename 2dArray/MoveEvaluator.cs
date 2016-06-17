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
    //**NO PIECE CAN MOVE OVER ANOTHER PIECE**
    public class MoveEvaluator
    {
        private bool _populated;
        private Game _currentGame;
        private SortedDictionary<string, Piece> pieceContainedIn;
        private Piece _pieceToEval;
        private int[] _moveToCoOrds;
        private int[] _currentPosition;
        private BoardEvaluator boardEval;
        private Mover _mover;

        public MoveEvaluator(Game CurrentGame, Mover Mover)
        {
            _mover = Mover;
            _currentGame = CurrentGame;
            boardEval = new BoardEvaluator(_currentGame, this);
        }

        public bool EvaluateMove(bool Populated, Piece PieceToEval, int[] MoveToCoOrds, bool Simulation = false, bool CastlingCheck = false)
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
                    //BLACK IS DOWN
                    //WHITE IS UP
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
                                        pawnToCheck.FirstMoveWasTwoSquares = true;
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
                                if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null &&
                                    _currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == pawnToCheck.Colour)
                                {
                                    break;
                                }
                                else if(_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null)
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
                                //Moving Vertically Up
                                if ((_currentPosition[0] - 2) == _moveToCoOrds[0])
                                {
                                    if (_populated)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        pawnToCheck.FirstMove = false;
                                        pawnToCheck.FirstMoveWasTwoSquares = true;
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
                                if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null &&
                                    _currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == pawnToCheck.Colour)
                                {
                                    break;
                                }
                                else if(_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null)
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
                                        if (pawnToCheck.FirstMoveWasTwoSquares == true)
                                        {
                                            pawnToCheck.FirstMoveWasTwoSquares = false;
                                        }
                                        return true;
                                    }
                                    else if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value == null)
                                    {
                                        Pawn eligibleForEnPassant;
                                        int[] positionOfEnPassantPawn;
                                        if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(_moveToCoOrds[1]).Value != null &&
                                            _currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(_moveToCoOrds[1]).Value.InherentValue == 1)
                                        {
                                            eligibleForEnPassant = _currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(_moveToCoOrds[1]).Value as Pawn;
                                            if (eligibleForEnPassant.FirstMoveWasTwoSquares)
                                            {
                                                positionOfEnPassantPawn = GetPosition(eligibleForEnPassant);
                                                _mover.RemovePawnForEnPassant(eligibleForEnPassant, positionOfEnPassantPawn);
                                            }
                                        }
                                        if (pawnToCheck.FirstMoveWasTwoSquares == true)
                                        {
                                            pawnToCheck.FirstMoveWasTwoSquares = false;
                                        }
                                        return true;
                                    }
                                    break;
                                }
                                else if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value == null)
                                {
                                    if (pawnToCheck.FirstMoveWasTwoSquares == true)
                                    {
                                        pawnToCheck.FirstMoveWasTwoSquares = false;
                                    }
                                    return true;
                                }
                                break;
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
                                        if (pawnToCheck.FirstMoveWasTwoSquares == true)
                                        {
                                            pawnToCheck.FirstMoveWasTwoSquares = false;
                                        }
                                        return true;
                                    }
                                    else if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value == null)
                                    {
                                        //Check if en passant
                                        Pawn eligibleForEnPassant;
                                        int[] positionOfEnPassantPawn;
                                        if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(_moveToCoOrds[1]).Value != null &&
                                            _currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(_moveToCoOrds[1]).Value.InherentValue == 1)
                                        {
                                            eligibleForEnPassant = _currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(_moveToCoOrds[1]).Value as Pawn;
                                            if (eligibleForEnPassant.FirstMoveWasTwoSquares)
                                            {
                                                positionOfEnPassantPawn = GetPosition(eligibleForEnPassant);
                                                _mover.RemovePawnForEnPassant(eligibleForEnPassant, positionOfEnPassantPawn);
                                            }
                                        }
                                        if (pawnToCheck.FirstMoveWasTwoSquares == true)
                                        {
                                            pawnToCheck.FirstMoveWasTwoSquares = false;
                                        }
                                        return true;
                                    }
                                    break;
                                }
                                else if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value == null)
                                {
                                    if (pawnToCheck.FirstMoveWasTwoSquares == true)
                                    {
                                        pawnToCheck.FirstMoveWasTwoSquares = false;
                                    }
                                    return true;
                                }
                                break;
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
                                    if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value != null)
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
                            //Left
                            else
                            {
                                if (_moveToCoOrds[1] < _currentPosition[1])
                                {
                                    int iterate = _currentPosition[1] - _moveToCoOrds[1];
                                    for (int i = 1; i <= iterate; i++)
                                    {
                                        int positionTemp = _currentPosition[1] - i;
                                        if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value != null)
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
                                int positionXTemp = new int();
                                int positionYTemp = new int();
                                positionXTemp = (_currentPosition[1] - i);
                                positionYTemp = (_currentPosition[0] + i);
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
                                    if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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
                                int positionXTemp = new int();
                                int positionYTemp = new int();
                                positionXTemp = (_currentPosition[1] - i);
                                positionYTemp = (_currentPosition[0] - i);
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
                                    if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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
                                int positionXTemp = new int();
                                int positionYTemp = new int();
                                positionXTemp = (_currentPosition[1] + i);
                                positionYTemp = (_currentPosition[0] - i);
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
                                    if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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
                                int positionXTemp = new int();
                                int positionYTemp = new int();
                                positionXTemp = (_currentPosition[1] + i);
                                positionYTemp = (_currentPosition[0] + i);
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
                                    if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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
                    //CASTLING NEEDS TESTING
                    King kingToEval = _pieceToEval as King;
                    int[] c8 = new int[] { 0, 2 };
                    int[] g8 = new int[] { 0, 6 };
                    int[] c1 = new int[] { 7, 2 };
                    int[] g1 = new int[] { 7, 6 };

                    if (kingToEval.FirstMove && !CastlingCheck &&
                        ((_moveToCoOrds[1] == c8[1] &&  _moveToCoOrds[0] == c8[0]) ||
                        (_moveToCoOrds[0] == g8[0] && _moveToCoOrds[1] == g8[1]) ||
                        (_moveToCoOrds[0] == c1[0] && _moveToCoOrds[1] == c1[1]) ||
                        (_moveToCoOrds[0] == g1[0] && _moveToCoOrds[1] == g1[1])))
                    {
                        if ((_moveToCoOrds[1] == c8[1] && _moveToCoOrds[0] == c8[0]) ||
                            (_moveToCoOrds[0] == g8[0] && _moveToCoOrds[1] == g8[1]))
                        {
                            if (_currentPosition[1] > _moveToCoOrds[1])
                            {
                                //LEFT
                                if (_currentGame._board.board.ElementAt(0).ElementAt(0).Value != null &&
                                    _currentGame._board.board.ElementAt(0).ElementAt(0).Value.InherentValue == 2) 
                                {
                                    Rook rookAtA8 = _currentGame._board.board.ElementAt(0).ElementAt(0).Value as Rook;
                                    if (rookAtA8.FirstMove == true)
                                    {
                                        int[] positionOfRook = GetPosition(rookAtA8);
                                        int iterate = _currentPosition[1] - positionOfRook[1];
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionTemp = new int();
                                            positionTemp = _currentPosition[1] - i;
                                            if (i == iterate)
                                            {
                                                if (!boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, _currentPosition))
                                                {
                                                    int[] positionOfRookCastled = new int[2] { 0, 2 };
                                                    rookAtA8.FirstMove = false;
                                                    kingToEval.FirstMove = false;
                                                    MoveRookForCastling(positionOfRookCastled, rookAtA8, Simulation);
                                                    return true;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value == null)
                                            {
                                                if (i <= 2)
                                                {
                                                    int[] simulatePosition = new int[2] { _currentPosition[0], positionTemp };
                                                    if (!boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Simulation = false;
                                                    continue;
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
                                else
                                {
                                    break;
                                }
                            }
                            else if (_currentPosition[1] < _moveToCoOrds[1])
                            {
                                //RIGHT
                                if (_currentGame._board.board.ElementAt(0).ElementAt(7).Value != null &&
                                    _currentGame._board.board.ElementAt(0).ElementAt(7).Value.InherentValue == 2)
                                {
                                    Rook rookAtH8 = _currentGame._board.board.ElementAt(0).ElementAt(7).Value as Rook;
                                    if (rookAtH8.FirstMove == true)
                                    {
                                        int[] positionOfRook = GetPosition(rookAtH8);
                                        int iterate = positionOfRook[1] - _currentPosition[1];
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionTemp = new int();
                                            positionTemp = _currentPosition[1] + i;
                                            if (i == iterate)
                                            {
                                                if (!boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, _currentPosition))
                                                {
                                                    int[] positionOfRookCastled = new int[2] { 0, 5 };
                                                    rookAtH8.FirstMove = false;
                                                    kingToEval.FirstMove = false;
                                                    MoveRookForCastling(positionOfRookCastled, rookAtH8, Simulation);
                                                    return true;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value == null)
                                            {
                                                if (i <= 2)
                                                {
                                                    int[] simulatePosition = new int[2] { _currentPosition[0], positionTemp };
                                                    if (!boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Simulation = false;
                                                    continue;
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
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if((_moveToCoOrds[0] == c1[0] && _moveToCoOrds[1] == c1[1]) ||
                            (_moveToCoOrds[0] == g1[0] && _moveToCoOrds[1] == g1[1]))
                        {
                            if (_currentPosition[1] > _moveToCoOrds[1])
                            {
                                //LEFT
                                if (_currentGame._board.board.ElementAt(7).ElementAt(0).Value != null &&
                                    _currentGame._board.board.ElementAt(7).ElementAt(0).Value.InherentValue == 2)
                                {
                                    Rook rookAtC1 = _currentGame._board.board.ElementAt(7).ElementAt(0).Value as Rook;
                                    if (rookAtC1.FirstMove == true)
                                    {
                                        int[] positionOfRook = GetPosition(rookAtC1);
                                        int iterate = _currentPosition[1] - positionOfRook[1];
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionTemp = new int();
                                            positionTemp = _currentPosition[1] - i;
                                            if (i == iterate)
                                            {
                                                if (!boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, _currentPosition))
                                                {
                                                    int[] positionOfRookCastled = new int[2] { 7, 2 };
                                                    rookAtC1.FirstMove = false;
                                                    kingToEval.FirstMove = false;
                                                    MoveRookForCastling(positionOfRookCastled, rookAtC1, Simulation);
                                                    return true;
                                                }
                                            }
                                            else if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value == null)
                                            {
                                                if (i <= 2)
                                                {
                                                    int[] simulatePosition = new int[2] { _currentPosition[0], positionTemp };
                                                    if (!boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Simulation = false;
                                                    continue;
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
                                else
                                {
                                    break;
                                }
                            }
                            else if (_currentPosition[1] < _moveToCoOrds[1])
                            {
                                //RIGHT
                                if (_currentGame._board.board.ElementAt(7).ElementAt(7).Value != null &&
                                    _currentGame._board.board.ElementAt(7).ElementAt(7).Value.InherentValue == 2)
                                {
                                    Rook rookAtG1 = _currentGame._board.board.ElementAt(7).ElementAt(7).Value as Rook;
                                    if (rookAtG1.FirstMove == true)
                                    {
                                        int[] positionOfRook = GetPosition(rookAtG1);
                                        int iterate = positionOfRook[1] - _currentPosition[1];
                                        for (int i = 1; i <= iterate; i++)
                                        {
                                            int positionTemp = new int();
                                            positionTemp = _currentPosition[1] + i;
                                            if (i == iterate)
                                            {
                                                if (!boardEval.IsPlayersKingInCheck(kingToEval.Colour, kingToEval, _currentPosition))
                                                {
                                                    int[] positionOfRookCastled = new int[2] { 7, 5 };
                                                    rookAtG1.FirstMove = false;
                                                    kingToEval.FirstMove = false;
                                                    MoveRookForCastling(positionOfRookCastled, rookAtG1, Simulation);
                                                    return true;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value == null)
                                            {
                                                if (i <= 2)
                                                {
                                                    int[] simulatePosition = new int[2] { _currentPosition[0], positionTemp };
                                                    if (!boardEval.CanEnemyCaptureSquare(kingToEval.Colour, simulatePosition, true))
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Simulation = false;
                                                    continue;
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
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (((_currentPosition[0] + 1) == _moveToCoOrds[0] && _currentPosition[1] == _moveToCoOrds[1]) ||
                        ((_currentPosition[0] - 1) == _moveToCoOrds[0] && _currentPosition[1] == _moveToCoOrds[1]) ||
                        ((_currentPosition[1] + 1) == _moveToCoOrds[1] && _currentPosition[0] == _moveToCoOrds[0]) ||
                        ((_currentPosition[1] - 1) == _moveToCoOrds[1] && _currentPosition[0] == _moveToCoOrds[0]) ||
                        ((_currentPosition[1] - 1) == _moveToCoOrds[1] && (_currentPosition[0] + 1) == _moveToCoOrds[0]) ||
                        ((_currentPosition[0] - 1) == _moveToCoOrds[0] && (_currentPosition[1] - 1) == _moveToCoOrds[1]) ||
                        ((_currentPosition[1] + 1) == _moveToCoOrds[1] && (_currentPosition[0] - 1) == _moveToCoOrds[0]) ||
                        ((_currentPosition[0] + 1) == _moveToCoOrds[0] && (_currentPosition[1] + 1) == _moveToCoOrds[1]))
                    {
                        if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value != null)
                        {
                            if (_currentGame._board.board.ElementAt(_moveToCoOrds[0]).ElementAt(_moveToCoOrds[1]).Value.Colour == kingToEval.Colour)
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
                                if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value != null)
                                {
                                    if (i == iterate)
                                    {
                                        if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value.Colour == _pieceToEval.Colour)
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
                                    if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value != null)
                                    {
                                        if (i == iterate)
                                        {
                                            if (_currentGame._board.board.ElementAt(_currentPosition[0]).ElementAt(positionTemp).Value.Colour == _pieceToEval.Colour)
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
                                    int positionXTemp = new int();
                                    int positionYTemp = new int();
                                    positionXTemp = (_currentPosition[1] - i);
                                    positionYTemp = (_currentPosition[0] + i);
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
                                        if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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
                                    int positionXTemp = new int();
                                    int positionYTemp = new int();
                                    positionXTemp = (_currentPosition[1] - i);
                                    positionYTemp = (_currentPosition[0] - i);
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
                                        if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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
                                    int positionXTemp = new int();
                                    int positionYTemp = new int();
                                    positionXTemp = (_currentPosition[1] + i);
                                    positionYTemp = (_currentPosition[0] - i);
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
                                        if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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
                                    int positionXTemp = new int();
                                    int positionYTemp = new int();
                                    positionXTemp = (_currentPosition[1] + i);
                                    positionYTemp = (_currentPosition[0] + i);
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
                                        if (_currentGame._board.board.ElementAt(positionYTemp).ElementAt(positionXTemp).Value != null)
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

        public void MoveRookForCastling(int[] CorrectionToSendToMover, Rook RookToMove, bool Simulation)
        {
            if (Simulation)
            {
                return;
            }
            //Send CoOrds for Rook to Move to
            _mover.MoveRookForCastling(CorrectionToSendToMover, RookToMove);
        }

        //***********************************REFACTOR******************************************
        //private bool PawnMoveLogic(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        //{

        //}

        //private bool RookMoveLogic(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        //{

        //}

        //private bool KnightMoveLogic(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        //{

        //}

        //private bool BishopMoveLogic(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        //{

        //}

        //private bool KingMoveLogic(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        //{

        //}

        //private bool QueenMoveLogic(bool Populated, Piece PieceToEval, int[] MoveToCoOrds)
        //{

        //}
    }
}

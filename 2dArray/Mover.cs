using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Mover : IPlayable
    {
        private Game _currentGame;
        private Converter _converter = new Converter();
        private Piece _pieceToMove;
        private SortedDictionary<string, Piece> pieceContainedIn;
        private int[] _moveToCoOrdinates = new int[2];
        private int xAxis;
        private int yAxis;
        private string co0rd;
        private string reservedKey;

        public void MovePiece(Game CurrentGame, Piece PieceToMove, int[] MoveToCoOrdinates)
        {
            _currentGame = CurrentGame;
            _pieceToMove = PieceToMove;
            //When coOrdinates are given by the player it will be numbered 1-8, this WONT factor in zero indexing, therefore -1 on yValues
            _moveToCoOrdinates = MoveToCoOrdinates;
            _moveToCoOrdinates[0] -= 1;           

            xAxis = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove)).Values.ToList().IndexOf(_pieceToMove);
            pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove));
            yAxis = _currentGame._board.board.IndexOf(pieceContainedIn);

            co0rd = _converter.Convert(xAxis);
            reservedKey = _converter.Convert(_moveToCoOrdinates[1]);

            //Remove
            _currentGame._board.board.ElementAt(yAxis).Remove(_currentGame._board.board.ElementAt(yAxis).ElementAt(xAxis).Key);

            //Rename the XAxis string and reorder
            switch (xAxis)
            {
                case 0:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
                case 1:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
                case 2:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
                case 3:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
                case 4:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
                case 5:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
                case 6:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
                case 7:
                    _currentGame._board.board.ElementAt(yAxis).Add(co0rd, null);
                    break;
            };

            _currentGame._board.board.ElementAt(yAxis).OrderBy(x => x.Key);

            //Remove the key from the pieces destination
            _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Remove(reservedKey);

            //Move and Reorder
            _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Add(reservedKey, _pieceToMove);
            _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).OrderBy(x => x.Key);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Game
    {
        public Board _board;
        public Mover mover;
        public MoveEvaluator moveEval;
        //bool _toPlay;
        public int xHorizontalBorder;
        public int yVerticalBorder;
        public Player _playerOne;
        public Player _playerTwo;
        private int[] coOrds;


        public Game(Board Board, Player PlayerOne, Player PlayerTwo)
        {
            _board = Board;
            _playerOne = PlayerOne;
            _playerTwo = PlayerTwo;
            mover = new Mover();
            moveEval = new MoveEvaluator(_board);
            int xHorizontalBorder = _board.board.ElementAt(0).Count();
            int yVericalBorder = _board.board.Count();

            //players must be given pieces in their lists
            foreach (var rowOfPieces in _board.board)
            {
                foreach (var piece in rowOfPieces)
                {
                    if (piece.Value == null)
                    {
                        continue;
                    }
                    else if (piece.Value.Colour == "Black")
                    {
                        piece.Value.Owner = "Player One";

                        switch (piece.Value.InherentValue)
                        {
                            case 1:
                                coOrds = moveEval.GetPosition(piece.Value);
                                _playerOne.ListOfPieces.Add(String.Format("{0}, {1}", coOrds[0].ToString(), coOrds[1].ToString()),"Pawn");
                                break;
                        }
                        
                    }
                    else
                    {

                    }
                    //piece.Value.Colour
                }
            }
        }

        //Games must have some rules
        //No piece must be able to go
    }
}

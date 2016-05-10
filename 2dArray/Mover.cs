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
        private BoardEvaluator boardEval;
        private Piece _pieceToMove;
        //Also in Move Evaluator
        private SortedDictionary<string, Piece> pieceContainedIn;
        private int[] _moveToCoOrdinates = new int[2];
        //Move Evaluator
        private int currentXAxis;
        //Move Evaluator
        private int currentYAxis;
        private string coOrdAsCharacter;
        private string incumbentKey;
        private MoveEvaluator moveEval;
        private int yAxisBeforeCorrection;
        private int[] yx;
        private bool _canMove;

        public Mover(Game CurrentGame)
        {
            _currentGame = CurrentGame;
            moveEval = new MoveEvaluator(CurrentGame);
            boardEval = new BoardEvaluator(CurrentGame);
        }

        //DON'T THINK THIS NEEDS TO BE GIVEN THE CURRENT GAME AGAIN
        public void MovePiece(Game CurrentGame, Piece PieceToMove, int[] MoveToCoOrdinates)
        {
            _pieceToMove = PieceToMove;
            //When coOrdinates are given by the player it will be numbered 1-8, this WONT factor in zero indexing, therefore -1 on yValues
            //i.e I want to move x to 4, A; this would be 3, 0 in index
            _moveToCoOrdinates = MoveToCoOrdinates;
            yAxisBeforeCorrection = _moveToCoOrdinates[0];
            _moveToCoOrdinates[0] -= 1;
            _moveToCoOrdinates[1] -= 1;          

            //Current Location Variables
            currentXAxis = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove)).Values.ToList().IndexOf(_pieceToMove);
            pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(_pieceToMove));
            currentYAxis = _currentGame._board.board.IndexOf(pieceContainedIn);

            coOrdAsCharacter = _converter.ConvertXAxis(currentXAxis);
            incumbentKey = _converter.ConvertXAxis(_moveToCoOrdinates[1]);

            //Initial checks
            //1) Is The Range of CoOrdinates provided legal? i.e. less than or equal to the border of the board
            //2) is the position the piece is moving to populated? Move as 
            //3) **IS PAWN PIECE NULL?
            //4) 
            //
            if (yAxisBeforeCorrection > _currentGame.yVerticalBorder ||
                _moveToCoOrdinates[1] > _currentGame.xHorizontalBorder)
            {
                //Need to tell the game that the move wasn't valid
                //Announcer class which talks to the game
            }
            else if(!moveEval.MoveToDestinationPopulated(MoveToCoOrdinates))
            {
                if (moveEval.EvaluateMove(false, _pieceToMove,_moveToCoOrdinates))
                {
                    //Remove the pieceToMove from its current location
                    _currentGame._board.board.ElementAt(currentYAxis).Remove(_currentGame._board.board.ElementAt(currentYAxis).ElementAt(currentXAxis).Key);

                    //Rename the XAxis key (string) and reorder
                    switch (currentXAxis)
                    {
                        case 0:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 1:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 2:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 3:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 4:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 5:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 6:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 7:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                    };
                    //Reorder
                    _currentGame._board.board.ElementAt(currentYAxis).OrderBy(x => x.Key);

                    //Remove the key from the pieces destination otherwise not unique
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Remove(incumbentKey);

                    //Move and Reorder
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Add(incumbentKey, _pieceToMove);
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).OrderBy(x => x.Key);

                    bool check = boardEval.Check(_pieceToMove);

                    if (check)
                    {
                        Console.WriteLine("Wew Check");
                    }
                }
            }
            else
            {
                if (moveEval.EvaluateMove(true, _pieceToMove, _moveToCoOrdinates))
                {
                    //Remove the pieceToMove from its current location
                    _currentGame._board.board.ElementAt(currentYAxis).Remove(_currentGame._board.board.ElementAt(currentYAxis).ElementAt(currentXAxis).Key);

                    //Rename the XAxis key (string) and reorder
                    switch (currentXAxis)
                    {
                        case 0:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 1:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 2:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 3:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 4:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 5:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 6:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                        case 7:
                            _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacter, null);
                            break;
                    };
                    //Reorder
                    _currentGame._board.board.ElementAt(currentYAxis).OrderBy(x => x.Key);

                    //Remove the key from the pieces destination otherwise not unique
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Remove(incumbentKey);

                    //Move and Reorder
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).Add(incumbentKey, _pieceToMove);
                    _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).OrderBy(x => x.Key);

                    bool check = boardEval.Check(_pieceToMove);

                    if (check)
                    {
                        Console.WriteLine("Wew Check");
                    }

                    //CheckMate
                }
            }
        }

        public int[] ProvidePosition(Piece PositionOfPieceInQuery)
        {
            return yx = moveEval.GetPosition(PositionOfPieceInQuery);
        }
    }
}

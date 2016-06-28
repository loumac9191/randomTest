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
        private Converter _converter;
        private BoardEvaluator boardEval;
        private int currentYAxis;
        private MoveEvaluator moveEval;

        public Mover(Game CurrentGame)
        {
            _currentGame = CurrentGame;
            moveEval = new MoveEvaluator(CurrentGame, this);
            boardEval = new BoardEvaluator(CurrentGame, moveEval);
            _converter = new Converter();
        }

        public void MovePiece(Piece PieceToMove, int[] MoveToCoOrdinates)
        {
            int yAxisBeforeCorrection = MoveToCoOrdinates[0];
            MoveToCoOrdinates[0] -= 1;
            MoveToCoOrdinates[1] -= 1;          
            int currentXAxis = _currentGame._board.board.Find(x => x.ContainsValue(PieceToMove)).Values.ToList().IndexOf(PieceToMove);
            SortedDictionary<string, Piece> pieceContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(PieceToMove));
            currentYAxis = _currentGame._board.board.IndexOf(pieceContainedIn);
            string coOrdAsCharacter = _converter.ConvertXAxis(currentXAxis);
            string incumbentKey = _converter.ConvertXAxis(MoveToCoOrdinates[1]);
            bool populated = moveEval.MoveToDestinationPopulated(MoveToCoOrdinates);

            if (yAxisBeforeCorrection > _currentGame.yVerticalBorder ||
                MoveToCoOrdinates[1] > _currentGame.xHorizontalBorder)
            {
                //Need to tell the game that the move wasn't valid
                //Announcer class which talks to the game
            }
            if (moveEval.EvaluateMove(populated, PieceToMove,MoveToCoOrdinates))
            {
                //Remove the pieceToMove from its current location
                _currentGame._board.board.ElementAt(currentYAxis).Remove(_currentGame._board.board.ElementAt(currentYAxis).ElementAt(currentXAxis).Key);

                //Rename the XAxis key (string)
                RenameXAxis(currentXAxis, coOrdAsCharacter);

                //Reorder
                _currentGame._board.board.ElementAt(currentYAxis).OrderBy(x => x.Key);

                //Remove the key from the pieces destination otherwise not unique
                _currentGame._board.board.ElementAt(MoveToCoOrdinates[0]).Remove(incumbentKey);

                if (populated)
                {
                    ////Remove the piece from the destination and place this in the games removed list?
                    //KeyValuePair<string, Piece> kvpForPieceRemoved = _currentGame._board.board.ElementAt(_moveToCoOrdinates[0]).ElementAt(_moveToCoOrdinates[1]);

                    //_currentGame.listOfRemovedPieces.Add(kvpForPieceRemoved.Value);
                }

                //Move and Reorder
                _currentGame._board.board.ElementAt(MoveToCoOrdinates[0]).Add(incumbentKey, PieceToMove);
                _currentGame._board.board.ElementAt(MoveToCoOrdinates[0]).OrderBy(x => x.Key);

                if (boardEval.Check(PieceToMove))
                {
                    Console.WriteLine("Wew Check");
                    //if (boardEval.CheckMate())
                    //{
                    //    Console.WriteLine("CHECKMATE!");
                    //}
                }
            }
            else
            {
                Console.WriteLine("Invalid Move");
            }
        }
        
        public int[] ProvidePosition(Piece PositionOfPieceInQuery)
        {
            return moveEval.GetPosition(PositionOfPieceInQuery); 
        }

        private void RenameXAxis(int currentXAxis, string coOrdAsCharacterForRename)
        {
            switch (currentXAxis)
            {
                case 0:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 1:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 2:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 3:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 4:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 5:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 6:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
                case 7:
                    _currentGame._board.board.ElementAt(currentYAxis).Add(coOrdAsCharacterForRename, null);
                    break;
            };
        }

        public void MoveRookForCastling(int[] CoOrdinatesForMove, Rook RookToMove)
        {
            SortedDictionary<string,Piece> rookContainedIn = _currentGame._board.board.Find(x => x.ContainsValue(RookToMove));
            int currentYAxisOfRook = _currentGame._board.board.IndexOf(rookContainedIn);
            int currentXAxisOfRook = _currentGame._board.board.Find(x => x.ContainsValue(RookToMove)).Values.ToList().IndexOf(RookToMove);
            string CoordsOfRookAsString = _converter.ConvertXAxis(currentXAxisOfRook);
            string incumbentKeyOfRook = _converter.ConvertXAxis(CoOrdinatesForMove[1]);   
                    
            _currentGame._board.board.ElementAt(currentYAxisOfRook).Remove(_currentGame._board.board.ElementAt(currentYAxisOfRook).ElementAt(currentXAxisOfRook).Key);
            RenameXAxis(currentXAxisOfRook, CoordsOfRookAsString);
            _currentGame._board.board.ElementAt(currentYAxisOfRook).OrderBy(x => x.Key);
            _currentGame._board.board.ElementAt(CoOrdinatesForMove[0]).Remove(incumbentKeyOfRook);
            _currentGame._board.board.ElementAt(CoOrdinatesForMove[0]).Add(incumbentKeyOfRook, RookToMove);
            _currentGame._board.board.ElementAt(CoOrdinatesForMove[0]).OrderBy(x => x.Key);
        }

        public void RemovePawnForEnPassant(Pawn PawnToRemove, int[] PositionOfPawn)
        {
            string CoordsOfPawnAsString = _converter.ConvertXAxis(PositionOfPawn[1]);

            _currentGame._board.board.ElementAt(PositionOfPawn[0]).Remove(_currentGame._board.board.ElementAt(PositionOfPawn[0]).ElementAt(PositionOfPawn[1]).Key);
            RenameXAxis(PositionOfPawn[1], CoordsOfPawnAsString);
            _currentGame._board.board.ElementAt(PositionOfPawn[0]).OrderBy(x => x.Key);
        }
    }
}

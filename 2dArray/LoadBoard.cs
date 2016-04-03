using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class LoadBoard
    {
        Board _currentBoardGame;

        public LoadBoard(Board CurrentBoardGame)
        {
            _currentBoardGame = CurrentBoardGame;
            //Load();  
        }

        //public void Load()
        //{
        //    Pawn pawn = new Pawn();
        //    Rook rook = new Rook();
        //    Knight knight = new Knight();
        //    Bishop bishop = new Bishop();
        //    King king = new King();
        //    Queen queen = new Queen();

        //    foreach (var vArray in _currentBoardGame.board)
        //    {
        //        if (vArray == _currentBoardGame.board[0] ||
        //            vArray == _currentBoardGame.board[7])
        //        {
        //            //populate row with rook, knight, bishop, king, queen, bishop, knight, rook
        //            foreach (int position in vArray)
        //            {                        
        //                int nValue = Array.(vArray, position);
        //                Array.FindIndex(vArray,position)

        //                //case or if?
        //                if (nValue == 0 ||
        //                    nValue == 7)
        //                {
        //                    vArray[nValue] = position + rook.value;
        //                    //rook
        //                }
        //                else if (nValue == 1 ||
        //                    nValue == 6)
        //                {
        //                    vArray[nValue] = position + knight.value;
        //                    //knight
        //                }
        //                else if (nValue == 2 ||
        //                    nValue == 5)
        //                {
        //                    vArray[nValue] = position + bishop.value;
        //                    //bishop
        //                }
        //                else if (nValue == 3)
        //                {
        //                    vArray[nValue] = position + king.value;
        //                    //king
        //                }
        //                else
        //                {
        //                    vArray[nValue] = position + queen.value;
        //                    //queen
        //                }
        //            }
        //        }
        //        else if (vArray == _currentBoardGame.board[1] ||
        //            vArray == _currentBoardGame.board[6])
        //        {
        //            foreach (int position in vArray)
        //            {
        //                int nValue = Array.IndexOf(vArray, position);
        //                //need to test whether this is correct
        //                vArray[nValue] = position + pawn.value;
        //            }
        //        }
        //    }
        //}
    }
}

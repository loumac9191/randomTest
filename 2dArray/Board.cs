using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Board
    {
        public List<Dictionary<string, Piece>> board;
        public Dictionary<string, Piece> one;


        public Board()
        {
            Rook rook = new Rook();
            board = new List<Dictionary<string, Piece>>();
            one = new Dictionary<string, Piece>
            {
                {"A", rook },

            };



            
        }
        ////KeyValuePair<string, int> yaTesting;
        //public int[][] board;

        //public Board()
        //{
        //    board = new int[8][];

        //    board[0] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[1] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[2] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[3] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[4] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[5] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[6] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //    board[7] = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        //}
        ////board.GetValue(0, 7);
    }
}


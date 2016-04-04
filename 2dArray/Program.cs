using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //Board board = new Board();
            //LoadBoard lBoard = new LoadBoard(board);

            //int SIZE = 8;
            //Piece rook = new Rook();
            //List<Dictionary<string, Piece[]>> board2 = new List<Dictionary<string, Piece[]>>();

            //Dictionary<string, Piece[]> eight = new Dictionary<string, Piece[]>();
            //Dictionary<string, Piece[]> seven = new Dictionary<string, Piece[]>();
            //Dictionary<string, Piece[]> six = new Dictionary<string, Piece[]>();
            //Dictionary<string, Piece[]> five = new Dictionary<string, Piece[]>();
            //Dictionary<string, Piece[]> four = new Dictionary<string, Piece[]>();
            //Dictionary<string, Piece[]> three = new Dictionary<string, Piece[]>();
            //Dictionary<string, Piece[]> two = new Dictionary<string, Piece[]>();
            //Dictionary<string, Piece[]> one = new Dictionary<string, Piece[]>();
            //KeyValuePair<int, Piece> yep = new KeyValuePair<int, Piece>(SIZE, rook);

            //Bishop bBishop = new Bishop();

            //Console.WriteLine(bBishop.colour);
            //Rook bRook1 = new Rook()
            //{
            //    colour = "black"
            //};

            //Dictionary<string, Piece> test = new Dictionary<string, Piece>
            //{
            //    {"A", bRook1 }
            //};
            //int ind = test.Values.ToList().IndexOf(bRook1);
            //Console.WriteLine(ind);


            //int count = board.board.Count();
            //Console.WriteLine(count);

            Board board = new Board();

            string s = board.board.ElementAt(0).ElementAt(0).Value.Colour;
            string s3 = board.board.ElementAt(7).ElementAt(7).Value.Colour;
            string s2 = board.board.ElementAt(0).ElementAt(4).Value.Colour.ToString();
            string s4 = board.board.ElementAt(6).ElementAt(3).Value.InherentValue.ToString();
            var r = board.board.ElementAt(0);
            Console.WriteLine(s);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);

            int pCount = 0;

            foreach (var piece in board.board)
            {
                pCount++;
            }

            Console.WriteLine(pCount);

            foreach (var item in r)
            {
                Console.WriteLine(item.Value);
            }

            Console.WriteLine(1);

            Console.WriteLine(board.board);



            //Board board = new Board();

            //Console.WriteLine(board.board[1][2]);

            //int s = Array.IndexOf(board.board[0], 0);
            //Console.WriteLine(s);
            ////board.board[1][2] = board.board[1][2] + 2;

            //Console.WriteLine(board.board[1][2]);
        }
    }
}

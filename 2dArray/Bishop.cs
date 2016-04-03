using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Bishop : Piece
    {
        public int value = 4;
        public int move = 8;
        public string direction = "diagonal";
        public new string colour = "black/white";
    }
}

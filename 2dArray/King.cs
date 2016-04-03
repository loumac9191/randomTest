using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class King : Piece
    {
        public int value = 5;
        public int move = 1;
        public string direction = "any when not in check";
        public string pColour = "black/white";
    }
}

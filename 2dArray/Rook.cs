using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Rook : Piece
    {
        private int inherentValue = 2;
        public new int distanceCapacity = 8;
        public new string moveDirection = "verticle/horizontal";
        public new string colour = "black/white";

        public int InherentValue
        {
            get
            {
                return inherentValue;
            }

            set
            {
                inherentValue = value;
            }
        }
    }
}

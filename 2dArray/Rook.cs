using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Rook : Piece
    {
        //private int inherentValue = 2;
        //public new int distanceCapacity = 8;
        //public new string moveDirection = "verticle/horizontal";
        //public new string colour = "black/white";

        private int inherentValue = 2;

        public int InherentValue
        {
            get { return this.inherentValue; }
            set { this.inherentValue = value; }
        }

        private int distanceCapacity = 8;

        public int DistanceCapacity
        {
            get { return this.distanceCapacity; }
            set { this.distanceCapacity = value; }
        }

        private string moveDirection = "vertical/horizontal";

        public string MoveDirection
        {
            get { return this.moveDirection; }
            set { this.moveDirection = value; }
        }

        private string colour;

        public string Colour
        {
            get { return this.colour; }
            set { this.colour = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Queen : Piece
    {
        //public int value = 6;
        //public int move = 8;
        //public string direction = "any ";
        //public string pColour = "black/white";

        private int inherentValue = 6;

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

        private string moveDirection = "any";

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

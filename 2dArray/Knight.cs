using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Knight : Piece
    {
        //public int value = 3;
        //public int move = 3;
        //public string direction = "two verticle one horizontal, two horizontal one verticle";
        //public string pColour = "black/white";

        private int inherentValue = 3;

        public int InherentValue
        {
            get { return this.inherentValue; }
            set { this.inherentValue = value; }
        }

        private int distanceCapacity = 3;

        public int DistanceCapacity
        {
            get { return this.distanceCapacity; }
            set { this.distanceCapacity = value; }
        }

        private string moveDirection = "two verticle one horizontal, two horizontal one verticle";

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

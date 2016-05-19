﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class King : Piece
    {
        private int inherentValue = 5;

        public int InherentValue
        {
            get { return this.inherentValue; }
            set { this.inherentValue = value; }
        }

        private int distanceCapacity = 1;

        public int DistanceCapacity
        {
            get { return this.distanceCapacity; }
            set { this.distanceCapacity = value; }
        }

        private string moveDirection = "any direction when not in check";

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

        private string owner;

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        private bool firstMove;

        public bool FirstMove
        {
            get { return firstMove; }
            set { firstMove = value; }
        }
    }
}

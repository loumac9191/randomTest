﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Game
    {
        public Board _board;
        //bool _toPlay;
        public int xHorizontal;
        public int yVertical;
        public Player _playerOne;
        public Player _playerTwo;


        public Game(Board Board, Player PlayerOne, Player PlayerTwo)
        {
            _board = Board;
            _playerOne = PlayerOne;
            _playerTwo = PlayerTwo;
            int xHorizontal = _board.board.ElementAt(0).Count();
            int yVerical = _board.board.Count();
        }

        //Games must have some rules
        //No piece must be able to go
    }
}

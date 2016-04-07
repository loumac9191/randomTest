using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Player
    {
        private SortedDictionary<string, string> listOfPieces = new SortedDictionary<string, string>();

        public SortedDictionary<string,string> ListOfPieces
        {
            get { return listOfPieces; }
            set { listOfPieces = value; }
        }

        private SortedDictionary<string, string> listOfMovesMade = new SortedDictionary<string, string>();

        public SortedDictionary<string, string> ListOfMovesMade
        {
            get { return listOfMovesMade; }
            set { listOfMovesMade = value; }
        }

        private bool winLose;

        public bool WinLose
        {
            get { return winLose; }
            set { winLose = value; }
        }
    }
}

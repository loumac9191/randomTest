using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public interface Piece
    {
        int InherentValue { get; set; }
        int DistanceCapacity { get; set; }
        string MoveDirection { get; set; }
        string Colour { get; set; }
        string Owner { get; set; }
    }
}

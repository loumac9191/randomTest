using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    public class Converter
    {
        private string xAxisToConvert;
        private string yAxisToConvert;

        public string ConvertXAxis(int XAxisToConvert)
        {
            switch (XAxisToConvert)
            {
                case 0:
                    xAxisToConvert = "A";
                    break;
                case 1:
                    xAxisToConvert = "B";
                    break;
                case 2:
                    xAxisToConvert = "C";
                    break;
                case 3:
                    xAxisToConvert = "D";
                    break;
                case 4:
                    xAxisToConvert = "E";
                    break;
                case 5:
                    xAxisToConvert = "F";
                    break;
                case 6:
                    xAxisToConvert = "G";
                    break;
                case 7:
                    xAxisToConvert = "H";
                    break;
            }
            return xAxisToConvert;
        }

        public int[] ConvertBoardPositionToCoordinate(string PositionToConvert)
        {
            int[] returningCoords = new int[2];

            returningCoords[0] = 1;
            returningCoords[1] = Convert.ToInt32(PositionToConvert.Substring(1));

            return returningCoords;
        }
    }
}

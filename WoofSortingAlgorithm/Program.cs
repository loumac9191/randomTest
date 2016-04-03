﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoofSortingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNoToSort = { 2, 4, 5, 14, 21, 5, 51, 53252523, 525123, 13131, 15, 252, 521, 12352, 256, 6225, 235124124, 55252, 64363635, 4353, 24, 114, 3252, 42 };
            Print(arrayOfNoToSort);
            Console.WriteLine(" ");
            int[] sortedArray = Sort(arrayOfNoToSort, 0);
            Print(sortedArray);

        }
        private static int[] Sort(int[] arrayToSort, int startPoint)
        {
            //Check whether need to stop or not
            if (startPoint == arrayToSort.Length)
            {
                return arrayToSort;
            }

            int i = startPoint + 1;
            while (i < arrayToSort.Length)
            {
                int compareNumb = arrayToSort[i];
                int origNum = arrayToSort[startPoint];
                if (compareNumb < origNum)
                {
                    arrayToSort[startPoint] = compareNumb;
                    arrayToSort[i] = origNum;
                }
                i++;
            }
            startPoint++;
            Sort(arrayToSort, startPoint);
            //this return actually wont ever be called
            return arrayToSort;
        }
        
        private static void Print (int[] intArray)
        {
            foreach (int number in intArray)
            {
                Console.WriteLine(number);
            }
        }
    }
}

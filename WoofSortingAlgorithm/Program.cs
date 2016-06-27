using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoofSortingAlgorithm
{
    class A
    {
    }

    class B : A
    {
    }

    class C : B
    {
    }
    class Program
    {
        //static void Main(string[] args)
        //{
        //    int[] arrayOfNoToSort = { 2, 4, 5, 14, 21, 5, 51, 53252523, 525123, 13131, 15, 252, 521, 12352, 256, 6225, 235124124, 55252, 64363635, 4353, 24, 114, 3252, 42 };
        //    Print(arrayOfNoToSort);
        //    Console.WriteLine(" ");
        //    int[] sortedArray = Sort(arrayOfNoToSort, 0);
        //    Print(sortedArray);

        //}
        //private static int[] Sort(int[] arrayToSort, int startPoint)
        //{
        //    //Check whether need to stop or not
        //    if (startPoint == arrayToSort.Length)
        //    {
        //        return arrayToSort;
        //    }

        //    int i = startPoint + 1;
        //    while (i < arrayToSort.Length)
        //    {
        //        int compareNumb = arrayToSort[i];
        //        int origNum = arrayToSort[startPoint];
        //        if (compareNumb < origNum)
        //        {
        //            arrayToSort[startPoint] = compareNumb;
        //            arrayToSort[i] = origNum;
        //        }
        //        i++;
        //    }
        //    startPoint++;
        //    Sort(arrayToSort, startPoint);
        //    //this return actually wont ever be called
        //    return arrayToSort;
        //}

        //private static void Print (int[] intArray)
        //{
        //    foreach (int number in intArray)
        //    {
        //        Console.WriteLine(number);
        //    }
        //}


            static void Main()
            {
                //A a1 = new A();
                //A a2 = new B();
                //A a3 = new C();

                //Console.WriteLine(a1.GetType());
                //Console.WriteLine(a2.GetType());
                //Console.WriteLine(a3.GetType());

            RandomComplexObj testTest = new RandomComplexObj()
            {
                name = "Bob"
            };
            RandomComplexObj testTest2 = new RandomComplexObj()
            {
                name = "Sonya"
            };
            RandomComplexObj testTest3 = new RandomComplexObj()
            {
                name = "Barb"
            };
            RandomComplexObj testTest4 = new RandomComplexObj()
            {
                name = "Tony"
            };

            List<RandomComplexObj> listTest = new List<RandomComplexObj>();
            List<RandomComplexObj> listTest2 = new List<RandomComplexObj>();

            listTest.Add(testTest);
            listTest.Add(testTest2);
            listTest.Add(testTest3);
            listTest.Add(testTest4);

            foreach (var item in listTest)
            {
                Console.WriteLine(item.name);
            }

            listTest2.Add(testTest);
            listTest2.Add(testTest2);
            listTest2.Add(testTest3);
            listTest2.Add(testTest4);

            foreach (var item in listTest2)
            {
                Console.WriteLine(item.name);
            }

            foreach (var item in listTest)
            {
                Console.WriteLine(item.name);
            }

            foreach (var item in listTest2)
            {
                int i = 1;
                item.name = String.Format("{0}.{1}", "Bob", i.ToString());
                Console.WriteLine(item.name);
                i++;
            }

            foreach (var item in listTest)
            {
                Console.WriteLine(item.name);
            }

            if (testTest.RetrunsTrue())
            {
                Console.WriteLine("lol");
            }

            string yeah = "yeah";
            KeyValuePair<int, string> test1 = new KeyValuePair<int, string>();
            KeyValuePair<int, string> test2 = new KeyValuePair<int, string>();

            Dictionary<int, string> testings = new Dictionary<int, string>();
            Dictionary<int, string> testings2;

            //test1.Value = yeah;
            //testings.Add(test1.Key, test1.Value);
            //testings.Add(test2.Key, test2.Value);

            //int iterate = testings.Count;

            //for (int i = 0; i <= iterate; iterate--)
            //{
            //    testings2 = new Dictionary<int, string>();
            //    testings2.Add(test1.Key, test2.Value);
            //    testings2.Add(test2.Key, test2.Value);
            //    if (iterate != 0)
            //    {
            //        KeyValuePair<string, int> theActualOne = testings.ElementAt(i);
            //        testings.Remove(theActualOne.Key);
            //    }
            //}

            List<string> testStringList = new List<string>();
            string test122 = "lol";
            string test12 = "lol";
            string test13= "lastlol";
            testStringList.Add(test122);
            testStringList.Add(test12);
            testStringList.Add(test13);

            int counterer = 1;
            foreach (string item in testStringList)
            {
                Console.WriteLine(counterer.ToString());
                Console.WriteLine(item);
                Console.WriteLine(testStringList.Last());
                counterer += 1;
            }

            List<Tuple<string, int>> somethingtesting = new List<Tuple<string, int>>();
            //somethingtesting.Add()



        }
    }
}

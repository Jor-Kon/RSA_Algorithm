using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BBS
{
    public class Tests
    {
        public static bool singleBitTest(BitArray input)
        {
            int count = 0;
            foreach (bool e in input)
            {
                if (e == true)
                    count++;
            }
            Console.WriteLine("Test pojedynczych bitów: {0}\n", count);
            if (count > 9725 && count < 10275)
                return true;
            else
                return false;
        }

        public static bool seriesTest_(BitArray input)
        {
            int[] count = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

            bool previousIsTrue;
            if (input[0] == false)
                previousIsTrue = false;
            else
                previousIsTrue = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    if (previousIsTrue == true && input[i] == true)
                    {

                    }
                }
                if (previousIsTrue == true && input[i] == true)
                    count[0]++;
                else if (previousIsTrue == true && input[i] == false)
                {

                    for (int j = 1; j < 6; j++)
                    {
                        if (count[0] == j)
                        {
                            count[j]++;
                            break;
                        }
                        if (count[0] >= 6)
                        {
                            count[6]++;
                            break;
                        }
                    }

                    previousIsTrue = false;
                    count[0] = 0;
                }
                else if (previousIsTrue == false && input[i] == true)
                {
                    for (int j = 1; j < 6; j++)
                    {
                        if (count[0] == j)
                        {
                            count[j]++;
                            break;
                        }
                        if (count[0] >= 6)
                        {
                            count[6]++;
                            break;
                        }
                    }
                    previousIsTrue = true;
                    count[0] = 0;
                }
                else if (previousIsTrue == false && input[i] == false)
                    count[0]++;
            }

            Console.WriteLine("Test serii:");
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine("długość serii: {0} | {1}", i, count[i]);
            }
            Console.WriteLine();

            if (count[1] >= 2315 && count[1] <= 2685 &&
                count[2] >= 1114 && count[2] <= 1386 &&
                count[3] >= 527 && count[3] <= 723 &&
                count[4] >= 240 && count[4] <= 384 &&
                count[5] >= 103 && count[5] <= 209 &&
                count[6] >= 103 && count[6] <= 209)
                return true;
            else
                return false;
        }

        public static bool seriesTest(BitArray input)
        {
            int[] count = new int[7] { 1, 0, 0, 0, 0, 0, 0 };

            bool isOne;
            if (input[0] == false)
                isOne = false;
            else
                isOne = true;
            for (int i = 1; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    if (isOne == true && input[i] == true)
                    {
                        count[0]++;
                        if (count[0] > 5)
                            count[6]++;
                        else
                            count[count[0]]++;
                    }
                }
                else if (isOne == true && input[i] == true)
                    count[0]++;
                else if (isOne == true && input[i] == false)
                {
                    if (count[0] > 5)
                        count[6]++;
                    else
                        count[count[0]]++;
                    isOne = false;
                    count[0] = 1;
                }

                if (input[i] == true)
                    isOne = true;
            }
            Console.WriteLine("Test serii:");
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine("Długość serii {0} | {1}", i, count[i]);
            }
            Console.WriteLine();

            if (count[1] >= 2315 && count[1] <= 2685 &&
                count[2] >= 1114 && count[2] <= 1386 &&
                count[3] >= 527 && count[3] <= 723 &&
                count[4] >= 240 && count[4] <= 384 &&
                count[5] >= 103 && count[5] <= 209 &&
                count[6] >= 103 && count[6] <= 209)
                return true;
            else
                return false;
        }

        public static bool longSeriesTest(BitArray input)
        {
            int count = 0;
            int biggestSeries = 0;

            bool isOne;
            if (input[0] == false)
                isOne = false;
            else
                isOne = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (isOne == true && input[i] == true)
                    count++;
                else if (isOne == true && input[i] == false)
                {
                    if (count > biggestSeries)
                        biggestSeries = count;
                    isOne = false;
                    count = 0;
                }
                else if (isOne == false && input[i] == true)
                {
                    if (count > biggestSeries)
                        biggestSeries = count;
                    isOne = true;
                    count = 0;
                }
                else if (isOne == false && input[i] == false)
                    count++;
            }

            Console.WriteLine("Test długiej serii: {0}\n", biggestSeries);
            if (biggestSeries < 26)
                return true;
            else
                return false;
        }

        public static bool pokerTest(BitArray input)
        {
            BitArray temp = new BitArray(4);
            List<int> listOfFours = new List<int>();
            int[] x = new int[1];
            for (int i = 0; i < input.Length; i += 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[j] = input[i + j];
                }
                temp.CopyTo(x, 0);
                listOfFours.Add(x[0]);
            }

            var q = from e in listOfFours
                    group e by e into gr
                    let count = gr.Count()
                    orderby gr.Key ascending
                    select new { Value = gr.Key, Count = count };

            //foreach (var element in q)
            //    Console.WriteLine($" {element.Value} | {element.Count} ");


            double ret = 0;
            foreach (var e in q)
            {
                ret += e.Count * e.Count;
            }
            ret = ret * 16 / 5000 - 5000;

            Console.WriteLine("Test pokerowy: {0}\n", ret);

            if (ret > 2.16 && ret < 46.17)
                return true;
            else
                return false;
        }
    }
}

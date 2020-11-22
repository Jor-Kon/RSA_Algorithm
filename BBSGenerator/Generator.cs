using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BBS
{
    public class Generator
    {
        static readonly BigInteger p = 100000000000031;
        static readonly BigInteger q = 100000000000067;
        static readonly BigInteger N = p * q;

        static BigInteger nextNumber(BigInteger previous)
        {
            return (previous * previous) % N;
        }

        static bool leastSignificantBit(BigInteger n)
        {
            if ((n & 1) != 0)
                return true;
            else
                return false;
        }

        static int generateSeed()
        {
            Random rnd = new Random();
            return rnd.Next();
        }

        public static BitArray generatorBBS()
        {
            BigInteger seed;
            do
            {
                seed = generateSeed();
            } while (BigInteger.GreatestCommonDivisor(seed, N) != 1);

            int amountOfBits = 20000;
            Console.WriteLine($"x = {seed}\nbits = {amountOfBits}\np = {p}\nq = {q}\nN = {N}");

            Console.WriteLine("Generating...");
            BitArray bbsArray = new BitArray(amountOfBits);
            BigInteger previous = (seed * seed) % N;
            for (int i = 0; i < amountOfBits; i++)
            {
                BigInteger next = nextNumber(previous);
                bbsArray[i] = leastSignificantBit(next);
                previous = next;
            }
            Console.WriteLine();

            return bbsArray;
        }

        public static void displayArray(BitArray array)
        {
            foreach (bool e in array)
            {
                if (e == true) Console.Write("1");
                else Console.Write("0");
            }
            Console.WriteLine();
        }
    }
}

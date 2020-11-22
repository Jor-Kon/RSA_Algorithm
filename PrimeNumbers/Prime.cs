using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace PrimeNumbers
{
    public static class Prime
    {
        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException();
        }

        public static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }

        public static bool isPrime(BigInteger n)
        {
            if (n <= 0) throw new IOException();
            if (n == 1 || n == 2) return true;
            if (n % 2 == 0) return false;
            for (BigInteger i = 3; i < Sqrt(n); i++)
            {
                if (BigInteger.GreatestCommonDivisor(i, n) == i)
                    return false;
            }
            return true;
        }

        public static BigInteger findPrimeNumber(BigInteger min)
        {
            BigInteger primeNumber = 0;
            BigInteger temp;
            BigInteger check = 3;

            if (min % 2 == 0)
                temp = min + 1;
            else
                temp = min;
            bool flag = true;
            do
            {
                if (isPrime(temp) == true)
                    primeNumber = temp;
                else
                {
                    temp += 2;
                }
            } while (primeNumber == 0);


            return primeNumber;
        }
    }
}
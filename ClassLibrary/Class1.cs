using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public static class Class1
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

        static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }

        public static Boolean isSquare(BigInteger n)
        {
            return (Sqrt(n) * Sqrt(n) == n);
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

        public static BigInteger[] encrypt(string plainText, BigInteger e, BigInteger n)
        {
            BigInteger[] textIntArray = Array.ConvertAll(Encoding.ASCII.GetBytes(plainText), x => (BigInteger)x);

            for(int i = 0; i < textIntArray.Length; i++)
            {
                Console.Write(textIntArray[i]);
                textIntArray[i] = BigInteger.ModPow(textIntArray[i], e, n);
            }
            Console.WriteLine();
            foreach (var x in textIntArray)
                Console.Write(x);
            Console.WriteLine();

            return textIntArray;
        }

        public static string decrypt(BigInteger[] encryptedArray, BigInteger d, BigInteger n)
        {
            BigInteger[] textIntArray = new BigInteger[encryptedArray.Length];
            string s = "";
            for (int i = 0; i < textIntArray.Length; i++)
            {
                s += Encoding.ASCII.GetString(BigInteger.ModPow(encryptedArray[i], d, n).ToByteArray());
            }
            return s;
        }


        public static void RSA()
        {
            Random rnd = new Random();
            BigInteger p, q;
            p = findPrimeNumber(1000);
            q = findPrimeNumber(2000);

            Console.WriteLine($"p = {p}\nq = {q}");

            BigInteger n = p * q;
            BigInteger phi = (p - 1) * (q - 1);
            Console.WriteLine($"phi = {phi}");
            BigInteger e = 0;
            while(BigInteger.GreatestCommonDivisor(e, phi) != 1)
            {
                e = rnd.Next(2, (int)phi);
            }
            Console.WriteLine($"e = {e}");
            BigInteger d = 2;
            do
            {
                d++;
            } while (e * d % phi != 1);
            Console.WriteLine($"d = {d}");

            BigInteger[] a = ClassLibrary.Class1.encrypt("ABCDE", e, n);
            string b = ClassLibrary.Class1.decrypt(a, d, n);
            Console.WriteLine(b);
        }
    }
}

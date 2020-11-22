using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using PrimeNumbers;

namespace RSAGenerator
{
    public static class RSA
    {
        

        public static Boolean isSquare(BigInteger n)
        {
            return (Prime.Sqrt(n) * Prime.Sqrt(n) == n);
        }


        public static BigInteger[] encrypt(string plainText, BigInteger e, BigInteger n)
        {
            BigInteger[] textIntArray = Array.ConvertAll(Encoding.ASCII.GetBytes(plainText), x => (BigInteger)x);

            for(int i = 0; i < textIntArray.Length; i++)
            {
                textIntArray[i] = BigInteger.ModPow(textIntArray[i], e, n);
            }

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


        public static void RSAGen(BigInteger p, BigInteger q, string plainText)
        {
            Random rnd = new Random();
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

            Console.WriteLine($"Plain text: {plainText}");
            BigInteger[] encryptedText = encrypt(plainText, e, n);

            Console.Write("Encrypted text: ");
            foreach (var x in encryptedText)
                Console.Write(x);
            Console.WriteLine();

            string decryptedText = decrypt(encryptedText, d, n);
            Console.WriteLine($"Deciphered text: {decryptedText}");
        }
    }
}

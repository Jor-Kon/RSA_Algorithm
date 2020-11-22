using System;
using System.Numerics;
using RSAGenerator;
using PrimeNumbers;

namespace RSA_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            BigInteger p, q;
            string plainText;
            p = Prime.findPrimeNumber(1000);
            q = Prime.findPrimeNumber(2000);
            Console.Write("Plain text: ");
            plainText = Console.ReadLine();
            RSA.RSAGen(p, q, plainText);
        }
    }
}

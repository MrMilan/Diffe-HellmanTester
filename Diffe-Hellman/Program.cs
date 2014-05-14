using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diffe_Hellman
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            ///prime number 
            int p = 13;
            ///base
            int g = 5;
            do
            {
                Console.WriteLine("Alice enter your secret number \"a\" (1 to 16)");
                a = ValidateReadNumber(Console.ReadLine());
            } while (a < 0 || a > 17);


            do
            {
                Console.WriteLine("Bob enter your secret number \"b\" (1 to 16)");
                b = ValidateReadNumber(Console.ReadLine());
            } while (b < 0 || b > 17);


        }

        public static int ValidateReadNumber(string valueNumber)
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(valueNumber);
            }
            catch (Exception exc)
            {

                throw new ArgumentException("Not valid input" + exc.Message);
            }

            return number;
        }

        public static int NumerateBigChar(int primeNumber, int gBase, int exponent)
        {
            return Convert.ToInt32(Math.Pow(gBase, exponent)) % primeNumber;
        }

        public static int NumerateSsecret(int primeNumber, int bigChar, int exponent)
        {
            return Convert.ToInt32(Math.Pow(bigChar, exponent)) % primeNumber;
        }
    }
}

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
            double privateA, privateB,publicA,publicB,secretA,secretB;
            ///prime number 
            int primeNumPub = 23;
            ///base
            int grupaNumPub = 5;
            Random rnd = new Random();

            int prim;
            
            do
            {
               prim= rnd.Next(1, 100);
                
            } while (IsItPrime(prim));
            do
            {
                Console.WriteLine("Alice enter your secret number \"a\" (1 to 16)-private key");
                privateA = ValidateReadNumber(Console.ReadLine());
            } while (privateA < 0 || privateA > 17);


            do
            {
                Console.WriteLine("Bob enter your secret number \"b\" (1 to 16)-private key");
                privateB= ValidateReadNumber(Console.ReadLine());
            } while (privateB < 0 || privateB > 17);
            Console.WriteLine("Exchange of public keys");
            publicA = NumeratePublicKey(primeNumPub, grupaNumPub, privateA);
            publicB = NumeratePublicKey(primeNumPub, grupaNumPub, privateB);
            Console.WriteLine("Alice get public key B = {0},Bob get public key A = {1}",publicB,publicA);
            secretA = NumerateSsecret(primeNumPub, publicB, privateA);
            secretB = NumerateSsecret(primeNumPub, publicA, privateB);
            Console.WriteLine("Secret of Alice {0} and secret Bob {1}",secretA,secretB);
            Console.ReadKey();

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

        public static double NumeratePublicKey(double primeNumber, double gBase, double exponentPrivateKey)
        {
            return Convert.ToDouble(Math.Pow(gBase, exponentPrivateKey)) % primeNumber;
        }

        public static double NumerateSsecret(double primeNumber, double publicKeyTheOthes, double myPrivateKey)
        {
            return Convert.ToDouble(Math.Pow(publicKeyTheOthes, myPrivateKey)) % primeNumber;
        }

        public static bool IsItPrime(int value)
        {
            for (int i = 2; i < value; i++)
            {
                if ((value % i) == 0)
                {
                    return false;
                }

            }
            return true;
        }

    }
}

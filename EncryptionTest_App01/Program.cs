using System;
using System.Text;
using System.Security.Cryptography;

namespace EncryptionTest_App01
{
    class Program
    {
        static void Main(string[] args)
        {
            String MasterPassword = "JonasF2003";

            long p = getPrimeNumber(0);
            long q = getPrimeNumber(p);

            var e = Hash(MasterPassword);
           // long e = Convert.ToInt64(ehash, 16);

            Console.WriteLine("e: " + e);
            Console.WriteLine("p: " + p);
            Console.WriteLine("q: " + q);

            Console.ReadLine();

        }
        static bool isPrime(long number)
        {
            bool isDevided = false;
            for (int i = 2; i<number && isDevided == false; i++)
            {
                if (number % i == 0)
                {
                    isDevided = true;
                }
            }
            if (number % number == 0 && number % 1 == 0 && isDevided == false)
            {
                Console.WriteLine("Primzahl gefunden juhu");
                return true;
            }
            else
            {
                return false;
            }
        }

        static long getPrimeNumber(long n)
        {
            bool isPrimeNumber = false;
            var characters = "123456789";
            var Charsarr = new char[16];
            var random = new Random();
            int trys = 1;

            while (isPrimeNumber == false)
            {
                Console.WriteLine("trys: " + trys);
                for (int i = 0; i < Charsarr.Length; i++)
                {
                    Charsarr[i] = characters[random.Next(characters.Length)];
                }
              
                var resultString = new String(Charsarr);
                var number = long.Parse(resultString);
                Console.WriteLine(number);
                
                if (number%2 == 1)
                {
                    if (isPrime(number))
                    {
                        if (number != n)
                        {
                            return number;
                        }
                    }
                }
                trys++;
            }
            return 0;
        }
        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}

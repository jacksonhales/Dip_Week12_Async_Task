using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            var task = FindPrimesAsync();

            Console.ReadLine();

        }

        public static async Task FindPrimesAsync()
        {
            var a = await FindPrime(250000);
            Console.WriteLine(DateTime.Now);
            var b = await FindPrime(400000);
            Console.WriteLine(DateTime.Now);

            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        public static async Task<long> FindPrime(int nthPrimeToFind)
        {
            long a = 2;
            int count = 0;

            while (count < nthPrimeToFind)
            {
                long b = 2;
                int prime = 1;// to check if found a prime

                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}

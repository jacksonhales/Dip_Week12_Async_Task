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

            Task<long> task1 = FindPrime(250000);
            Task<long> task2 = FindPrime(400000);
            
            Console.WriteLine(task1.Result);

            Console.WriteLine(task2.Result);

            Console.ReadLine();

        }

        public static async Task<long> FindPrime(int nthPrimeToFind)
        {
            var task = await Task.Run(() => FindPrimeSyncronous(nthPrimeToFind));
            Console.WriteLine(DateTime.Now);
            return task;
        }


        public static long FindPrimeSyncronous(int nthPrimeToFind)
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

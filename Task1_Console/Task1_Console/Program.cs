using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

            Thread task1 = new Thread(() => FindPrimeMultithreaded(250000));
            Thread task2 = new Thread(() => FindPrimeMultithreaded(400000));

            task1.Start();
            task2.Start();
                        
            /* ASYNC Example
            Task<long> task1 = FindPrime(250000);
            Task<long> task2 = FindPrime(400000);
            
            Console.WriteLine(task1.Result);

            Console.WriteLine(task2.Result);
            */

            Console.ReadLine();

        }

        public static void FindPrimeMultithreaded(int nthPrimeToFind)
        {
            long a = 2;
            int count = 0;

            while (count < nthPrimeToFind)
            {
                long b = 2;
                int prime = 1; // to check if found a prime

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
            Console.WriteLine(--a);
            Console.WriteLine(DateTime.Now);
        }

        public static async Task<long> FindPrime(int nthPrimeToFind)
        {
            var task = await Task.Run(() => FindPrimeSynchronous(nthPrimeToFind));
            Console.WriteLine(DateTime.Now);
            return task;
        }


        public static long FindPrimeSynchronous(int nthPrimeToFind)
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

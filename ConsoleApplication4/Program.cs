using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //EjercicioOriginal();
            Ejercicio1();
        }

        public static bool IsDivisibleByFive(int i)
        {
            Thread.SpinWait(2000000);
            return i % 5 == 0;
        }

        public static void EjercicioOriginal()
        {
            var sw = Stopwatch.StartNew();
            var numbers = Enumerable.Range(1, 1000);
            //var results = numbers.Where(IsDivisibleByFive);
            var results = numbers.AsParallel().Where(IsDivisibleByFive);

            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
            sw.Stop();

            Console.WriteLine("El tiempo transcurrido en ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("\nTerminado");
            Console.ReadKey(true);
        }

        public static void Ejercicio1()
        {
            Stopwatch sw = Stopwatch.StartNew();
            IEnumerable<int> numbers = Enumerable.Range(1, 1000);
            IEnumerable<int> results = numbers.Where(IsDivisibleByFive);

            var task = Task.Factory.StartNew(() => Ejercicio1_Metodo(results));

            Task.WaitAll(task);
            sw.Stop();

            Console.WriteLine("El tiempo transcurrido en ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("\nTerminado");
            Console.ReadKey(true);
        }

        public static void Ejercicio1_Metodo(IEnumerable<int> results)
        {
            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
        }

        public static void Ejercicio2()
        {
            var sw = Stopwatch.StartNew();
            var numbers = Enumerable.Range(1, 1000);
            var results = numbers.Where(IsDivisibleByFive);

            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
            sw.Stop();

            Console.WriteLine("El tiempo transcurrido en ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("\nTerminado");
            Console.ReadKey(true);
        }
    }
}

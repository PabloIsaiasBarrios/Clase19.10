using PCyP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static int value = 65;

        static void Main(string[] args)
        {
            //Utils.Start();
            //var Task1 = Task.Factory.StartNew(MetodoPar1);
            //var Task2 = Task.Factory.StartNew(MetodoImpar1);
            //Task.WaitAll(Task1, Task2);
            //Utils.Finish();
            //Console.ReadLine();

            Utils.Start();
            var Task1 = Task<int>.Factory.StartNew(MetodoPar2);
            var Task2 = Task<int>.Factory.StartNew(MetodoImpar2);
            Task.WaitAll(Task1, Task2);
            Console.WriteLine($"Task: {Task1.Id} imprimio el ultimo valor {Task1.Result} ({(char)Task1.Result})");
            Console.WriteLine($"Task: {Task2.Id} imprimio el ultimo valor {Task2.Result} ({(char)Task2.Result})");
            Utils.Finish();
            Console.ReadLine();
        }

        //public static void MetodoPar1()
        //{
        //    while (value < 91)
        //    {
        //        if (value % 2 == 0)
        //        {
        //            Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
        //            value++;
        //            Thread.SpinWait(1000000000);
        //        }
        //    }
        //}

        //public static void MetodoImpar1()
        //{
        //    while (value < 91)
        //    {
        //        if(value%2!=0)
        //        {
        //            Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
        //            value++;
        //            Thread.SpinWait(100000000);
        //        }
        //    }

        //}

        public static int MetodoPar2()
        {
            int ultimo_valor = 0;
            while (value < 91)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
                    ultimo_valor = value;
                    value++;
                    Thread.SpinWait(1000000000);
                }
            }
            return ultimo_valor;
        }

        public static int MetodoImpar2()
        {
            int ultimo_valor = 0;
            while (value < 91)
            {
                if (value % 2 != 0)
                {
                    Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
                    ultimo_valor = value;
                    value++;
                    Thread.SpinWait(100000000);
                }
            }
            return ultimo_valor;
        }
    }
}

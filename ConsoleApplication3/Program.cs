using PCyP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Abecedario Secuencial: ");
            Utils.Start();
            AbecedarioSecuencial();
            Utils.Finish();
            Console.WriteLine("Abecedario Paralelo");
            Utils.Start();
            AbecedarioParalelo();
            Utils.Finish();
            Console.ReadLine();
        }

        public static void AbecedarioSecuencial()
        {
            int value = 65;
            for(int i = 65; i< 91; i++)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
                    value++;
                    Thread.SpinWait(50000000);
                }

                else
                {
                    Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
                    value++;
                    Thread.SpinWait(50000000);
                }
            }
        }

        public static void AbecedarioParalelo()
        {
            object _locker = new object();
            int value = 65;
            Parallel.For(65, 91, i =>
            {
                if (value % 2 == 0)
                {
                    lock (_locker)
                    {
                        Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
                        value++;
                        Thread.SpinWait(50000000);
                    }
                }

                else
                {
                    lock (_locker)
                    {
                        Console.WriteLine("{0} - {1} - TMID: {2}", value, (char)value, Thread.CurrentThread.ManagedThreadId);
                        value++;
                        Thread.SpinWait(50000000);
                    }
                }
            }
            );
        }

    }
}

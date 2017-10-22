using PCyP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            NoParallelMethod();
            ParallelMethod();
        }

        public static void NoParallelMethod()
        {
            Utils.Start();
            for(int i = 0 ; i<16 ; i++)
            {
                Console.WriteLine(string.Format("TPID {0} - Valor: {1}", Thread.CurrentThread.ManagedThreadId, i));
                Utils.SpinWait();
            }
            Utils.Finish();
        }

        public static void ParallelMethod()
        {
            Utils.Start();
            Parallel.For(1, 16, i =>
            {
                Console.WriteLine(string.Format("TPID {0} - Valor: {1}", Thread.CurrentThread.ManagedThreadId, i));
                Utils.SpinWait();
            }
            );
            Utils.Finish();
        }
    }
}

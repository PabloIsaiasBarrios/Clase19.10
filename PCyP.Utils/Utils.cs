using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCyP.Utils
{
    public class Utils
    {
        private static Stopwatch stopWatch;
        private static int value = 64;

        public static void SpinWait()
        {
            Thread.SpinWait(800000000);
        }

        public static void Start()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public static void Finish()
        {
            TimeSpan ts = stopWatch.Elapsed;
            stopWatch.Stop();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public static int ReturnNumber()
        {
            value++;
            return value;
        }
    }
}

using System;
using System.Threading;

namespace OutTesting
{/// <summary>
/// create two threads to method with out parameter
/// and Checks what is passing
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int outVar = 10;
            OutExample OutEx = new OutExample();
            Thread firstThread = new Thread(() => OutEx.CheckOut(out outVar));
            firstThread.Start();
            Console.WriteLine(outVar);
            Thread secondThread = new Thread(() => OutEx.CheckOut(out outVar));
            secondThread.Start();
            Console.ReadLine();
        }
    }
    class OutExample
    {
        public void CheckOut(out int outVar)
        {
            Thread.Sleep(1000);
            outVar = 20;
            Console.WriteLine(outVar);
        }
    }
}

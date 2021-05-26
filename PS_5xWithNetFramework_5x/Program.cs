using System;
using System.Threading;

namespace PS_5x_WithNET_Framework
{
    class Program
    {        
        static void Main(string[] args)
        {
            Worker worker = new Worker("PS1_ToExecute.ps1");
            Thread thread = new Thread(worker.DoWork);
            thread.IsBackground = true;
            thread.Start();

            while (true)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.C && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    worker.KeepGoing = false;
                    break;
                }
            }
            thread.Join();
        }
    }
}
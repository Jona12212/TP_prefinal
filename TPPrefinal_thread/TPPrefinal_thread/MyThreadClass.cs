using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TPPrefinal_thread
{
    internal class MyThreadClass
    {
        public static void Thread1()
        {
            for (int i = 1; i <= 2; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + i);
                Thread.Sleep(500); 
            }
            Console.WriteLine($"The thread {Thread.CurrentThread.ManagedThreadId} has exited with code 0 (0x0).");
        }

        public static void Thread2()
        {
            for (int i = 1; i <= 6; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + i);
                Thread.Sleep(1500); 
            } 
            Console.WriteLine($"The thread {Thread.CurrentThread.ManagedThreadId} has exited with code 0 (0x0).");
        }
       

    }

}

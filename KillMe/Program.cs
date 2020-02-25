using System;
using System.Diagnostics;
using System.Threading;

namespace Threadster
{
    class Program
    {
        static int count = 0;
        static object _lock = new object();
        static void Main(string[] args)
        {
            Thread hashTagWriter= new Thread(Write);
            Thread starWriter = new Thread(Write);
            starWriter.Start('*');
            hashTagWriter.Start('#');
            
        }
       

        static void Write(object output)
        {
            char write = (char)output;
            while (true)
            {

                lock (_lock)
                {
                    count += 60;
                    for (int i = 0; i < 60; i++)
                    {

                        Console.Write(output);
                    }

                    Console.Write(count + "\n");
                    Thread.Sleep(500);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace brainfucksharp
{
    class Program
    {
        static void Main(string[] args)
        {
            String program;
            Stopwatch timer = new Stopwatch();
            Boolean debugging = false;

            if (args[0] == "-debug")
            {
                debugging = true;
                program = File.ReadAllText(args[1]);
                timer.Start();
            }
            else
            {
                program = File.ReadAllText(args[0]);
            }

            Interpreter i = new Interpreter(program);


            if (debugging)
            {
                timer.Stop();
                Console.WriteLine("\n\n{0} took {1}ms to run", args[1], timer.ElapsedMilliseconds);
            }
            Console.ReadKey();
        }
    }
}

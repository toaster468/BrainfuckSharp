using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brainfucksharp
{
    class Interpreter
    {
        int stackpointer;
        int instructionpointer;
        public Byte[] Memory;
        public string Program;

        public Interpreter(String program)
        {
            stackpointer = 0;
            instructionpointer = 0;
            Memory = new Byte[30000];
            Program = program;
            Run();
        }

        public void Run()
        {
            while(true)
            {
                char op;

                if (instructionpointer >= Program.Length)
                    op = '0';
                else
                    op = Program.ToCharArray()[instructionpointer];

                Step(op);
            }
        }

        public void Step(Char c)
        {
            switch (c)
            {
                case '>':
                    stackpointer++;
                    break;
                case '<':
                    stackpointer--;
                    break;
                case '+':
                    Memory[stackpointer]++;
                    break;
                case '-':
                    Memory[stackpointer]--;
                    break;
                case '.':
                    Console.Write((char)Memory[stackpointer]);
                    break;
                case ',':
                    Memory[stackpointer] = (Byte)Console.ReadKey().KeyChar;
                    break;
                case '[':
                    if(Memory[stackpointer] == 0)
                        instructionpointer = findnext();
                    break;
                case ']':
                    if(Memory[stackpointer] != 0)
                        instructionpointer = findprev();
                    break;
                default:
                    break;
            }

            instructionpointer++;
        }

        public void Halt()
        {
            while (true) ;
        }

        public int findnext()
        {
            int i = instructionpointer;
            char[] p = Program.ToCharArray();

            while (p[i] != ']')
            {
                i++;
            }

            return i;
        }

        public int findprev()
        {
            int i = instructionpointer;
            char[] p = Program.ToCharArray();

            while (p[i] != '[')
            {
                i--;
            }

            return i;
        }
    }
}

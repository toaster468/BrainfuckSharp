/*
 * Testing Git 
 */

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
        Boolean Halted;

        public Interpreter(String program)
        {
            stackpointer = 0;
            instructionpointer = 0;
            Memory = new Byte[30000];
            Program = program;
            Halted = false;
            Run();
        }

        void Run()
        {
            while(!Halted)
            {
                char op;

                if (instructionpointer >= Program.Length)
                {
                    Halted = true;
                    continue;
                }
                else
                    op = Program[instructionpointer];

                Step(op);
            }
        }

        void Step(Char c)
        {
            switch (c)
            {
                case '>':
                    ++stackpointer;
                    break;
                case '<':
                    --stackpointer;
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
                    if (Memory[stackpointer] == 0)
                        instructionpointer = FindMatchingClose();
                    break;
                case ']':
                    if (Memory[stackpointer] != 0)
                        instructionpointer = FindMatchingOpen();
                    break;
                default:
                    break;
            }

            instructionpointer++;
        }

        int FindMatchingClose()
        {
            int i = instructionpointer + 1;
            int count = 1;

            while (count > 0)
            {
                if (Program[i] == ']')
                {
                    count--;
                }
                else if (Program[i] == '[')
                {
                    count++;
                }

                i++;
            }
            
            return i - 1;
        }

        int FindMatchingOpen()
        {
            int i = instructionpointer - 1;
            int count = 1;

            while (count > 0)
            {
                if (Program[i] == ']')
                {
                    count++;
                }
                else if (Program[i] == '[')
                {
                    count--;
                }

                i--;
            }

            return i + 1;
        }
    }
}

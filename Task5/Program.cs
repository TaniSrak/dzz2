using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mathWord = Console.ReadLine();
            string[] operand = mathWord.Split(' ');
            if (operand.Length == 3 )
            {
                int a = 0, b = 0, result = 0;
                if (int.TryParse(operand[0], out a) && int.TryParse(operand[2], out b))
                {
                    switch(operand[1])
                    {
                        case "+":
                            result = a + b; break;
                        case "-":
                            result = a - b; break;
                        default:
                            break;
                    }
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("а и/или б не является числом");
                }
            }
            else
            {
                Console.WriteLine("Некорректное выражение");
            }
            Console.ReadKey();
        }

    }
}

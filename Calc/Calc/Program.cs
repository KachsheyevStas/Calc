using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите выражение:");
            string InputData = Console.ReadLine();
            Poliz str = new Poliz();
            str.input = InputData;
           // Console.WriteLine(str.input);
            str.ConvertToPostfixNotation(InputData);
            Console.Write("Результат:");
            Console.WriteLine(str.result(str.input));
            Console.ReadKey();
        }
    }
}


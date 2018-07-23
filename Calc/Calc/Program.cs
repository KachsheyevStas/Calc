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
            /*  Console.Write("Введите выражение:");
              string InputData = Console.ReadLine();
              Poliz str = new Poliz
              {
                  input = InputData
              };
              // Console.WriteLine(str.input);
              // str.ConvertToPostfixNotation(InputData);
              Console.Write("Результат:");
              Console.WriteLine(str.Result(str.input));
              Console.ReadKey();*/
            Console.Write("Введите выражение: "); //Предлагаем ввести выражение
            Console.WriteLine(Poliz.Calculate(Console.ReadLine())); //Считываем, и выводим результат
        }
    }
}


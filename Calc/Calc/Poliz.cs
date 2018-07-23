using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class Poliz
    {
       /* public Poliz()
        {
            operators = operators = new List<string>(standart_operators);
        }
        public string input;
        private List<string> operators;
        private List<string> standart_operators =
        new List<string>(new string[] {  "+", "-", "*", "/", "(", ")", });
        public IEnumerable<string> Separate(string input)
        {
            int pos = 0;
            input.Replace(',', '.');
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!operators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s += input[i];
                    else if (input[pos] == '.')
                         for (int i = pos + 1; i < input.Length && (Char.IsLetter(input[i])); i++)
                            s += input[i];
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }
        private byte GetPriority(string s)
    {
                switch (s)
                {
                    case "(":
                    case ")":
                        return 0;
                    case "+":
                    case "-":
                        return 1;
                    case "*":
                    case "/":
                        return 2;
                    default:
                        return 3;
                }
            }
        public string[] ConvertToPostfixNotation(string input)
            {
                List<string> outputSeparated = new List<string>();
                Stack<string> stack = new Stack<string>();
                foreach (string c in Separate(input))
                {
                    if (operators.Contains(c))
                    {
                        if (stack.Count > 0 && !c.Equals("("))
                        {
                            if (c.Equals(")"))
                            {
                                string s = stack.Pop();
                                while (s != "(")
                                {
                                    outputSeparated.Add(s);
                                    s = stack.Pop();
                                }
                            }
                            else if (GetPriority(c) > GetPriority(stack.Peek()))
                                stack.Push(c);
                            else
                            {
                                while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                                    outputSeparated.Add(stack.Pop());
                                stack.Push(c);
                            }
                        }
                        else
                            stack.Push(c);
                    }
                    else
                        outputSeparated.Add(c);
                }
                if (stack.Count > 0)
                    foreach (string c in stack)
                        outputSeparated.Add(c);

                return outputSeparated.ToArray();
            }
        public double Result(string input)
            {
                Stack<string> stack = new Stack<string>();
                Queue<string> queue = new Queue<string>(ConvertToPostfixNotation(input));
                string str = queue.Dequeue();
                while (queue.Count >= 0)
                {
                    if (!operators.Contains(str))
                    {
                        stack.Push(str);
                        str = queue.Dequeue();
                    }
                    else
                    {
                        double summ = 0;
                        try
                        {
                            switch (str)
                            {
                                case "+":
                                    {
                                        double a = Convert.ToDouble(stack.Pop());
                                        double b = Convert.ToDouble(stack.Pop());
                                        summ = a + b;
                                        break;
                                    }
                                case "-":
                                    {
                                        double a = Convert.ToDouble(stack.Pop());
                                        double b = Convert.ToDouble(stack.Pop());
                                        summ = b - a;
                                        break;
                                    }
                                case "*":
                                    {
                                        double a = Convert.ToDouble(stack.Pop());
                                        double b = Convert.ToDouble(stack.Pop());
                                        summ = b * a;
                                        break;
                                    }
                                case "/":
                                    {
                                        double a = Convert.ToDouble(stack.Pop());
                                        double b = Convert.ToDouble(stack.Pop());
                                        summ = b / a;
                                        break;
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                        Console.WriteLine(ex);
                        }
                        stack.Push(summ.ToString());
                        if (queue.Count > 0)
                            str = queue.Dequeue();
                        else
                            break;
                }

            }
            return Convert.ToDouble(stack.Pop());
        }*/
//Метод возвращает true, если проверяемый символ - разделитель("пробел" или "равно")
static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }

       
//Метод возвращает true, если проверяемый символ - оператор
static private bool IsOperator(char с)
        {
            if (("+-/*()".IndexOf(с) != -1))
                return true;
            return false;
        }

     
//Метод возвращает приоритет оператора
static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                default: return 5;
            }
        }


 
//"Входной" метод класса
static public double Calculate(string input)
        {
            string output = GetExpression(input); //Преобразовываем выражение в постфиксную запись
            double result = Counting(output); //Решаем полученное выражение
            return result; //Возвращаем результат
        }
        
static public string GetExpression(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                //Разделители пропускаем
                if (IsDelimeter(input[i]))
                    continue; //Переходим к следующему символу

                //Если символ - цифра, то считываем все число
                if (Char.IsDigit(input[i]) || input[i] == '.') //Если цифра
                {
                   
                    //Читаем до разделителя или оператора, что бы получить число
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        i++; //Переходим к следующему символу
                        if (input[i] == '.')
                        {
                           
                        }
                        if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                    }

                    output += " "; //Дописываем после числа пробел в строку с выражением
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }

                //Если символ - оператор
                if (IsOperator(input[i])) //Если оператор
                {
                    if (input[i] == '(') //Если символ - открывающая скобка
                        operStack.Push(input[i]); //Записываем её в стек
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0) //Если в стеке есть элементы
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                        operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

                    }
                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output; //Возвращаем выражение в постфиксной записи
        }

       
static private double Counting(string input)
        {
            double result = 0; //Результат
            Stack<double> temp = new Stack<double>(); //Dhtvtyysq стек для решения

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]) || input[i] == '.')
                {
                    string a = string.Empty;
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }
    }
    
}
   



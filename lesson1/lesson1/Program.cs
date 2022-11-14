using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте вас приветствует математическая программа");
            Console.WriteLine("пажалуйста введите число. ");

            String Number = Console.ReadLine();

            if (Number == "q")
            {
                return;
            }

            if(!ParseStrToPositiveInt(Number,out int IntNumber))
            {
                Console.ReadLine();
                return;
            }

            int Factorial = GetFactorial(IntNumber);
            int Sum = GetSum(1,IntNumber);
            int MaxEvenNumber = IntNumber / 2*2;
            
            Console.WriteLine("Факториал равет " + Factorial);
            Console.WriteLine("Сума от 1 до N равна " + Sum);
            Console.WriteLine("максимальное четное число меньше N равно " + MaxEvenNumber);
            Console.ReadLine();
        }

        static int GetFactorial(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial = factorial * i;

            }
            return factorial;
        }

        static int GetSum(int begin, int end)
        {
            int sum = 0;
            for (int i = begin; i <= end; i++)
            {
                sum = sum + i;

            }
            return sum;
        }

        static bool ParseStrToPositiveInt(string str,out int number)
        {
            try
            {
                number = Int32.Parse(str);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Входная строка имела неверный формат");
                number = default;
                return false;
            }

            if (number < 0)
            {
                Console.WriteLine("Вы ввели отрицательное число");
                return false;
            }

            return true;
        }
    }
}

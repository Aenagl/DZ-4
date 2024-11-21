using System;

namespace Labs
{
    internal class Program
    {
        /*Упражнение 5.1 Написать метод, возвращающий наибольшее из двух
        чисел.Входные параметры метода – два целых числа.Протестировать метод.*/
        public static int MaxNum(int a, int b)
        {
            return (a > b) ? a : b;
        }

        /*Упражнение 5.2 Написать метод, который меняет местами значения двух передаваемых
        параметров.Параметры передавать по ссылке.Протестировать метод.*/
        public static void Change(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        /*Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений
        передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
        если в процессе вычисления возникло переполнение, то вернуть значение false. Для
        отслеживания переполнения значения использовать блок checked.*/
        static bool Factorial(int n, out long result)
        {
            result = 1;

            if (n < 0)
            {
                return false;
            }

            try
            {
                for (int i = 1; i <= n; i++)
                {
                    result = checked(result * i);
                }
            }
            catch (OverflowException)
            {
                return false; // Если произошло переполнение
            }

            return true;
        }
        //Задание 5.4 Написать рекурсивный метод вычисления факториала числа.
        static long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Факториал не определен для отрицательных чисел.");
            }

            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Тест 1.");
            Console.WriteLine("Входные данные: 4 и 7");
            Console.WriteLine($"Наибольшее число: {MaxNum(4, 7)}");

            Console.WriteLine("Тест 2.");
            int a = 6; int b = 7;
            Console.WriteLine($"До вызова метода: a = {a} / b = {b} ");
            Change(ref a, ref b);
            Console.WriteLine($"После вызова метода: a = {a} / b ={b}");

            Console.WriteLine("Тест 3.");
            long result;

            if (Factorial(5, out result))
            {
                Console.WriteLine("Факториал 5 равен: " + result);
            }
            else
            {
                Console.WriteLine("Ошибка вычисления факториала 5!");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Matrix
{
    /// <summary>
    /// Класс работы с пользователем
    /// </summary>
    public static class Input
    {
        public static bool YesOrNoAsk(string text)
        {
            Console.WriteLine(text);
            char answer = Console.ReadKey(true).KeyChar;
            if (answer.ToString().ToLower() == "y")
            {
                return true;
            }
            return false;
        }
        public static int GetUserNumber()
        {
            bool answerCheckout = int.TryParse(Console.ReadLine(), out int answer);
            if (answerCheckout)
                return answer;
            throw new ArgumentException("Не верный ввод");
        }
        public static int MainMenu()
        {
            Console.WriteLine("Здравствуйте, Вы хотите:");
            Console.WriteLine("1 - Создать и просуммировать матрицы.");
            Console.WriteLine("2 - Создать и перемножить матрицы.");
            Console.WriteLine("3 - Умножить матрицу на вектор.");
            return GetUserNumber();
        }
        public static int GetRowsCount()
        {
            Console.WriteLine("Введите количество строк");
            return GetUserNumber();
        }

        public static int GetColumnsCount()
        {
            Console.WriteLine("Введите количество столбцов");
            return GetUserNumber();
        }
        public static int MatrixCreateVariant()
        {
            Console.WriteLine("Вы хотите:");
            Console.WriteLine("1 - Создать случайную матрицу");
            Console.WriteLine("2 - Ввести матрицу вручную");
            Console.WriteLine("3 - Получить матрицу из файла Matrix.txt");
            return GetUserNumber();
        }
        public static int GetMatrixElements(int number)
        {
            Console.WriteLine($"Введите элемент {number}");
            return GetUserNumber();
        }
        public static int GetVectorSize()
        {
            Console.WriteLine($"Введите размерность вектора ");
            return GetUserNumber();
        }
    }
}

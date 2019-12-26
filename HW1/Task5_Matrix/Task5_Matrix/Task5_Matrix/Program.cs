using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Matrix
{
    /// <summary>
    /// Основной класс
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            ///Создаем экземпляры классов для работы с матрицами и пользовательским вводом
            Matrix matrix = new Matrix();
            Input userInput = new Input();

            ///Спрашиваем нужно ли создавать первую матрицу 
            bool answer = userInput.GetUserInput();
            var column1 = userInput.Row;
            var row1 = userInput.Column;
            var firstMatrix = matrix.CreateMatrix(column1, row1, answer);
            ///Спрашиваем нужно ли создавать вторум матрицу 
            bool answer2 = userInput.GetUserInput();
            var column2 = userInput.Row;
            var row2 = userInput.Column;
            var secondMatrix = matrix.CreateMatrix(column2, row2, answer2);
            ///Нужо ли просуммировать созданные матрицы
            userInput.DoYouWantSum();
            matrix.SumMatrix(firstMatrix, secondMatrix, column1, row1, column2, row2);

            /// Нужно ли перемножать созданные матрицы
            userInput.DoYouWantMult();
            matrix.MultiplicateMatrix(firstMatrix, secondMatrix, column1, row1, column2, row2);


            Console.ReadKey();
        }

    }
    /// <summary>
    /// Класс для работы с матрицами
    /// </summary>
    /// <param name="column1">Количество строк</param>
    /// <param name="row1">Количество столбцов</param>
    class Matrix
    {
        /// <summary>
        /// Метод для генерирования матрицы
        /// </summary>
        /// <param name="column1">Количество колонок матрицы</param>
        /// <param name="row1">Количество строк матрицы</param>
        /// <param name="answer">Создавать ли матрицу True/False</param>
        /// <returns>Возвращает двумерный массив заполненый целыми
        /// числами от 0 до 99</returns>
        public int[,] CreateMatrix(int column1, int row1, bool answer)
        {
            if (answer)
            {
                try
                {
                    Random randomizer = new Random();
                    if (column1 > 0 && row1 > 0)
                    {
                        int[,] newMatrix = new int[column1, row1];
                        for (int i = 0; i < column1; i++)
                        {
                            for (int j = 0; j < row1; j++)
                            {
                                newMatrix[i, j] = randomizer.Next(0, 99);
                                Console.Write("{0}\t", newMatrix[i, j]);
                            }
                            Console.WriteLine();
                        }
                        return newMatrix;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Метод сложения двух соразмерных матриц
        /// </summary>
        /// <param name="firstMatrix">Первая матрица</param>
        /// <param name="secondMatrix">Вторая матрица</param>
        /// <param name="column1">Количество колонок первой матрицы</param>
        /// <param name="row1">Количество строк первой матрицы</param>
        /// <param name="column2">Количество колонок второй матрицы</param>
        /// <param name="row2">Количество строк первой матрицы</param>
        /// <returns>Возвращает сумму двух матриц</returns>
        public int[,] SumMatrix(int[,] firstMatrix, int[,] secondMatrix, int column1, int row1, int column2, int row2)
        {
            try
            {
                if (column1 == column2 && row1 == row2)  ///Соразмерны ли данные матрицы?
                {
                    Console.WriteLine("Размерность массивов одинакова");
                    int[,] summedMartix = new int[column1, row1];
                    for (int i = 0; i < row1; i++)
                    {
                        for (int j = 0; j < column1; j++)
                        {
                            summedMartix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                            Console.Write("{0}\t", summedMartix[i, j]);
                        }
                        Console.WriteLine();
                    }

                    return summedMartix;
                }
                else
                {
                    Console.WriteLine("Размерность массивов НЕ позволяет сложение");
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("\n Для сложения нужны две матрицы одинаковых размерностей");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Метод для умножения двух ранее созданным матриц, 
        /// если их размерности подходят для этого
        /// </summary>
        /// <param name="firstMatrix">Первая матрица</param>
        /// <param name="secondMatrix">Вторая матрица</param>
        /// <param name="column1">Количество колонок первой матрицы</param>
        /// <param name="row1">Количество строк первой матрицы</param>
        /// <param name="column2">Количество колонок второй матрицы</param>
        /// <param name="row2">Количество колонок второй матрицы</param>
        /// <returns>Возвращает произведение двух матриц</returns>
        public int[,] MultiplicateMatrix(int[,] firstMatrix, int[,] secondMatrix, int column1, int row1, int column2, int row2)
        {

            if (column1 == row2)  ///Возможно ли перемножить данные матрицы?
            {
                Console.WriteLine("Размерность массивов позволяет умножение");
                int[,] result = new int[row1, column2];
                for (int r = 0; r < row1; ++r)
                {
                    for (int c = 0; c < column2; ++c)
                    {
                        int s = 0;
                        for (int z = 0; z < column1; ++z)
                            s += firstMatrix[r, z] * secondMatrix[z, c];
                        Console.Write(s + "\t");
                        result[r, c] = s;

                    }
                    Console.WriteLine();

                }

                return result;
            }
            else
            {
                Console.WriteLine("Размерность массивов НЕ позволяет умножение");
                return null;
            }

        }

    }
    /// <summary>
    /// Класс работы с пользователем
    /// </summary>
    class Input
    {
        private int row;
        private int column1;
        /// <summary>
        /// Спрашиваем нужно ли сгенерировать новую матрицу
        /// </summary>
        /// <returns>Ответ пользователя True/False</returns>
        public bool GetUserInput()
        {
            Console.WriteLine("\n Добавить новую матрицу? (y/n)");
            char answer = Console.ReadKey(true).KeyChar;
            if (answer == 'y')
            {
                try
                {
                    Console.WriteLine("\n Введите количество строк");
                    row = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n Введите количество столбцов");
                    column1 = int.Parse(Console.ReadLine());
                    return true;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Спрашиваем у пользователя 
        /// Складывать ли созданные матрицы
        /// </summary>
        /// <returns>Ответ пользователя True/False</returns>
        public bool DoYouWantSum()
        {
            Console.WriteLine("\n Хотите сложить полученные матрицы? (y/n)");
            char answer = Console.ReadKey(true).KeyChar;
            if (answer == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Спрашиваем у пользователя 
        /// Перемножать ли созданные матрицы
        /// </summary>
        /// <returns>Ответ пользователя True/False</returns>
        public bool DoYouWantMult()
        {
            Console.WriteLine("\n Хотите перемножить полученные матрицы? (y/n)");
            char answer = Console.ReadKey(true).KeyChar;
            if (answer == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Свойства для работы с размерностями матрицы
        /// </summary>
        public int Row
        {
            get
            {
                return row;
            }
        }
        public int Column
        {
            get
            {
                return column1;
            }
        }
    }
}


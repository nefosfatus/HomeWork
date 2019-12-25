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
            Matrix matrix = new Matrix();
            Input userInput = new Input();

            bool answer = userInput.GetUserInput();
            var m = userInput.M;
            var n = userInput.N;
            var firstMatrix = matrix.CreateMatrix(m, n, answer);

            bool answer2 = userInput.GetUserInput();
            var m2 = userInput.M;
            var n2 = userInput.N;
            var secondMatrix = matrix.CreateMatrix(m2, n2, answer2);
            _ = userInput.DoYouWantSum();
            _ = matrix.SumMatrix(firstMatrix, secondMatrix, m, n, m2, n2);
            _ =  matrix.MultiplicateMatrix(firstMatrix, secondMatrix, m, n, m2, n2);

            Console.ReadKey();
        }

    }
    /// <summary>
    /// Класс для работы с матрицами
    /// </summary>
    /// <param name="m">Количество строк</param>
    /// <param name="n">Количество столбцов</param>
    class Matrix
    {
        public int[,] CreateMatrix(int m, int n, bool answer)
        {
            if (answer)
            {
                try
                {
                    Random randomizer = new Random();
                    if (m > 0 && n > 0)
                    {
                        int[,] NewMatrix = new int[m, n];
                        for (int i = 0; i < m; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                NewMatrix[i, j] = randomizer.Next(0, 99);
                                Console.Write("{0}\t", NewMatrix[i, j]);
                            }
                            Console.WriteLine();
                        }
                        return NewMatrix;
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
        public int[,] SumMatrix(int[,] firstMatrix, int[,] secondMatrix, int m, int n, int m2, int n2)
        {
            try
            {
                if (m == m2 && n == n2)
                {
                    Console.WriteLine("Размерность массивов одинакова");
                    int[,] SummedMartix = new int[m, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            SummedMartix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                            Console.Write("{0}\t", SummedMartix[i, j]);
                        }
                        Console.WriteLine();
                    }

                    return SummedMartix;
                }
                else
                {
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

        public int[,] MultiplicateMatrix(int[,] firstMatrix, int[,] secondMatrix, int m, int n, int m2, int n2)
        {
           
            if (m == n2)
            {
              
                int[,] multipledMartix = new int[n, m2];
                for (int i = 0; i < n2; i++)
                {
                    for (int j = 0; j < multipledMartix.Length; j++)
                    {
                        multipledMartix[i, j] = 0;
                        for (int k = 0; k < m; k++)
                            multipledMartix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                        Console.Write("{0}\t", multipledMartix[i, j]);
                    }
                    Console.WriteLine();
                }
                return multipledMartix;
            }
            else
            {
                return null;
            }

        }

    }
    class Input
    {
        private int row;
        private int column;
        public bool GetUserInput()
        {
            Console.WriteLine("\n Добавить новую матрицу? (y/n)");
            char answer = Console.ReadKey(true).KeyChar;
            if (answer == 'y')
            {
                Console.WriteLine("\n Введите количество строк");
                row = int.Parse(Console.ReadLine());
                Console.WriteLine("\n Введите количество столбцов");
                column = int.Parse(Console.ReadLine());
                return true;
            }
            else
            {
                return false;
            }

        }
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
        public int M
        {
            get
            {
                return row;
            }
        }
        public int N
        {
            get
            {
                return column;
            }
        }
    }
}
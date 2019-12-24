using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Input_From_File_Formating
{
    class Program
    {
        /// <summary>
        /// Основной класс
        /// </summary>

        static void Main(string[] args)
        {
            Input input = new Input();
            ConsoleOutput consoleOutput = new ConsoleOutput();
            while (true)
            {
                List<string> ValuesFromFile = input.GetInputValuesFromFile();
                foreach(var line in ValuesFromFile)
                {
                    string[] Coordinates = input.SplitValues(line);
					decimal x = decimal.Parse(Coordinates[0], CultureInfo.InvariantCulture);
					decimal y = decimal.Parse(Coordinates[1], CultureInfo.InvariantCulture);
					consoleOutput.PrintCoordinates(x, y);
                }
                Console.ReadKey();
            }
            
        }
    }
    /// <summary>
    /// Класс работающий со входными данными.
    /// </summary>
    class Input
    {
		private decimal x;
		private decimal y;
        /// <summary>
        /// Метод работает с данными из консоли разбивает строку на части по запятой
        /// и сохраняет части в ранее объявленных переменных х,у
        /// </summary>
        /// <exception cref="Exception">
        /// Отлавливает и выводит в консоль любые исключения
        /// </exception>

		public void GetInputValues()
		{
			Console.WriteLine("Пожалуйста введите координаты");
			string Value = Console.ReadLine();
			try
			{
				string[] SplittedValues = Value.Split(',');
				var ss = SplittedValues[0];
				var sd = SplittedValues[1];

				x = decimal.Parse(SplittedValues[0], CultureInfo.InvariantCulture);
				y = decimal.Parse(SplittedValues[1], CultureInfo.InvariantCulture);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Введите оба ЧИСЛОВЫХ значения\n");
				Console.WriteLine(ex.Message);
			}
		}

        /// <summary>
        /// Метод работает с данными из файла 
        /// </summary>
        /// <exception cref="Exception">
        /// Отлавливает и выводит в консоль любые исключения
        /// </exception>
        /// <returns> Возвращает строки в списке lines</returns>
        public List<string> GetInputValuesFromFile()
        {
            Console.WriteLine("Считываем данные из файла");
            List<string> lines = new List<string>();
            FileStream file = new FileStream("Input.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            try
            {
                while (!readFile.EndOfStream)
                {
                    lines.Add(readFile.ReadLine());
                }
                readFile.Close();
                Console.WriteLine("Данные считаны");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return lines;

        }

        /// <summary>
        /// Метод работает со строками и разбивает их на части
        /// и сохраняет части в ранее объявленных переменных х,у
        /// </summary>
        /// <exception cref="Exception">
        /// Отлавливает и выводит в консоль любые исключения
        /// </exception>
        /// <param name="line"> Принимает строки из листа lines</param>
        public string[] SplitValues(string line)
        {
            
            try
            {
                string[] SplittedValues = line.Split(',');
                
                return SplittedValues;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Введите верный формат чисел, 1 строка - 1 пара\n");
                Console.WriteLine(ex.Message);
                string[] Nothing = null;
                return Nothing;
            }

            
        }
        /// <summary>
        /// Параметры для получения доступа к приватным переменным
        /// </summary>
        /// <param name="X_Value"> Координата оси Х</param>
        /// <param name="Y_Value"> Координата оси Y</param>

        public decimal X_Value
        {
            get { return x; }
        }
        public decimal Y_Value
        {
            get { return y; }
        }
   
    }
    /// <summary>
    /// Класс для работы с выводом консоли
    /// </summary>
    /// <param name="x">Координата Х</param>
    /// <param name="y">Координата Y</param>

    class ConsoleOutput
    {
		public void PrintCoordinates(decimal x, decimal y)
		{
			string ForPrint = string.Format("X:{0:N6} Y:{1:N6}", x, y);
			Console.WriteLine(ForPrint);
			
		}

	}

}

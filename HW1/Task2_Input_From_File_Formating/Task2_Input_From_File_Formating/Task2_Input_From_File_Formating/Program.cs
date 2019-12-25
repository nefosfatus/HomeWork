using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Saver saver = new Saver();
            while (true)
            {
                List<string> ValuesFromFile = input.GetInputValuesFromFile();
                foreach(var line in ValuesFromFile)
                {
                    string[] Coordinates = input.SplitValues(line);
					decimal _x = decimal.Parse(Coordinates[0], CultureInfo.InvariantCulture);
					decimal _y = decimal.Parse(Coordinates[1], CultureInfo.InvariantCulture);
					string coordinatesLine = consoleOutput.PrintCoordinates(_x, _y);
                    saver.SaveStringInFile(coordinatesLine);
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
		private decimal _x;
		private decimal _y;
        /// <summary>
        /// Метод работает с данными из консоли разбивает строку на части по запятой
        /// и сохраняет части в ранее объявленных переменных х,у
        /// </summary>
        /// <exception cref="FormatException">
        /// Отлавливает и выводит в консоль исключения
        /// При неверном формате входных данных
        /// </exception>

        public void GetInputValues()
		{
			Console.WriteLine("Пожалуйста введите координаты");
			string Value = Console.ReadLine();
			try
			{
				string[] SplittedValues = Value.Split(',');
				_x = decimal.Parse(SplittedValues[0], CultureInfo.InvariantCulture);
				_y = decimal.Parse(SplittedValues[1], CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				Console.WriteLine("Введите оба ЧИСЛОВЫХ значения\n");
                throw new FormatException("Неверный формат входных данных");
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
            
            try
            {
                FileStream file = new FileStream("Input.txt", FileMode.Open);
                StreamReader readFile = new StreamReader(file);
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
                throw new IOException("Файл не найден");
                throw new FormatException("Формат данных в файле не верный");
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
                return null;
            }

            
        }
        /// <summary>
        /// Параметры для получения доступа к приватным переменным
        /// </summary>
        /// <param name="ValueX"> Координата оси Х</param>
        /// <param name="ValueY"> Координата оси Y</param>

        public decimal ValueX
        {
            get { return _x; }
        }
        public decimal ValueY
        {
            get { return _y; }
        }
   
    }
    /// <summary>
    /// Класс для работы с выводом консоли
    /// </summary>
    /// <param name="_x">Координата Х</param>
    /// <param name="_y">Координата Y</param>

    class ConsoleOutput
    {
		public string PrintCoordinates(decimal x, decimal y)
		{
			string ForPrint = string.Format("X:{0:N6} Y:{1:N6}", x, y);
			Console.WriteLine(ForPrint);
            return ForPrint;
			
		}

	}

    /// <summary>
    /// Класс для сохранения отформатированных данных в файл
    /// </summary>
    /// <exception cref="Exception">
    /// Отлавливает и выводит в консоль любые исключения
    /// </exception>
    class Saver
    {
        public void SaveStringInFile(string lines)
        {
            try
            {
                File.AppendAllText("Output.txt", lines+Environment.NewLine);
                Console.WriteLine("Сохранено");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
              
            }
            
        }
    }

}

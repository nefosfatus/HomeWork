using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Task1_Input_Formating
{
	/// <summary>
	/// Основной класс
	/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            ConsoleOutput consoleOutput = new ConsoleOutput();
            while (true) //loop
            {
                input.GetInputValues();
                var x = input.X_Value;
                var y = input.Y_Value;
                consoleOutput.PrintCoordinates(x, y);
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
            catch(Exception ex)
            {
                Console.WriteLine("Введите оба ЧИСЛОВЫХ значения\n");
                Console.WriteLine(ex.Message);
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
    class ConsoleOutput
    {
        public void PrintCoordinates(decimal x, decimal y) 
        {
			string ForPrint = string.Format("X:{0:N6} Y:{1:N6}", x, y);
			Console.WriteLine(ForPrint);
            Console.ReadKey();
        }

    }

}

    


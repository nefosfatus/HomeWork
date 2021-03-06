﻿using System;
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
                var x = input.ValueX;
                var y = input.ValueY;
                consoleOutput.PrintCoordinates(x, y);
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

				_x = decimal.Parse(SplittedValues[0], CultureInfo.InvariantCulture);
                _y = decimal.Parse(SplittedValues[1], CultureInfo.InvariantCulture);
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
    /// <param name="x">Координата Х</param>
    /// <param name="y">Координата Y</param>
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

    


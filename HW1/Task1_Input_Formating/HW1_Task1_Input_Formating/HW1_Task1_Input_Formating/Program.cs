using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Task1_Input_Formating
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            ConsoleOutput consoleOutput = new ConsoleOutput();
            while (true)
            {
                input.GetInputValues();
                var x = input.X_Value;
                var y = input.Y_Value;
                consoleOutput.PrintCoordinates(x, y);
            }
        }
    }

    class Input
    {
        private string x;
        private string y;
        public void GetInputValues()
        {
            Console.WriteLine("Пожалуйста введите координаты");
            string Value = Console.ReadLine();
            try
            {
                string[] SplittedValues = Value.Split(',');
                x = SplittedValues[0];
                y = SplittedValues[1];
            }
            catch(Exception ex)
            {
                Console.WriteLine("Введите оба ЧИСЛОВЫХ значения\n");
                Console.WriteLine(ex.Message);
            }
        }
        public string X_Value
        {
            get { return x; }
        }
        public string Y_Value
        {
            get { return y; }
        }
   
    }
    class ConsoleOutput
    {
        public void PrintCoordinates(string x, string y) 
        {
            Console.WriteLine($"\nX:{x}, Y:{y}");
            Console.ReadKey();
        }

    }

}

    


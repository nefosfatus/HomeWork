using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Input_From_File_Formating
{
    class Program
    {
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
                    consoleOutput.PrintCoordinates(Coordinates[0], Coordinates[1]);
                }
                Console.ReadKey();
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
            
        }

    }

}

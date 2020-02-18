using System;

namespace Task1_Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            //initialization instance
            Input input = new Input();
            Output output = new Output();

            //get 2 vectors
            Vector firstVector = input.GetUserInput();
            Vector secondVector = input.GetUserInput();

            //do all overload operations and print it
            output.PrintAllOperations(firstVector, secondVector);

            if (firstVector == secondVector)
            {
                Console.WriteLine("Векторы равны");
            }
            if (firstVector != secondVector)
            {
                Console.WriteLine("Векторы НЕ равны");
            }


            Console.ReadLine();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}

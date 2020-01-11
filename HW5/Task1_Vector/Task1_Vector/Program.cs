using System;

namespace Task1_Vector
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Input input = new Input();
            Output output = new Output();

            Vector firstVector = input.GetUserInput();
            Vector secondVector = input.GetUserInput();
            output.PrintAllOperations(firstVector, secondVector);


            Console.ReadLine();




        }
    }
}

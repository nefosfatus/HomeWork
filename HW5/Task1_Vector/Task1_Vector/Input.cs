using System;

namespace Task1_Vector
{
    class Input
    {
        /// <summary>
        /// create vector by user input
        /// </summary>
        /// <returns></returns>
        public Vector GetUserInput()
        {
            Vector vector = new Vector();
            Console.WriteLine("\n Please enter vector coordinates");
            Console.WriteLine("\nx:");
            vector.xAxisNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("\ny:");
            vector.yAxisNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("\nz:");
            vector.zAxisNumber = double.Parse(Console.ReadLine());
            return vector;
        }
    }
}

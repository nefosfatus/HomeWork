using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Vector
{
    class Input
    {
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

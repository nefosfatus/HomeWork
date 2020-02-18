using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

    
                //initialize
                Input input = new Input();

                //Get user input - coordinates
                List<int> pointACoorinates = input.GetCoordinates("A");
                List<int> pointBCoorinates = input.GetCoordinates("B");
                List<int> pointCCoorinates =  input.GetCoordinates("C");

                //create new trianlge
                Triangle triangle = new Triangle(pointACoorinates, pointBCoorinates, pointCCoorinates);

                //get info about triangle
                triangle.GetTriangleInfo();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}

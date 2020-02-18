using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Input
    {
        /// <summary>
        /// Method for get user input
        /// </summary>
        /// <param name="point">Cooedinate name </param>
        /// <returns>list with coordinates</returns>
        public List<int> GetCoordinates(string point)
        {
            try
            {
                Console.WriteLine($"Введите координату Х точки {point}");
                int xCoorinate = int.Parse(Console.ReadLine());
                Console.WriteLine($"Введите координату Y точки {point}");
                int yCoorinate = int.Parse(Console.ReadLine());
                List<int> coordinates = new List<int>() { xCoorinate, yCoorinate };
                return coordinates;
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

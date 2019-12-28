using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoxWithToys.Toy;

namespace BoxWithToys
{
    class Program
    {
        static void Main(string[] args)
        {
            Airplane airpalne = new Airplane();
            Helicopter helicopter = new Helicopter();
            List<Toy> toys = new List<Toy>() {airpalne, helicopter };
            foreach(var toy in toys)
            {
                
                if (toy is IAircrafter && toy is IPlaner)
                {
                    Console.WriteLine("Да это самолет!");
                    toy.GetToyName();
                }
                else if(toy is IAircrafter && toy is ICopter)
                {
                    
                    Console.WriteLine("Да это вертолет!");
                    toy.GetToyName();
                }
            }
            Console.ReadKey();
            
        }

    }
}

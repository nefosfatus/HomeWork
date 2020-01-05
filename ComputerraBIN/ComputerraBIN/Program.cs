using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const int maximum = 6;
            EmploeeGenerator emploeeGenerator = new EmploeeGenerator();
            Field field = new Field();
            Engine engine = new Engine();
            List<Emploee> emploees = emploeeGenerator.GenerateEmploees(5,2,1,2, maximum);
            
            field.BuildWall(maximum, maximum);
            field.DrawPositions(emploees);
            engine.StartWork(15,emploees, maximum, maximum, maximum, maximum);
            
          

            Console.ReadKey();
        }
    }
}

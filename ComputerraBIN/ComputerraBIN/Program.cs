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
            const int maximum = 7;
            EmploeeGenerator emploeeGenerator = new EmploeeGenerator();
            Field field = new Field();
            Engine engine = new Engine();
            List<Emploee> emploees = emploeeGenerator.GenerateEmploees(5,2,1,2, maximum);
            List<Work> works = emploeeGenerator.GenereteWork(4, 2, maximum);
            List<Customer> customers = emploeeGenerator.GenereteCustomer(1, 2, maximum);
            
            field.BuildWall(maximum, maximum);
            foreach(var item in emploees)
            {
                field.DrawPositions(item);
            }
            foreach (var item in works)
            {
                field.DrawPositions(item);
            }
            foreach (var item in customers)
            {
                field.DrawPositions(item);
            }

            engine.SayHello(emploees);
            engine.StartWork(150,emploees, works, customers, 2, maximum, 2, maximum);
            
          

            Console.ReadKey();
        }
    }
}

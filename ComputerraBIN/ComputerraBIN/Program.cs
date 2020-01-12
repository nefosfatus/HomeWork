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
            //Max and min coordinates (Wall perimeter)
            const int maximum = 15;
            const int minimum = 2;
            //Items count
            const int workHours = 8;
            const int workersCount = 8;
            const int bossesCount = 5;
            const int bigBossesCount = 2;
            const int worksCount = 4;
            const int customersCount = 1;

            ///Instances for work with generator,drawer and engine
            EmploeeGenerator emploeeGenerator = new EmploeeGenerator();
            Field field = new Field();
            Engine engine = new Engine();

            //generate 8 Workers,5 Bosses, 2 BigBosses
            List<Emploee> emploees = emploeeGenerator.GenerateEmploees(workersCount, bossesCount, bigBossesCount, minimum, maximum);
            //generate 4 works
            List<Work> works = emploeeGenerator.GenereteWork(worksCount, minimum, maximum);
            //generate 1 customer
            List<Customer> customers = emploeeGenerator.GenereteCustomer(customersCount, minimum, maximum);
            //Build wall by min/max position
            field.BuildWall(maximum, maximum);
            //cast to IMoveble and concatinate to one list
            List<IMoveable> emploeesMovebles = emploees.Cast<IMoveable>().ToList();
            List<IMoveable> worksMoveables = works.Cast<IMoveable>().ToList();
            List<IMoveable> customersMoveables = customers.Cast<IMoveable>().ToList();
            List<IMoveable> allItems = new List<IMoveable>();
            allItems = allItems.Concat(emploeesMovebles).Concat(worksMoveables).Concat(customersMoveables).ToList();
            //Draw start position for all elements
            field.DrawStartPositions(allItems);
            //Start engine for 8 hours
            engine.StartWork(workHours, emploees, works, customers, minimum, maximum, minimum, maximum);

            Console.ReadKey();
        }
    }
}

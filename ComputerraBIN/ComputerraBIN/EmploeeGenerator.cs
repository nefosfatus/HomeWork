using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// Class for generate items ant theirs parameters
    /// </summary>
    public class EmploeeGenerator
    {

        private readonly Random random = new Random();
        /// <summary>
        /// Create List of emplooes
        /// </summary>
        public List<Emploee> GenerateEmploees(int workersCount, int bossesCount, int bigBossesCount, int minCoordinate, int maxCoordinate)
        {
            List<Emploee> emploees = CreateEmploees(workersCount, bossesCount, bigBossesCount);
            emploees = GiveSalary(emploees, 1000, 3000, 5000, 10000, 20000, 50000);
            
            emploees = GiveName(emploees);
            emploees = GiveMood(emploees);
            emploees = GivePost(emploees);
            emploees = GivePhrase(emploees);
            foreach(var emploee in emploees)
            {
                emploee.Position = GivePosition(emploee.Position, minCoordinate, maxCoordinate, minCoordinate, maxCoordinate);
            }
            return emploees;
        }
        /// <summary>
        /// Create List of works
        /// </summary>
        public List<Work> GenereteWork(int worksCount, int minCoordinate, int maxCoordinate)
        {
            List<Work> works = new List<Work>();
            while (worksCount != 0)
            {
                Work work = new Work();
                works.Add(work);
                worksCount--;
            }
            foreach (var work in works)
            {
                work.Position = GivePosition(work.Position, minCoordinate, maxCoordinate, minCoordinate, maxCoordinate);
            }
            return works;
        }
        /// <summary>
        /// Create List of Customers
        /// </summary>
        public List<Customer> GenereteCustomer(int customersCount, int minCoordinate, int maxCoordinate)
        {
            List<Customer> customers = new List<Customer>();

            for (int count = customersCount; count!=0; count--)
            {
                Customer customer = new Customer();
                customer.Position = GivePosition(customer.Position, minCoordinate, maxCoordinate, minCoordinate, maxCoordinate);
                customers.Add(customer);
            }
            return customers;
        }
        /// <summary>
        /// Create emploee
        /// </summary>
        public List<Emploee> CreateEmploees(int workersCount, int bossesCount, int bigBossesCount)
        {
            List<Emploee> workersList = new List<Emploee>();
            while (workersCount != 0)
            {
                Worker worker = new Worker();
                workersList.Add(worker);
                workersCount--;
            }
            while (bossesCount != 0)
            {
                Boss boss = new Boss();
                workersList.Add(boss);
                bossesCount--;
            }
            while (bigBossesCount != 0)
            {
                BigBoss bigBoss = new BigBoss();
                workersList.Add(bigBoss);
                bigBossesCount--;
            }
            return workersList;
        }
        /// <summary>
        /// Give name for each emploees in list 
        /// </summary>
        /// <param name="emploees"></param>
        public List<Emploee> GiveName(List<Emploee> emploees)
        {
            List<string> firstNames = new List<string>() { "John", "William", "James", "Charles", "George", "Frank", "Joseph", "Mary", "Anna", "Emma", "Elizabeth", "Minnie" };
            List<string> secondNames = new List<string>() { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson" };

            foreach (var emploee in emploees)
            {
                string firstName = firstNames[random.Next(0, firstNames.Count - 1)];
                string secondName = secondNames[random.Next(0, secondNames.Count - 1)];
                emploee.Name = firstName + " " + secondName;
            }
            return emploees;
        }
        /// <summary>
        /// Give position for each emploees in list 
        /// </summary>
        public Point GivePosition(Point point, int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate)
        {
            List<Point> usedPoints = new List<Point>();
            
            bool isUnic = false;
            while (isUnic == false)
            {
                point = new Point
                {
                    CoordinateX = Utilities.GetRandomCoordinate(minXCoordinate, maxXCoordinate),
                    CoordinateY = Utilities.GetRandomCoordinate(minYCoordinate, maxYCoordinate)
                };
                if (usedPoints.Contains(point))
                {
                    continue;
                }
                else
                {
                    isUnic = true;
                    usedPoints.Add(point);
                }
            }
            return point;
        }
        /// <summary>
        /// Give Mood for each emploees in list 
        /// </summary>
        public List<Emploee> GiveMood(List<Emploee> emploees)
        {
            foreach (var emploee in emploees)
            {
                emploee.Mood = random.Next(100) <= 30 ? true : false;
            }
            return emploees;
        }
        /// <summary>
        /// Give salary for each emploees in list 
        /// </summary>
        public List<Emploee> GiveSalary(List<Emploee> emploees, int workerMin, int workerMax, int bossMin, int bossMax, int bigBossMin, int bigBossMax)
        {
            foreach (var emploee in emploees)
            {
                if (emploee is Worker)
                {
                    emploee.Salary = random.Next(workerMin, workerMax);
                }
                if (emploee is Boss)
                {
                    emploee.Salary = random.Next(bossMin, bossMax);
                }
                if (emploee is BigBoss)
                {
                    emploee.Salary = random.Next(bigBossMin, bigBossMax);
                }
            }
            return emploees;
        }
        /// <summary>
        /// Give post for each emploees in list 
        /// </summary>
        public List<Emploee> GivePost(List<Emploee> emploees)
        {
            foreach (var emploee in emploees)
            {
                if (emploee is Worker)
                {
                    emploee.Post = "Worker";
                }
                if (emploee is Boss)
                {
                    emploee.Post = "Boss";
                }
                if (emploee is BigBoss)
                {
                    emploee.Post = "BigBoss";
                }
            }
            return emploees;
        }
        /// <summary>
        /// Give phrase for each emploees in list 
        /// </summary>
        public List<Emploee> GivePhrase(List<Emploee> emploees)
        {
            foreach (var emploee in emploees)
            {
                if (emploee is Worker)
                {
                    emploee.Phrase = "All too easy.";
                }
                if (emploee is Boss)
                {
                    emploee.Phrase = "Taz'dingo";
                }
                if (emploee is BigBoss)
                {
                    emploee.Phrase = "Lok-narash!";
                }
            }
            return emploees;
        }
       
        
    }
}

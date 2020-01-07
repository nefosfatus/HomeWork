using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public class EmploeeGenerator
    {

        private readonly Random random = new Random();
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
        public List<Customer> GenereteCustomer(int customersCount, int minCoordinate, int maxCoordinate)
        {
            List<Customer> customers = new List<Customer>();
            while (customersCount != 0)
            {
                Customer customer = new Customer();
                customers.Add(customer);
                customersCount--;
            }
            foreach (var customer in customers)
            {
                customer.Position = GivePosition(customer.Position, minCoordinate, maxCoordinate, minCoordinate, maxCoordinate);
            }
            return customers;
        }
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

        public Point GivePosition(Point point, int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate)
        {
            List<Point> usedPoints = new List<Point>();
            
            bool isUnic = false;
            while (isUnic == false)
            {
                point = new Point
                {
                    CoordinateX = random.Next(minXCoordinate, maxXCoordinate),
                    CoordinateY = random.Next(minYCoordinate, maxYCoordinate)
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
        public List<Emploee> GiveMood(List<Emploee> emploees)
        {
            foreach (var emploee in emploees)
            {
                emploee.Mood = random.Next(100) <= 30 ? true : false;
            }
            return emploees;
        }
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

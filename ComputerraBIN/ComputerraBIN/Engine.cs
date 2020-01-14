using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// Terrarium engine
    /// </summary>
    public class Engine
    {
        readonly Random random = new Random();
        readonly Field field = new Field();
        /// <summary>
        /// Start terrarium
        /// </summary>
        /// <param name="timeCycle">Work hours</param>
        /// <param name="emploees">Emploees</param>
        /// <param name="works">Work to do </param>
        /// <param name="customers">Customers</param>
        /// Move only in office field
        public bool StartWork(int timeCycle, List<Emploee> emploees,List<Work> works,List<Customer> customers,int minXCoordinate, int maxXCoordinate,int minYCoordiate, int maxYCoordinate)
        {
            while (timeCycle != 0)
            {
                PrintWorkTime(timeCycle);
                foreach (var emploee in emploees)
                {
                    Point newPosition = GetNewPosition(emploee.Position, minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
                    IMoveable placeholder = CheckIt(emploees, works, customers, newPosition);
                    if (placeholder == null)
                    {
                        ClearCell(emploee.Position);
                        emploee.Move(newPosition);
                        field.DrawPositions(emploee);
                    }
                    if (emploee is Worker)
                    {
						DoWorkerJob(emploees, works, customers, placeholder,  emploee, minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
					}
                    if (emploee is Boss)
                    {
						DoBossJob(emploees, works, customers, placeholder, emploee, minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
					}
                    if (emploee is BigBoss)
                    {
						DoBigBossJob(emploees, works, customers, placeholder, emploee, minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
					}
                    Task.Delay(500).Wait();
                    continue;
                }
                foreach(var customer in customers)
                {
                    Point newPosition = GetNewPosition(customer.Position, minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
                    IMoveable placeholder = CheckIt(emploees, works, customers, newPosition);
                    if (placeholder == null)
                    {
                        ClearCell(customer.Position);
                        customer.Move(newPosition);
                        field.DrawPositions(customer);
                    }
                    continue;
                }
                timeCycle--;
            }
            PrintWorkTime(timeCycle);
            return true;
        }
        /// <summary>
        /// Clock
        /// </summary>
        /// <param name="timeCycle"></param>
        public void PrintWorkTime(int timeCycle)
        {
            Field field = new Field();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            field.ClearCurrentConsoleLine();
            Console.WriteLine($"Until the end of the working day: {timeCycle} hours");
        }
        /// <summary>
        /// Check free position for move
        /// </summary>
        public IMoveable CheckIt(List<Emploee> emploees,List<Work> works,List<Customer> customers, Point newPosition)
        {
            Emploee emploee = emploees.Where(s => s.Position == newPosition)?.FirstOrDefault();
            Work work = works.Where(s => s.Position == newPosition)?.FirstOrDefault();
            Customer customer = customers.Where(s => s.Position == newPosition)?.FirstOrDefault();
            if (emploee != null)
                return emploee;
            if (work != null)
                return work;
            if (customer != null)
                return customer;
            return null;
        }
        /// <summary>
        /// Clear current position before move to new position
        /// </summary>
        /// <param name="point"></param>
        public void ClearCell(Point point)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(point.CoordinateX, point.CoordinateY);
            Console.Write(" ");
        }
        /// <summary>
        /// Move to new position
        /// </summary>
        public Point GetNewPosition(Point currentPosition, int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate)
        {
            currentPosition.CoordinateX = SetPosition(currentPosition.CoordinateX, minXCoordinate, maxXCoordinate);
            currentPosition.CoordinateY = SetPosition(currentPosition.CoordinateY, minYCoordinate, maxYCoordinate);
            return currentPosition;
        }
        /// <summary>
        /// Move only by 1 cell around
        /// </summary>
        public int SetPosition(int coordinate, int minCoordinate, int maxCoordinate)
        {
            if (coordinate  < maxCoordinate && coordinate  > minCoordinate)
            {
                coordinate  += random.Next(-1, 2);
            }
            if (coordinate  >= maxCoordinate)
            {
                coordinate  += random.Next(-1,0);
            }
            if (coordinate  <= minCoordinate)
            {
                coordinate  += random.Next(0, 2);
            }
            return coordinate;
        }
		public void DoWorkerJob(List<Emploee> emploees, List<Work> works, List<Customer> customers,IMoveable placeholder,Emploee emploee, int minXCoordinate, int maxXCoordinate, int minYCoordiate, int maxYCoordinate)
		{
			if ((placeholder is Boss) || (placeholder is BigBoss))
				emploee.Talk((Emploee)placeholder);
			if (placeholder is Work)
			{
				Point WorkNewPosition = GetNewPosition(placeholder.Position, minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
				IMoveable workplaceholder = CheckIt(emploees, works, customers, WorkNewPosition);
				if (workplaceholder == null)
				{
					ClearCell(placeholder.Position);
					placeholder.Move(WorkNewPosition);
					field.DrawPositions(placeholder);
					emploee.SalaryIncrease(100);
					emploee.Say("work is done");
				}
			}
		}

		public void DoBossJob(List<Emploee> emploees, List<Work> works, List<Customer> customers, IMoveable placeholder, Emploee emploee, int minXCoordinate, int maxXCoordinate, int minYCoordiate, int maxYCoordinate)
		{
			if (placeholder is Worker)
			{
				((Boss)emploee).Talk((Worker)placeholder);
				((Boss)emploee).DoWork((IManagable)placeholder);
				emploee.SalaryIncrease(10);
			}
			if (placeholder is Boss)
			{
				emploee.Talk((Emploee)placeholder);
				((Boss)emploee).DoWork((IManagable)placeholder);
			}
			if (placeholder is BigBoss)
			{
				emploee.Talk((Emploee)placeholder);
			}
			if (placeholder is Work)
			{
				emploee.Say("Now I will find a specialist");
			}
			if (placeholder is Customer)
			{
				emploee.Say("Your task will be completed as soon as possible");
				emploee.SalaryIncrease(100);
			}
		}
		public void DoBigBossJob(List<Emploee> emploees, List<Work> works, List<Customer> customers, IMoveable placeholder, Emploee emploee, int minXCoordinate, int maxXCoordinate, int minYCoordiate, int maxYCoordinate)
		{
			if (placeholder is Worker)
			{
				((BigBoss)emploee).Manage((IManagable)placeholder);
				emploee.SalaryIncrease(10);
			}
			if (placeholder is Boss)
			{
				emploee.Talk((Emploee)placeholder);
				((IManage)emploee).Manage((IManagable)placeholder);
			}
			if (placeholder is Work)
			{
				emploee.Say("Now I will find a manager");
			}
			if (placeholder is Customer)
			{
				emploee.Say("How about new project?");
				Work newWork = ((Customer)placeholder).CreateWork(minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
				field.DrawPositions(newWork);
				emploee.SalaryIncrease(1000);
			}
			if (placeholder is BigBoss)
			{
				emploee.Talk((Emploee)placeholder);
			}
		}
	}
}
 
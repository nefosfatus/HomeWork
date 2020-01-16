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
        public bool StartWork(int timeCycle, List<IMoveable> all,CoordinateLimits coordinateLimits)
        {
            var emploees = all.OfType<Emploee>();
            var customers = all.OfType<Customer>();
            var works = all.OfType<Work>();
            while (timeCycle != 0)
            {
                PrintWorkTime(timeCycle);
                foreach (var emploee in emploees)
                {
                    Point newPosition = GetNewPosition(emploee.Position, coordinateLimits);
                    IMoveable placeholder = CheckIt(all, newPosition);
                    if (placeholder == null)
                    {
                        ClearCell(emploee.Position);
                        emploee.Move(newPosition);
                        field.DrawPositions(emploee);
                    }
                    if (emploee is Worker)
                    {
                        DoWorkerJob(all, placeholder, emploee, coordinateLimits);
                    }
                    if (emploee is Boss)
                    {
                        DoBossJob(all, placeholder, emploee, coordinateLimits);
                    }
                    if (emploee is BigBoss)
                    {
                        DoBigBossJob(all, placeholder, emploee, coordinateLimits);
                    }
                    Task.Delay(500).Wait();
                    continue;
                }
                foreach(var customer in customers)
                {
                    Point newPosition = GetNewPosition(customer.Position, coordinateLimits);
                    IMoveable placeholder = CheckIt(all, newPosition);
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine($"Until the end of the working day: {timeCycle} hours");
        }
        /// <summary>
        /// Check free position for move
        /// </summary>
        public IMoveable CheckIt(List<IMoveable> all, Point newPosition)
        {
            var placeholder = GetElementOnPosition(all, newPosition);
            if (placeholder != null)
                return placeholder;
            return null;
        }
        public IMoveable GetElementOnPosition(List<IMoveable> list,Point point)
        {
            IMoveable element = list.Where(s => s.Position == point).FirstOrDefault();
            return element;
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
        public Point GetNewPosition(Point currentPosition, CoordinateLimits coordinateLimits)
        {
            currentPosition.CoordinateX = SetPosition(currentPosition.CoordinateX, coordinateLimits.CoordinateXMin, coordinateLimits.CoordinateXMax);
            currentPosition.CoordinateY = SetPosition(currentPosition.CoordinateY, coordinateLimits.CoordinateYMin, coordinateLimits.CoordinateYMax);
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
		public void DoWorkerJob(List<IMoveable> emploees,IMoveable placeholder,Emploee emploee,CoordinateLimits coordinateLimits)
		{
			if ((placeholder is Boss) || (placeholder is BigBoss))
				emploee.Talk((Emploee)placeholder);
			if (placeholder is Work)
			{
				Point WorkNewPosition = GetNewPosition(placeholder.Position, coordinateLimits);
				IMoveable workplaceholder = CheckIt(emploees, WorkNewPosition);
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

		public void DoBossJob(List<IMoveable> emploees, IMoveable placeholder, Emploee emploee, CoordinateLimits coordinateLimits)
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
		public void DoBigBossJob(List<IMoveable> emploees, IMoveable placeholder, Emploee emploee, CoordinateLimits coordinateLimits)
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
				Work newWork = ((Customer)placeholder).CreateWork(coordinateLimits);
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
 
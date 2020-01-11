using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public class Engine
    {
        readonly Random random = new Random();
        readonly Field field = new Field();
        public bool StartWork(int timeCycle, List<Emploee> emploees,List<Work> works,List<Customer> customers,int minXCoordinate, int maxXCoordinate,int minYCoordiate, int maxYCoordinate)
        {
            while (timeCycle != 0)
            {
                foreach(var emploee in emploees)
                {
                    Point newPosition = GetNewPosition(emploee.Position, minXCoordinate, maxXCoordinate,minYCoordiate,maxYCoordinate);
                    IMoveable placeholder = CheckIt(emploees,works,customers, newPosition);
                    if (placeholder == null)
                    {
                        ClearCell(emploee.Position);
                        emploee.Move(newPosition);
                        field.DrawPositions(emploee);                        
                    }
                    if(emploee is Worker)
                    {
                        var newPositionfinded = false;
                        
                            if ((placeholder is Boss) || (placeholder is BigBoss))
                                emploee.Talk((Emploee)placeholder);
                            if(placeholder is Work)
                            {
                            while (newPositionfinded != true)
                            {
                                Point WorkNewPosition = GetNewPosition(placeholder.Position, minXCoordinate, maxXCoordinate, minYCoordiate, maxYCoordinate);
                                IMoveable workplaceholder = CheckIt(emploees, works, customers, WorkNewPosition);
                                if (workplaceholder == null)
                                {
                                    ClearCell(placeholder.Position);
                                    placeholder.Move(WorkNewPosition);
                                    field.DrawPositions(placeholder);
                                    emploee.Say("work is done");
                                    newPositionfinded = true;
                                }
                        }
                        }

                    }
                    
                        
                    
                    Task.Delay(500).Wait();
                }
                
                timeCycle--;
            }
            return true;
        }
        
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
        public void ClearCell(Point point)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(point.CoordinateX, point.CoordinateY);
            Console.Write(" ");
        }
        public Point GetNewPosition(Point currentPosition, int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate)
        {
            currentPosition.CoordinateX = SetPosition(currentPosition.CoordinateX, minXCoordinate, maxXCoordinate);
            currentPosition.CoordinateY = SetPosition(currentPosition.CoordinateY, minYCoordinate, maxYCoordinate);
            return currentPosition;
        }

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

        public void SayHello(List<Emploee> emploees)
        {
            int i = 18;
            Console.SetCursorPosition(30, i);
            field.ClearCurrentConsoleLine();
            foreach (var emploee in emploees)
            {
                Console.SetCursorPosition(2, i);
                emploee.Say("Hello!");
                i++;
            }

        }

    }
}

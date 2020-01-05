using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    class Engine
    {
        Random random = new Random();
        Field field = new Field();
        public bool StartWork(int timeCycle, List<Emploee> emploees,int minXCoordinate, int maxXCoordinate,int minYCoordiate, int maxYCoordinate)
        {
            while (timeCycle != 0)
            {
                foreach(var emploee in emploees)
                {
                    Point newPosition = GetNewPosition(emploee.Position, minXCoordinate, maxXCoordinate,minYCoordiate,maxYCoordinate);
                    
                    ClearCell(emploee.Position);
                    emploee.Move(newPosition);
                    List<Emploee> currentEmploe = new List<Emploee> { emploee };
                    field.DrawPositions(currentEmploe);
                    currentEmploe.Clear();
                }
                Task.Delay(500);
                timeCycle--;
            }
            return true;
        }
        
        public void CheckIt(List<Emploee> emploees, Point newPosition)
        {
            Emploee placeholder = emploees.Where(s => s.Position == newPosition)?.FirstOrDefault();
        }
        public void ClearCell(Point point)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(point.CoordinateX, point.CoordinateY);
            Console.Write(" ");
        }
        public Point GetNewPosition(Point currentPosition, int minXCoordinate, int maxXCoordinate, int minYCoordiate, int maxYCoordinate)
        {
            bool isFit = false;
            while (isFit == false)
            {
                if (currentPosition.CoordinateX == 1 || currentPosition.CoordinateX == minXCoordinate-1 || currentPosition.CoordinateX == maxXCoordinate-1) 
                {
                    Point newPosition = SetPosition(currentPosition, maxXCoordinate, maxYCoordinate, 0, -1);
                    isFit = true;
                    return newPosition;
                }
                if (currentPosition.CoordinateY == 1 || currentPosition.CoordinateY == minYCoordiate-1 || currentPosition.CoordinateY == maxYCoordinate-1)
                {
                    Point newPosition = SetPosition(currentPosition, maxXCoordinate, maxYCoordinate, -1, 0);
                    isFit = true;
                    return newPosition;
                }

                if ((currentPosition.CoordinateX !=1)  && (currentPosition.CoordinateY != 1))
                {
                    Point newPosition = SetPosition(currentPosition, maxXCoordinate, maxYCoordinate, -1, -1);
                    isFit = true;
                    return newPosition;

                }


            }
            return currentPosition;

        }

        public Point SetPosition(Point currentPosition, int maxXCoordinate, int maxYCoordinate,
            int minX,int minY)
        {
            Point newPosition = new Point
            {
                CoordinateX = currentPosition.CoordinateX + random.Next(minX, 1),
                CoordinateY = currentPosition.CoordinateY + random.Next(minY, 1)
            };
            if (newPosition.CoordinateX < maxXCoordinate && newPosition.CoordinateY < maxYCoordinate)
            {
                return newPosition;
            }
            return currentPosition;
        }
        //get list and timer

        //draw start picture 

        //generate new coordinate 

        //if there is item iteract with if not take that place

        //draw item on new place 

        //clear old place 
    }
}

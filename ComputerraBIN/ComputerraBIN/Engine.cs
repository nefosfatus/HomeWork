using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public class Engine
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
        public Point GetNewPosition(Point currentPosition, int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate)
        {
            bool isFit = false;
            while (isFit == false)
            {

                currentPosition.CoordinateX = SetPosition(currentPosition.CoordinateX, minXCoordinate, maxXCoordinate);
                currentPosition.CoordinateY = SetPosition(currentPosition.CoordinateY, minYCoordinate, maxYCoordinate);

            }
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
        //get list and timer

        //draw start picture 

        //generate new coordinate 

        //if there is item iteract with if not take that place

        //draw item on new place 

        //clear old place 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public struct Point: IPoint
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public Point GetPosition()
        {
            Point point = new Point();
            return point;
        }

        //перегрузка операторов
        public static bool operator ==(Point point1, Point point2)
        {
            if ((point1.CoordinateX == point2.CoordinateX) && (point1.CoordinateY == point2.CoordinateY))
                return true;
            return false;
        }
        public static bool operator !=(Point point1, Point point2)
        {
            if ((point1.CoordinateX == point2.CoordinateX) && (point1.CoordinateY == point2.CoordinateY))
                return false;
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// structure for indicating position on the field
    /// </summary>
    public struct Point: IPoint
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        /// <summary>
        /// return positon
        /// </summary>
        /// <returns></returns>
        public Point GetPosition()
        {
            Point position = new Point()
            {
                CoordinateX = this.CoordinateX,
                CoordinateY = this.CoordinateY
            };
            return position;
        }

        //operator overload to copare the position
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
        public override int GetHashCode()
        {
            return (this.CoordinateX << 2) ^ this.CoordinateY;
        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point p = (Point)obj;
                return (CoordinateX == p.CoordinateX) && (CoordinateY == p.CoordinateY);
            }
        }
    }
}

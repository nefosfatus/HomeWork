using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// Can't move, characterized only by the position
    /// </summary>
    public class Work : IMoveable
    {
        public Point Position { get; set; }
        public bool IsAlive()
        {
            return false;
        }
        public void Move(Point p)
        {
            Position = new Point()
            {
                CoordinateX = p.CoordinateX,
                CoordinateY = p.CoordinateY
            };
        }
    }
}

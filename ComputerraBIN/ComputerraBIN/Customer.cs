using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public class Customer : IManage, IMoveable
    {
        /// <summary>
        /// Has position
        /// </summary>
        public Point Position { get; set; }

        Random rnd = new Random();
        /// <summary>
        /// Can manage staff
        /// </summary>
        /// <param name="imngbl"></param>
        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork(imngbl);
        }
        /// <summary>
        /// Can create new work
        /// </summary>
        /// <returns>New work</returns>
        public Work CreateWork(int minXCoordinate, int maxXCoordinate, int minYCoordiate, int maxYCoordinate)
        {
            Work work = new Work()
            {
                Position = new Point()
                {
                    CoordinateX = rnd.Next(minXCoordinate, maxXCoordinate),
                    CoordinateY = rnd.Next(minYCoordiate, maxYCoordinate)
                }
            };
            
            return work;
        }
        /// <summary>
        /// Can move
        /// </summary>
        /// <param name="p"></param>
        public void Move(Point p)
        {
            Position = new Point()
            {
                CoordinateX = p.CoordinateX,
                CoordinateY = p.CoordinateY
            };
        }
        /// <summary>
        /// check if item is alive
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            return false;
        }
    }
}

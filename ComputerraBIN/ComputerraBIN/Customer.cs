using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    class Customer : IManage
    {
        Random rnd = new Random();
        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork(imngbl);
        }
        public Work CreateWork()
        {
            Work work = new Work()
            {
                Position = new Point()
                {
                    CoordinateX = rnd.Next(0, 100),
                    CoordinateY = rnd.Next(0, 100)
                }
            };
            return work;
        }
    }
}

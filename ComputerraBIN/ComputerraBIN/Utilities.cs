using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public static class Utilities
    {
        private static readonly Random random = new Random();
        public static int GetRandomCoordinate(int min, int max)
        {
            int coordinate = random.Next(min, max);
            return coordinate;
        }
    }
}

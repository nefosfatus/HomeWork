using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Matrix
{
	class Utilities
	{
        /// <summary>
        /// Get random coordinate
        /// </summary>
        private static readonly Random random = new Random();
        public static int GetRandomValue(int min, int max)
        {
            int coordinate = random.Next(min, max);
            return coordinate;
        }

    }
}

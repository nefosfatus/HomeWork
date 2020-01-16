using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public static class Utilities
    {
        /// <summary>
        /// Get random coordinates for point
        /// </summary>
        private static readonly Random random = new Random();
        public static int GetRandomCoordinate(int min, int max)
        {
            int coordinate = random.Next(min, max);
            return coordinate;
        }
        /// <summary>
        /// Clear curret console line for write neew message
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}

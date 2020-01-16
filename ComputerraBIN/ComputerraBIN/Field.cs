using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// Class for draw in console
    /// </summary>
    class Field
    {
        /// <summary>
        /// Create office wall
        /// </summary>
        /// <param name="wallHeight">wallHeight</param>
        /// <param name="wallWidth">wallWidth</param>
        public void BuildWall(int wallHeight, int wallWidth)
        {
            for (int i = 1; i < wallHeight; i++)
            {
                PutBrick(1, i, wallHeight, i);
            }
            for (int i = 1; i < wallWidth; i++)
            {
                PutBrick(i, 1, i, wallWidth);
            }
        }
        /// <summary>
        /// Drow # element
        /// </summary>
        public void PutBrick(int a, int b, int c, int d)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b);
            Console.Write("#");
            Console.SetCursorPosition(c, d);
            Console.Write("#");
        }
        /// <summary>
        /// Draw position for imovable element
        /// </summary>
        /// <param name="emploee"></param>
        public void DrawPositions(IMoveable emploee)
        {
            string emploeeSymbol = "W";
            string customerSymbol = "C";
            string workSymbol = "$";
            ConsoleColor workerColor = ConsoleColor.White;
            ConsoleColor bossColor = ConsoleColor.Blue;
            ConsoleColor bigBossColor = ConsoleColor.DarkYellow;
            ConsoleColor workColor = ConsoleColor.Yellow;
            if (emploee is Worker)
            {
                DrawSymbol(emploeeSymbol, emploee.Position, workerColor);
                return;
            }
            if (emploee is Boss)
            {
                DrawSymbol(emploeeSymbol, emploee.Position, bossColor);
                return;
            }
            if (emploee is BigBoss)
            {
                DrawSymbol(emploeeSymbol, emploee.Position, bigBossColor);
                return;
            }
            if (emploee is Customer)
            {
                DrawSymbol(customerSymbol, emploee.Position, workerColor);
                return;
            }
            if (emploee is Work)
            {
                DrawSymbol(workSymbol, emploee.Position, workColor);
                return;
            }
        }

        public void DrawSymbol(string symbol, Point position, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.SetCursorPosition(position.CoordinateX, position.CoordinateY);
            Console.Write(symbol);
        }
        public void DrawStartPositions(List<IMoveable> items)
        {
            foreach (var item in items)
            {
                DrawPositions(item);
            }

        }
    }
    /// <summary>
    /// Limits for determine borders
    /// </summary>
    public struct CoordinateLimits
    {
        public int CoordinateXMin { get; set; }
        public int CoordinateXMax { get; set; }
        public int CoordinateYMin { get; set; }
        public int CoordinateYMax { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    class Field
    {

        public void BuildWall(int wallHeight, int wallWidth)
        {
            for(int i = 1; i < wallHeight; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(wallWidth, i);
                Console.Write("#");
            }
            for (int i = 1; i < wallWidth; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, wallHeight);
                Console.Write("#");
            }
        }
        public void DrawPositions(List<Emploee> emploees)
        {
            foreach(var emploee in emploees)
            {
                if(emploee is Worker)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(emploee.Position.CoordinateX, emploee.Position.CoordinateY);
                    Console.Write("W");
                }
                if (emploee is Boss)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(emploee.Position.CoordinateX, emploee.Position.CoordinateY);
                    Console.Write("W");
                }
                if (emploee is BigBoss)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(emploee.Position.CoordinateX, emploee.Position.CoordinateY);
                    Console.Write("W");
                }

            }
        }
    }
}

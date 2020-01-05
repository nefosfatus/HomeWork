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
    }
}

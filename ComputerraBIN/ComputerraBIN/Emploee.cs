using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// Basic class for emploees
    /// </summary>
    abstract public class Emploee : IEmploee, IMoveable, IAlive
    {
        /// <summary>
        /// Emploee parametrs 
        /// </summary>
        public decimal Salary { get; set; } 
        public string Name { get; set; } 
        public bool Mood { get; set; }  
        public Point Position { get; set; }  
        public string Post { get; set; }    
        public string Phrase { get; set; }
        /// <summary>
        /// check if item is alive
        /// </summary>
        /// <returns>boolean answer</returns>
        public bool IsAlive()
        {
            return true;
        }
        /// <summary>
        /// move item on position <p>
        /// </summary>
        /// <param name="p">point</param>
        public void Move(Point p)
        {
            Position = new Point()
            {
                CoordinateX = p.CoordinateX,
                CoordinateY = p.CoordinateY
            };
        }
        /// <summary>
        /// Salary Increase
        /// </summary>
        /// <param name="increase">Add to emploee salary</param>
        public void SalaryIncrease(int increase)
        {
            this.Salary += increase;
        }
        /// <summary>
        /// Say something + emploee present
        /// </summary>
        /// <param name="WhatToSay"></param>
        public void Say(string WhatToSay)
        {
            Console.SetCursorPosition(0, 18);
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine($"{WhatToSay}. My name is:{Name}, I'm:{Post}, My salary is {Salary}$");
        }
        /// <summary>
        /// Talk with placeholder
        /// </summary>
        /// <param name="ee">emploee </param>
        public void Talk(Emploee ee)
        {
            Console.SetCursorPosition(0, 16);
            Utilities.ClearCurrentConsoleLine();
            if ((this is Worker) && (ee is Worker))
            {
                PrintPhrase("Be happy to!");
                return;
            }
            if ((this is Worker) && ((ee is Boss)||(ee is BigBoss)))
            {
                PrintPhrase($"I hear and obey. {ee.Post}");
                return;
            }
            if ((this is Boss) && (ee is Worker))
            {
                PrintPhrase("Move fasta'!");
                return;
            }
            if ((this is Boss) && (ee is Boss))
            {
                PrintPhrase($"For the Horde!");
                return;
            }
            if ((this is Boss) && (ee is BigBoss))
            {
                PrintPhrase("Yes, chieftain?");
                return;
            }
            if (this is BigBoss)
            {
                PrintPhrase($"We need more gold!");
                return;
            }
        }
        /// <summary>
        /// Clear current console line and print new phrase
        /// </summary>
        /// <param name="phrase"></param>
        public void PrintPhrase(string phrase)
        {
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine(phrase);
        }
        
    }
}

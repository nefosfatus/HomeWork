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
            Field field = new Field();
            Console.SetCursorPosition(0, 18);
            field.ClearCurrentConsoleLine();
            Console.WriteLine($"{WhatToSay}. My name is:{Name}, I'm:{Post}, My salary is {Salary}$");
        }
        /// <summary>
        /// Talk with placeholder
        /// </summary>
        /// <param name="ee">emploee </param>
        public void Talk(Emploee ee)
        {
            Field field = new Field();
            Console.SetCursorPosition(0, 16);
            field.ClearCurrentConsoleLine();
            if ((this is Worker) && (ee is Worker))
            {
                string phrase = "Be happy to!";
                field.ClearCurrentConsoleLine();
                Console.WriteLine(phrase);
            }
            if ((this is Worker) && ((ee is Boss)||(ee is BigBoss)))
            {
                string phrase = $"I hear and obey. {ee.Post}";
                field.ClearCurrentConsoleLine();
                Console.WriteLine(phrase);
            }
            if ((this is Boss) && (ee is Worker))
            {
                string phrase = "Move fasta'!";
                field.ClearCurrentConsoleLine();
                Console.WriteLine(phrase);
            }
            if ((this is Boss) && (ee is Boss))
            {
                string phrase = $"For the Horde!";
                field.ClearCurrentConsoleLine();
                Console.WriteLine(phrase);
            }
            if ((this is Boss) && (ee is BigBoss))
            {
                string phrase = $"Yes, chieftain? ";
                field.ClearCurrentConsoleLine();
                Console.WriteLine(phrase);
            }
            if (this is BigBoss)
            {
                string phrase = $"We need more gold!";
                field.ClearCurrentConsoleLine();
                Console.WriteLine(phrase);
            }
        }
        
    }
}

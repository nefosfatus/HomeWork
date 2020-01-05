using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    abstract public class Emploee : IEmploee, IMoveable, IAlive
    {
        public decimal Salary { get; set; } //done
        public string Name { get; set; } //done
        public bool Mood { get; set; }  //done
        public Point Position { get; set; }  //done
        public string Post { get; set; }    //done
        public string Phrase { get; set; }  //done

        public bool IsAlive()
        {
            return true;
        }

        public void Move(Point p)
        {
            Position = new Point()
            {
                CoordinateX = p.CoordinateX,
                CoordinateY = p.CoordinateY
            };
        }

        public void Say(string WhatToSay)
        {
            Console.WriteLine($"{Phrase}. My name is:{Name}, I'm:{Post}");
        }

        public void Talk(Emploee ee)
        {
            if ((this is Worker) && (ee is Worker))
            {
                string phrase = "Be happy to!";
                Console.WriteLine(phrase);
            }
            else
            {
                string phrase = $"I hear and obey. {ee.Post}";
                Console.WriteLine(phrase);
            }
            if ((this is Boss) && (ee is Worker))
            {
                string phrase = "Move fasta'!";
                Console.WriteLine(phrase);
            }
            if ((this is Boss) && (ee is Boss))
            {
                string phrase = $"For the Horde!";
                Console.WriteLine(phrase);
            }
            if ((this is Boss) && (ee is BigBoss))
            {
                string phrase = $"Yes, chieftain?";
                Console.WriteLine(phrase);
            }
            if (this is BigBoss)
            {
                string phrase = $"We need more gold!";
                Console.WriteLine(phrase);
            }
        }
    }
}

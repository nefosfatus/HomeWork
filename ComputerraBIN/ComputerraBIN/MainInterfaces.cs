using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public interface IPoint
    {
        Point GetPosition();
    }
    public interface IMoveable
    {
        Point Position { get; set; }
        void Move(Point p);
        bool IsAlive();
    }
    public interface IAlive { };
    public interface IManagable
    {
        void DoWork(IManagable imngbl);
    }
    public interface IManage
    {
        void Manage(IManagable imngbl);
    }
    public interface IEmploee
    {
        decimal Salary { get; set; }
        string Name { get; set; }
        bool Mood { get; set; }
        Point Position { get; set; }
        void Say(string WhatToSay);
        void Talk(Emploee ee);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// To get item position
    /// </summary>
    public interface IPoint
    {
        Point GetPosition();
    }
    /// <summary>
    /// To set position,move item
    /// </summary>
    public interface IMoveable
    {
        Point Position { get; set; }
        void Move(Point p);
       
    }
    /// <summary>
    /// To check Alive item or not
    /// </summary>
    public interface IAlive { bool IsAlive(); };
    /// <summary>
    /// What items can be controled
    /// </summary>
    public interface IManagable
    {
        void DoWork(IManagable imngbl);
    }
    /// <summary>
    /// what items can control
    /// </summary>
    public interface IManage
    {
        void Manage(IManagable imngbl);
    }
    /// <summary>
    /// Emploee interface
    /// </summary>
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

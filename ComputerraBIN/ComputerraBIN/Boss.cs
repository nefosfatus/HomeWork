using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// Class for bosses.
    /// Boss obeys the big bossees
    /// Boss manages workers
    /// </summary>
    class Boss : Emploee, IManagable, IManage
    {
        /// <summary>
        /// Do what big boss say and manages workers
        /// </summary>
        /// <param name="imngbl"></param>
        public void DoWork(IManagable imngbl)
        {
            if (imngbl is Worker)
            {
                this.Mood = false;
                this.Salary = Salary + 100;
            }
            if(imngbl is Boss)
            {
                this.Mood = false;
            }
        }

        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork(imngbl);
        }
    }
    /// <summary>
    /// Manage all emploees
    /// </summary>
    class BigBoss : Emploee, IManage
    {
        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork(imngbl);
        }
    }
}

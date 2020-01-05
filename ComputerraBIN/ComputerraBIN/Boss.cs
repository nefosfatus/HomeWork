using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    class Boss : Emploee, IManagable, IManage
    {
        public void DoWork(IManagable imngbl)
        {
            if (imngbl is Worker)
            {
                this.Mood = false;
                this.Salary = Salary - 100;
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
    class BigBoss : Emploee, IManage
    {
        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork(imngbl);
        }
    }
}

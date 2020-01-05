using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    public class Worker : Emploee, IManagable
    {
        public void DoWork(IManagable managable)
        {
            this.Mood = false;
            this.Salary = Salary + 10;
        }
        
    }
}

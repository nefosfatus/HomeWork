using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    /// <summary>
    /// hard worker, can only do the job
    /// </summary>
    public class Worker : Emploee, IManagable
    {
        /// <summary>
        /// do what the authorities say
        /// after that mood is decreasing but salary is increasing
        /// </summary>
        /// <param name="managable"></param>
        public void DoWork(IManagable managable)
        {
            this.Mood = false;
            this.Salary = Salary + 10;
        }
        
    }
}

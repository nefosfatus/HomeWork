using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{

    public class Emploee
    {
        protected string empNum;
        protected string empName;
        protected void DoWork() { }
        public Emploee(string number, string name)
        {
            this.empNum = number;
            this.empName = name;
        }
        public virtual string GetTypeName()
        {
            return "This is Emploee";
        }
    }
    public class Manager : Emploee
    {
        public Manager(string number, string name) : base(number,name)
        {

        }
        public void DoManagerWork() { }

        public override string GetTypeName()
        {
            return "This is Manager";
        }
    }
    public class ManualWorker : Emploee
    {
        public ManualWorker(string number, string name) : base(number, name)
        {

        }
        public void DoManualWork() { }
    }
}

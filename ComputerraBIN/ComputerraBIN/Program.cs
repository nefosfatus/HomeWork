using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN
{
    class Program
    {
        
        static void Main(string[] args)
        {

            EmploeeGenerator emploeeGenerator = new EmploeeGenerator();
            List<Emploee> emploees = emploeeGenerator.GenerateEmploees();
          

            Console.ReadKey();
        }
    }
}

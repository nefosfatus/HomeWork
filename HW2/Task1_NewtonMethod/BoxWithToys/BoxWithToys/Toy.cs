using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxWithToys
{
    public abstract class Toy: IToyName,IToyProperties
    {
        public virtual string ToyName { get {
                return "Игрушка";
            } 
        }
        
        
        public virtual string GetToyName()
        {
            
            string ToyAnswer = "Мое имя " + ToyName;
            Console.WriteLine(ToyAnswer);
            return ToyAnswer;
        }

        public virtual List<string> GetToyProperties()
        {
            List<string> Properties = new List<string> {"Красивая"};
            return Properties;
        }
        
    }
    public class Airplane : Toy, IAircrafter,IPlaner
    {
        public override string ToyName{get { return "Самолет"; } }
    }

    public class Helicopter: Toy, IAircrafter, ICopter
    {
        public override string ToyName { get { return "Вертолет"; } }
    }
}

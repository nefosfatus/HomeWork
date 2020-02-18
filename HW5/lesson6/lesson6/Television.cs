using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
	abstract class Television
	{
		public void TurnOn() 
		{
			Console.WriteLine("Television on");
		}
		public void TurnOff()
		{
			Console.WriteLine("Television ff");
		}
		public abstract void  IncreaseVolume();
		public abstract void  DecreaseVolume();
	}

	class WidescreenTv : Television
	{
		public override void IncreaseVolume()
		{
			Console.WriteLine("vol inc");
		}
		public override void DecreaseVolume()
		{
			Console.WriteLine("vol dec");
		}
	}

	class TV : Television
	{
		public override void IncreaseVolume()
		{
			Console.WriteLine("vol inc TV");
		}
		public override void DecreaseVolume()
		{
			Console.WriteLine("vol dec TV"); ;
		}
	}
}	

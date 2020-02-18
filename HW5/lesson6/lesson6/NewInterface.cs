using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
	interface NewInterface
	{
		double Add();
	}
	interface NewInterface2
	{
		double Add();
	}
	class SomeClass : NewInterface, NewInterface2
	{
		double NewInterface.Add()
		{
			return 2;
		}
		double NewInterface2.Add()
		{
			return 2;
		}
	}
}

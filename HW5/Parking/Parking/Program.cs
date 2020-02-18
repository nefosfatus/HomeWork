using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//Add autos on "parking"(List)
				List<Auto> autosOnParking = Generator.CreateParking();
				//get fastest auto
				Auto fastestAuto = autosOnParking.OrderBy(s => s.Parameters.Speed).FirstOrDefault();
				//get auto with max carring
				Auto maxCarringAuto = autosOnParking.OrderBy(s => s.Parameters.Carring).FirstOrDefault();
				//Print in console
				Console.WriteLine($"\nСамое быстрое авто {fastestAuto.Parameters.Brand}:{fastestAuto.Parameters.Number} - {fastestAuto.Parameters.Speed}(м/с)");
				Console.WriteLine($"\nСамое грузоподъемное авто {maxCarringAuto.Parameters.Brand}:{maxCarringAuto.Parameters.Number} - {maxCarringAuto.Parameters.Carring}(кг)");
				Console.ReadKey();
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.ReadKey();
		}
	}
}

//auto -> Car,Track,Auto
//base mark,number,speed
//track - 

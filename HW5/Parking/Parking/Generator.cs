using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
	/// <summary>
	/// Static class to create 
	/// some autos
	/// </summary>
	public static class Generator
	{
		/// <summary>
		/// Create parking by user input 
		/// </summary>
		/// <returns>List of autos</returns>
		public static List<Auto> CreateParking()
		{
			//arrange
			Input input = new Input();
			List<Auto> autoList = new List<Auto>();
			bool continueAnswer = true;

			//Do until the user cliks "stop"(key N)
			while (continueAnswer == true)
			{	
				//get type and parameters from user
				Automobiles autoType = input.ChooseAutoType();
				MainAutoParameters autoParameters = input.MainMenu(autoType);
				//create auto by this parameters
				Auto auto = AutomobileCreater.CreateAuto(autoType);
				auto.SetAutoParameters(autoParameters);
				//Add to List
				autoList.Add(auto);
				//Create yet?
				Console.WriteLine("Создать еще(Y/N)");
				continueAnswer = input.ChooseYesNo();
			}
			return autoList;
		}
	}
	public static class AutomobileCreater
	{
		/// <summary>
		/// Create auto by choosen type
		/// </summary>
		/// <param name="automobiles">choosen type</param>
		/// <returns>Auto</returns>
		public static Auto CreateAuto(Automobiles automobiles)
		{
			if (automobiles == Automobiles.Car)
			{
				Car car = new Car();
				return car;
			}
			if (automobiles == Automobiles.Track)
			{
				Track track = new Track();
				return track;
			}
			if (automobiles == Automobiles.Bike)
			{
				Bike bike = new Bike();
				return bike;
			}
			throw new ArgumentException("Переданно не верное значение");
		}

	}
}

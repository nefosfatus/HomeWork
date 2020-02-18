using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{	
	/// <summary>
	/// Class for work with user input
	/// </summary>
	public class Input
	{
		/// <summary>
		/// Choose auto type
		/// </summary>
		/// <returns>Auto type</returns>
		public Automobiles ChooseAutoType()
		{
			Console.WriteLine("\nАвтомобиль какого типа Вы хотите добавить?");
			Console.WriteLine("\tМашина - 1 |Грузовое авто - 2 | Мотоцикл - 3");
			ConsoleKeyInfo ans = Console.ReadKey();
			if (ans.Key == ConsoleKey.D1)
			{
				Console.WriteLine("\nВы создали машину.");
				return Automobiles.Car;
			}
			if (ans.Key == ConsoleKey.D2)
			{
				Console.WriteLine("\nВы создали грузовик.");
				return Automobiles.Track;
			}
			if (ans.Key == ConsoleKey.D3)
			{
				Console.WriteLine("\nВы создали  мотоцикл.");
				return Automobiles.Bike;
			}
			throw new ArgumentException("Не выбран ни один из предложенных вариантов");
		}
		/// <summary>
		/// Main menu in console for every created auto
		/// </summary>
		/// <param name="automobile">Choosen auto type</param>
		/// <returns>Parameters for auto</returns>
		public MainAutoParameters MainMenu(Automobiles automobile)
		{
			//Arrange
			MainAutoParameters autoParameters = new MainAutoParameters();
			string brand = string.Empty;
			string number = string.Empty;
			int speed = 0;
			//Set brand
			Console.WriteLine("\nВведите марку:");
			brand = Console.ReadLine();
			bool brandInputCheck = string.IsNullOrEmpty(brand);
			if (!brandInputCheck)
				autoParameters.Brand = brand;
			if (brandInputCheck)
			{
				Console.WriteLine("Это поле не может быть пустым, по умолчанию BMW");
				autoParameters.Brand = "BMW";
			}
			//Set speed
			Console.WriteLine("\nВведите скорость:");
			bool speedInputCheck = int.TryParse(Console.ReadLine(), out speed);
			if (speedInputCheck)
				autoParameters.Speed = speed;
			if(!speedInputCheck)
				Console.WriteLine("Вы ввели неверный формат данных, скорость по умолчанию 0");
			//Set number
			Console.WriteLine("\nВведите номер:");
			number = Console.ReadLine();
			bool numberInputCheck = string.IsNullOrEmpty(brand);
			if (!numberInputCheck)
				autoParameters.Number = number;
			if (numberInputCheck)
			{
				Console.WriteLine("Номер не может быть пустым, по умолчанию - 6666");
				autoParameters.Number = "6666";
			}
			//Set carring
			if (automobile == Automobiles.Bike)
				autoParameters.Carring = BikeMenu();
			if (automobile == Automobiles.Track)
				autoParameters.Carring = TrackMenu();
			if (automobile == Automobiles.Car)
				autoParameters.Carring = 200;
			return autoParameters;
		}
		/// <summary>
		/// Menu for bike.If bike has pram set carrign 50
		/// if not set carring 0
		/// </summary>
		/// <returns>Carring. </returns>
		public int BikeMenu()
		{
			Console.WriteLine("\nДобавить коляску?(Y/N)");
			bool answerAboutPram = ChooseYesNo();
			if (answerAboutPram)
			{
				int pramCarring = 50;
				Console.WriteLine("\nКоляска создана.");
				return pramCarring;
			}
			return 0;
		}
		/// <summary>
		/// Menu for track
		/// Set carring = user input 
		/// </summary>
		/// <returns>Carring</returns>
		public int TrackMenu()
		{
			Console.WriteLine("Введите грузоподъемность:");
			int carring;
			var result = int.TryParse(Console.ReadLine(),out carring);
			if (result)
				return carring;
			Console.WriteLine("Не верный ввод");
			return 0;
		}
		/// <summary>
		/// Method to ask user.
		/// </summary>
		/// <returns>Yes/no</returns>
		public bool ChooseYesNo()
		{
			ConsoleKeyInfo ans = Console.ReadKey();
			if (ans.Key == ConsoleKey.Y)
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// Set speed = user input 
		/// </summary>
		/// <returns>speed</returns>
		public int AskSpeed()
		{
			Console.WriteLine("\nВведите скорость:");
			int carring;
			var result = int.TryParse(Console.ReadLine(), out carring);
			if (result)
				return carring;
			Console.WriteLine("Не верный ввод");
			return 0;
		}
	}
	
}

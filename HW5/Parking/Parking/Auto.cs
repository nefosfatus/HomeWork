using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{	
	/// <summary>
	/// Automobile types
	/// </summary>
	public enum Automobiles
	{
		Car,
		Track,
		Bike
	}
	/// <summary>
	/// Common parameters for any auto
	/// </summary>
	public struct MainAutoParameters
	{
		public string Brand { get; set; }
		public string Number { get; set; }
		public int Speed { get; set; }
		public int Carring { get; set; }
	}
	/// <summary>
	/// Base class for every auto in out application
	/// 
	/// </summary>
	public abstract class Auto
	{
		public MainAutoParameters Parameters { get; set; }
		/// <summary>
		/// Standart setting parameters 
		/// </summary>
		/// <param name="autoParameters"></param>
		public virtual void SetAutoParameters(MainAutoParameters autoParameters)
		{
			this.Parameters = autoParameters;
		}
	}

	public class Car : Auto
	{
		/// <summary>
		/// Redefined method for Car
		/// Car carring == 200; Always
		/// </summary>
		/// <param name="autoParameters">Car parameters</param>
		public override void SetAutoParameters(MainAutoParameters autoParameters)
		{
			this.Parameters = new MainAutoParameters()
			{
				Speed = autoParameters.Speed,
				Brand = autoParameters.Brand,
				Number = autoParameters.Number,
				Carring = 200
			};
		}
	}
	/// <summary>
	/// These classes use standart parameters setting
	/// </summary>
	public class Track : Auto
	{
		
	}
	public class Bike : Auto
	{
		
	}
	
}


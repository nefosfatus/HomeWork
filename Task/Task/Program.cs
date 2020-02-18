using System;
using System.Collections.Generic;
using System.Linq;
using Task.Data;

namespace Task
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			var dataSource = new DataSource();


			var customers = dataSource.Customers;
			var suppliers = dataSource.Suppliers;
			var product = dataSource.Products;

			//максимальный суммарный оборот
			decimal maximumTotalTurnover = 4000;
			decimal maximumOrderPrice = 800;

			//заказы первого клиента
			var ordersFirstCustomer = customers.First().Orders;

			//сумма первого заказа у первого клиента
			var summFirstOrderOfOFirstCustomer = customers.First().Orders.First().Total;

			//список всех клиентов, чей суммарный оборот превосходит максимальный
			var customerWhichOverupMaxTotal = customers.Where(c => (c.Orders.Sum(r=>r.Total)) > maximumTotalTurnover).Select(s=>s.CompanyName);

			//все клиенты, у которых были заказы, превосходящие по сумме величину X
			var customerWhichOverupMaxPrice = customers.Where(c => c.Orders.Any(r => r.Total > maximumOrderPrice)).Select(s => s.CompanyName);
			
			//список поставщиков, находящихся в той же стране и том же городе
			foreach (var item in customers)
			{
				foreach(var it in suppliers)
				{
					if ((item.City == it.City)&&(item.Country == it.Country)){
						
					}
				}
			}

			//Укажите всех клиентов, у которых указан нецифровой почтовый код или не заполнен регион
			//или в телефоне не указан код оператора
			char rightBracket = ')';
			char leftBracket = '(';
			var unreferencedCustomers = customers.Where(c => (c.Region == null)
															||(c.Phone.ToString().Contains(rightBracket)&&c.Phone.ToString().Contains(leftBracket))
															||(c.PostalCode.ToString().Any(r=>char.IsSymbol(r)))
															);
			var unreferencedCustomers1 = customers.Where(c => (c.Phone.ToString().Contains(rightBracket) && c.Phone.ToString().Contains(leftBracket)));
			var unreferencedCustomers2 = customers.Where(c => (c.PostalCode.ToString().Any(r => char.IsSymbol(r))));
			var unreferencedCustomers3 = customers.Where(c => (c.Region == null));
		}
	}
}
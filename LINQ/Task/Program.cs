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
			//максимальная сумма заказа
			decimal maximumOrderPrice = 800;

			//заказы первого клиента
			var ordersFirstCustomer = customers.First().Orders;

			//сумма первого заказа у первого клиента
			var summFirstOrderOfOFirstCustomer = customers.First().Orders.First().Total;

			//список всех клиентов, чей суммарный оборот превосходит максимальный
			var customerWhichOverupMaxTotal = customers.Where(c => (c.Orders.Sum(r=>r.Total)) > maximumTotalTurnover);

			//все клиенты, у которых были заказы, превосходящие по сумме величину X
			var customerWhichOverupMaxPrice = customers.Where(c => c.Orders.Any(r => r.Total > maximumOrderPrice));

			//список поставщиков, находящихся в той же стране и том же городе
			var localSuppliersForEachCustomer = customers.Select(c => new {
				Name = c.CompanyName,
				SuppliersList = suppliers.Where(n=>n.Country==c.Country && n.City == c.City)
			});

			//Укажите всех клиентов, у которых указан нецифровой почтовый код или не заполнен регион
			//или в телефоне не указан код оператора
			char rightBracket = ')';
			char leftBracket = '(';
			var unreferencedCustomers = customers.Where(c=>c.PostalCode!=null).Where(c => 
															(c.Region==null)
															||(c.Phone.ToString().Contains(rightBracket)&&c.Phone.ToString().Contains(leftBracket))
															||(c.PostalCode.Any(n => char.IsLetter(n)))
															);

			//Сгруппируйте товары по группам «дешевые», «средняя цена», «дорогие». Границы каждой группы задайте сами
			decimal cheapOraderBoard = 30;
			decimal middleOraderBoard = 70;

			var ordersGroupsByTotal = new
			{
				CheapProducts = product.Where(s=>s.UnitPrice<cheapOraderBoard),
				MiddleProducts = product.Where(s => s.UnitPrice < middleOraderBoard),
				ExpensiveProducts = product.Where(s => s.UnitPrice > middleOraderBoard)
			};
		}
	}
}
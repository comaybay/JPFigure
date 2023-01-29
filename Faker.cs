using JPFigure.Entities;
using JPFigure.Models;
using System;
using static NuGet.Packaging.PackagingConstants;

namespace JPFigure
{
	public class Faker
	{
		private Random random = new Random();
		private JPFigureContext context;

		public Faker(JPFigureContext context)
		{
			this.context = context;
		}

		public async Task AddRandomOrders(int year)
		{
			var clearorders = context.Orders.Where(o => o.Date.Year == year).ToList();
			context.Orders.RemoveRange(clearorders);
			await context.SaveChangesAsync();

			var userIds = context.Users.Select(u => u.Id).ToList();
			var figureIds = context.Figures.Select(u => u.Id).ToList();

			var orders = new List<Order>();
			for (int i = 1; i <= 12; i++) {
				for (int oi = 0; oi < random.Next(10, 51); oi++)
				{
					var date = new DateTime(year, random.Next(1, 13), 1);
					date.AddDays(random.Next(0, 32));

					orders.Add(new()
					{
						Date = date,
						UserId = ChooseRandom(userIds),
					});
				}
			}

			context.Orders.AddRange(orders);
			await context.SaveChangesAsync();

			var orderDetails = new List<OrderDetail>();
			foreach (var order in orders) { 
				for (int odi = 0; odi < random.Next(1, 10); odi++)
				{
					orderDetails.Add(new()
					{
						FigureId = ChooseRandom(figureIds),
						OrderId = order.Id,
						Quantity = random.Next(1, 10),
					});
				}
			}

			context.OrderDetails.AddRange(orderDetails);
			await context.SaveChangesAsync();
		}

		private T ChooseRandom<T>(List<T> list)
		{
			return list[random.Next(list.Count)];
		}
	}
}

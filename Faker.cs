using JPFigure.Entities;
using JPFigure.Entities.Enums;
using JPFigure.Models;
using System;
using static NuGet.Packaging.PackagingConstants;
using Character = JPFigure.Entities.Character;

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

		public async Task PopulateRandomFigures()
		{
			var removeFigures = context.Figures.Where(f => f.ProductName.Contains("Mock Figure Of")).ToList();
			context.Figures.RemoveRange(removeFigures);
			await context.SaveChangesAsync();

			var characters = context.Characters.ToList();
			var manufactureIds = context.Manufactures.Select(u => u.Id).ToList();

			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.NonScale, FigureType.Others);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.NonScale, FigureType.Nendoroid);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneTwelveth, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneThird, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneFourth, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneFifth, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneSixth, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneSeventh, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneEight, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneTenth, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.NonGundam, FigureScale.OneTwelveth, FigureType.ScaleFigure);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.HighGrade, FigureScale.NonScale, FigureType.Gundam);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.RealGrade, FigureScale.NonScale, FigureType.Gundam);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.MasterGrade, FigureScale.NonScale, FigureType.Gundam);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.PerfectGrade, FigureScale.NonScale, FigureType.Gundam);
			AddRandomFiguresToContext(characters, manufactureIds, GundamType.SuperDeformed, FigureScale.NonScale, FigureType.Gundam);
			await context.SaveChangesAsync();
		}

		private string CreateMockImageUrl() => $"Image/mock_figure_{random.Next(0, 8)}.jpg";

		private void AddRandomFiguresToContext(List<Character> characters, List<int> manufacturerIds, GundamType gundamType, FigureScale scale, FigureType figureType)
		{
			var figures = new List<Entities.Figure>();
			var character = ChooseRandom(characters);
			var figureNum = gundamType == GundamType.NonGundam && scale == FigureScale.NonScale ? random.Next(30, 101) : random.Next(5, 16);
			for (int i = 0; i <= figureNum; i++)
			{
				figures.Add(new()
				{
					DateAdded = new DateTime(random.Next(2009, 2020), random.Next(1, 13), random.Next(1, 27)),
					CharacterId = character.Id,
					GundamType = gundamType,
					Height = random.Next(10, 70),
					Images = new string[] { CreateMockImageUrl(), CreateMockImageUrl(), CreateMockImageUrl(), CreateMockImageUrl() },
					Price = random.Next(1, 41) * 300000,
					ManufactureId = ChooseRandom(manufacturerIds),
					ProductName = $"Mock Figure Of {character.Name}",
					ReleaseDate = new DateOnly(random.Next(2009, 2023), random.Next(1, 13), random.Next(1, 27)),
					Scale = scale,
					StockCount = random.Next(5, 100),
					Type = figureType
				});
			}

			context.Figures.AddRange(figures);
		}
	}
}

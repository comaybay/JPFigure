using JPFigure.Entities.Enums;
using JPFigure.Models;
using JPFigure.Repositories.Data;
using JPFigure.Repositories.Data.Filters;
using JPFigure.Repositories.Data.Inputs;

namespace JPFigure.Repositories
{
	public class FigureRepository : Repository
	{
		public FigureRepository(JPFigureContext context) : base(context)
		{
		}

		public async void AddScaleFigure(ScaleFigureInput input)
		{
			await Context.Figures.AddAsync(new()
			{
				Type = FigureType.ScaleFigure,
				GundamType = GundamType.NonGundam,
				Scale = input.Scale,
				ProductName = input.ProductName,
				Height = input.Height,
				ReleaseDate = input.ReleaseDate,
				CharacterId = input.CharacterId,
				StockCount = input.StockCount,
				ManufactureId = input.ManufactureId,
			});
			
			await Context.SaveChangesAsync();
		}

		public async void AddGundamFigure(GundamFigureInput input)
		{
			await Context.Figures.AddAsync(new()
			{
				Type = FigureType.Gundam,
				GundamType = input.GundamType,
				Scale = FigureScale.NonScale,
				ProductName = input.ProductName,
				Height = input.Height,
				ReleaseDate = input.ReleaseDate,
				CharacterId = input.CharacterId,
				StockCount = input.StockCount,
				ManufactureId = input.ManufactureId,
			});

			await Context.SaveChangesAsync();
		}

		public async void AddNendoroidFigure(FigureInput input)
		{
			await Context.Figures.AddAsync(new()
			{
				Type = FigureType.Nendoroid,
				GundamType = GundamType.NonGundam,
				Scale = FigureScale.NonScale,
				ProductName = input.ProductName,
				Height = input.Height,
				ReleaseDate = input.ReleaseDate,
				CharacterId = input.CharacterId,
				StockCount = input.StockCount,
				ManufactureId = input.ManufactureId,
			});

			await Context.SaveChangesAsync();
		}

		public async void AddOtherFigure(FigureInput input)
		{
			await Context.Figures.AddAsync(new()
			{
				Type = FigureType.Others,
				GundamType = GundamType.NonGundam,
				Scale = FigureScale.NonScale,
				ProductName = input.ProductName,
				Height = input.Height,
				ReleaseDate = input.ReleaseDate,
				CharacterId = input.CharacterId,
				StockCount = input.StockCount,
				ManufactureId = input.ManufactureId,
			});

			await Context.SaveChangesAsync();
		}

		public async Task<Pagination<ScaleFigure>> GetScaleFigures(int pageNumber, int limit, ScaleFigureFilter filter)
		{
			throw new NotImplementedException();
		}
	}
}

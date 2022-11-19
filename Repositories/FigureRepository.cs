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

		public async Task AddScaleFigure(ScaleFigureInput input)
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
				Price = input.Price,
				Images = input.Images
			});
			
			await Context.SaveChangesAsync();
		}

		public async Task AddGundamFigure(GundamFigureInput input)
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
				Price = input.Price,
				Images = input.Images
			});

			await Context.SaveChangesAsync();
		}

		public async Task AddNendoroidFigure(FigureInput input)
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
				Price = input.Price,
				Images = input.Images
			});

			await Context.SaveChangesAsync();
		}

		public async Task AddOtherFigure(FigureInput input)
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
				Price = input.Price,
				Images = input.Images
			});

			await Context.SaveChangesAsync();
		}

		public async Task<Pagination<ScaleFigure>> GetScaleFigures(ScaleFigureFilter? filter, int pageNumber = 1, int limit = 20)
		{
			var query = Context.Figures.Where(f => f.Type == FigureType.ScaleFigure);

			if (filter != null)
			{
				if (filter.ManufactureId != null)
					query = query.Where(f => f.ManufactureId == filter.ManufactureId);
				
				if (filter.FigureScale != null)
					query = query.Where(f => f.Scale == filter.FigureScale);

				(int? from, int? to) = filter.PriceRange;

				if (from != null && to != null)
					query = query.Where(f => f.Price >= from && f.Price <= to);

				else if (from != null)
					query = query.Where(f => f.Price >= from);

				else if (to != null)
					query = query.Where(f => f.Price <= to);
			}

			return await PaginationHelper.Create<ScaleFigure>(
				limit, pageNumber, 
				() => filter == null || filter.OrderNewest ? 
					query.OrderByDescending(f => f.DateAdded) : query.OrderBy(f => f.DateAdded)
			);
		}
	}
}

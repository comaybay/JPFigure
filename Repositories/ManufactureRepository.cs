using JPFigure.Entities;
using JPFigure.Repositories.Data.Inputs;
using Microsoft.EntityFrameworkCore;

namespace JPFigure.Repositories
{
	public class ManufactureRepository : Repository
	{
		public ManufactureRepository(JPFigureContext context) : base(context)
		{
		}

		public async void AddManufacture(ManufactureInput input)
		{
			await Context.Manufactures.AddAsync(new()
			{
				Name = input.Name
			});

			await Context.SaveChangesAsync();
		}

		public async Task<List<Manufacture>> GetAllSeries()
		{
			return await Context.Manufactures.ToListAsync();
		}
	}
}

using JPFigure.Repositories.Data.Inputs;
using Microsoft.EntityFrameworkCore;

namespace JPFigure.Repositories
{
	public class ManufactureRepository : Repository
	{
		public ManufactureRepository(JPFigureContext context) : base(context)
		{
		}

		public async Task AddManufacture(ManufactureInput input)
		{
			await Context.Manufactures.AddAsync(new()
			{
				Name = input.Name
			});

			await Context.SaveChangesAsync();
		}

		public async Task<List<Models.Manufacture>> GetAllManufactures()
		{
			return await Context.Manufactures.Select(m => new Models.Manufacture()
			{
				Id = m.Id,
				Name = m.Name,
			}).ToListAsync();
		}
	}
}

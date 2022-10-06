using JPFigure.Entities;
using JPFigure.Repositories.Data.Inputs;
using Microsoft.EntityFrameworkCore;

namespace JPFigure.Repositories
{
	public class SeriesRepository : Repository
	{
		public SeriesRepository(JPFigureContext context) : base(context)
		{
		}

		public async Task AddSeries(SeriesInput input)
		{
			await Context.Series.AddAsync(new()
			{
				Name = input.Name
			});

			await Context.SaveChangesAsync();
		}

		public async Task<List<Models.Series>> GetAllSeries()
		{
			return await Context.Series.Select(
				s => new Models.Series() { 
					Id = s.Id,
					Name = s.Name
				}).ToListAsync();
		}
	}
}

using JPFigure.Repositories.Data.Inputs;

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
	}
}

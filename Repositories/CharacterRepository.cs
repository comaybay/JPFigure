using JPFigure.Entities;
using JPFigure.Repositories.Data.Inputs;

namespace JPFigure.Repositories
{
	public class CharacterRepository : Repository
	{
		public CharacterRepository(JPFigureContext context) : base(context)
		{
		}

		public async void AddCharacter(CharacterInput input)
		{
			await Context.Characters.AddAsync(new()
			{
				Name = input.Name,
				SeriesId = input.SeriesId
			});

			await Context.SaveChangesAsync();
		}
	}
}

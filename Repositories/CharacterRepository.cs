using JPFigure.Entities;
using JPFigure.Repositories.Data.Inputs;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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

		public async Task<List<Models.Character>> GetAllCharacters()
		{
			return await Context.Characters
				.Include(c => c.Series)
				.Select(c => new Models.Character() { 
					Id = c.Id, 
					Name = c.Name, 
					Series = c.Series
				})
				.ToListAsync();
		}
	}
}

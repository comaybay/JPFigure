using JPFigure.Entities;
using JPFigure.Repositories.Data.Inputs;
using Microsoft.EntityFrameworkCore;

namespace JPFigure.Repositories
{
	public class UserRepository : Repository
	{
		public UserRepository(JPFigureContext context) : base(context)
		{
		}

		public async Task<bool> EmailExists(string email)
		{
			return await Context.Users.AnyAsync(u => u.Email == email);
		}


		public async Task<User?> GetUser(int id)
		{
			return await Context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
		}

		public async Task<User?> GetUser(string email, string password)
		{
			return await Context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
		}

		public async Task AddUser(User input)
		{
			await Context.Users.AddAsync(input);
			await Context.Carts.AddAsync(new Cart { UserId = input.Id });
			await Context.SaveChangesAsync();
		}

		public async Task<List<Entities.User>> GetAllUsers()
		{
			return await Context.Users.ToListAsync();
		}
	}
}

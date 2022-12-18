using JPFigure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace JPFigure.Repositories
{
	public class CartRepository : Repository
	{
		public CartRepository(JPFigureContext context) : base(context)
		{
		}

		public async Task<Cart> AddCart(int userId)
		{
			var cart = new Cart { UserId = userId };
			await Context.Carts.AddAsync(cart);
			await Context.SaveChangesAsync();
			return cart;
		}

		public async Task AddToCart(string userEmail, int figureId, int quantity)
		{
			var cart = await GetCart(userEmail);

			var cartDetail = Context.CartDetails.Where(cd => cd.FigureId == figureId && cd.CartId == cart.Id).FirstOrDefault();

			if (cartDetail == null)
			{
				await Context.CartDetails.AddAsync(new CartDetail()
				{
					CartId = cart.Id,
					FigureId = figureId,
					Quantity = quantity,
				});
			}
			else
			{
				cartDetail.Quantity += quantity;
				Context.CartDetails.Update(cartDetail);
			}

			await Context.SaveChangesAsync();
		}

		public async Task<Cart> GetCart(string userEmail)
		{
			var cart = await Context.Carts.Where(c => c.User.Email == userEmail).FirstOrDefaultAsync();
			if (cart == null)
			{
				cart = await AddCart(Context.Users.Where(u => u.Email == userEmail).First().Id);
			}

			return cart;
		}
	}
}

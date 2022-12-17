using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace JPFigure.Auth
{
	public class AuthStateProvider : AuthenticationStateProvider
	{
		private readonly ProtectedSessionStorage sessionStorage;
		private ClaimsPrincipal anonClaims = new ClaimsPrincipal(new ClaimsIdentity());

		public AuthStateProvider(ProtectedSessionStorage sessionStorage)
		{
			this.sessionStorage = sessionStorage;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			try
			{
				var usResult = await sessionStorage.GetAsync<UserSession>("UserSession");
				var us = usResult.Success ? usResult.Value : null;

				if (us == null)
				{
					return await Task.FromResult(new AuthenticationState(anonClaims));
				}

				var claims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name, us.Name),
					new Claim(ClaimTypes.Email, us.Email),
					new Claim(ClaimTypes.Role, us.Role),
				}, "Auth"));

				return await Task.FromResult(new AuthenticationState(claims));
			}
			catch
			{
				return await Task.FromResult(new AuthenticationState(anonClaims));
			}
		}

		public async Task UpdateAuthenticationState(UserSession userSession)
		{
			ClaimsPrincipal claims;

			if (userSession != null)
			{
				await sessionStorage.SetAsync("UserSession", userSession);
				claims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name, userSession.Name),
					new Claim(ClaimTypes.Email, userSession.Email),
					new Claim(ClaimTypes.Role, userSession.Role),
				}, "Auth"));
			}
			else
			{
				await sessionStorage.DeleteAsync("UserSession");
				claims = anonClaims;
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
		}
	}
}

public class UserSession
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Role { get; set; }
}
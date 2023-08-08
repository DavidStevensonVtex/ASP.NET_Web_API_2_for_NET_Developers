using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace SportsStore.Infrastructure.Identity
{
	public class StoreAuthProvider : OAuthAuthorizationServerProvider
	{
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			UserManager<IdentityUser> userMgr =
				context.OwinContext.Get<UserManager<IdentityUser>>(
					"AspNet.Identity.Owin:" + typeof(UserManager<IdentityUser>).AssemblyQualifiedName);

			IdentityUser user = await userMgr.FindAsync(context.UserName, context.Password);
			if ( user == null )
			{
				context.SetError("invalid_grant", "The username or password is incorrect");
			}
			else
			{
				ClaimsIdentity ident = await userMgr.CreateIdentityAsync(user, "Custom");
				AuthenticationTicket ticket = new AuthenticationTicket(ident, new AuthenticationProperties());
				context.Validated(ticket);
				context.Request.Context.Authentication.SignIn(ident);
			}
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
			return Task.FromResult<object>(null);
		}
	}
}
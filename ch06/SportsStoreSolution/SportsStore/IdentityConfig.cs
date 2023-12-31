﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SportsStore.Infrastructure.Identity;

[assembly:OwinStartup(typeof(SportsStore.IdentityConfig))]

namespace SportsStore
{
    public class IdentityConfig
	{
		public void Configuration(IAppBuilder app) 
		{
			app.CreatePerOwinContext<StoreIdentityDbContext>(StoreIdentityDbContext.Create);
			app.CreatePerOwinContext<UserManager<IdentityUser>>(StoreIdentityManager.CreateUserManager);
			app.CreatePerOwinContext<RoleManager<IdentityRole>>(StoreIdentityManager.CreateRoleManager);

			//app.UseCookieAuthentication(new CookieAuthenticationOptions
			//{
			//	AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
			//});

			//app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions
			//{
			//	Provider = new StoreAuthProvider(),
			//	AllowInsecureHttp = true,
			//	TokenEndpointPath = new PathString("/Authenticate")
			//});
		}
	}
}


using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsStore.Infrastructure.Identity
{
	public class StoreIdentityDbInitializer : CreateDatabaseIfNotExists<StoreIdentityDbContext>
	{
		protected async override void Seed ( StoreIdentityDbContext context )
		{
			StoreUserManager userMgr = new StoreUserManager(new UserStore<StoreUser>(context));
			StoreRoleManager roleMgr = new StoreRoleManager(new RoleStore<StoreRole>(context));

			string roleName = "Administrators";
			string userName = "Admin";
			string password = "secret";
			string email = "admin@example.com";

			if (!await roleMgr.RoleExistsAsync(roleName))
			{
				await roleMgr.CreateAsync(new StoreRole(roleName));
			}

			StoreUser user = await userMgr.FindByNameAsync(userName);
			if (user == null)
			{
				await userMgr.CreateAsync(new StoreUser { UserName = userName, Email = email }, password);
				user = await userMgr.FindByNameAsync(userName);
			}

			if (! await userMgr.IsInRoleAsync(user.Id, roleName))
			{
				await userMgr.AddToRoleAsync(user.Id, roleName);
			}

			base.Seed(context);
		}
	}
}
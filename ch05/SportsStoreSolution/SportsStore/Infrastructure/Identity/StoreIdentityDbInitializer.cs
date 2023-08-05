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
		protected override void Seed ( StoreIdentityDbContext context )
		{
            StoreUserManager userMgr = new StoreUserManager(new UserStore<StoreUser>(context));
			StoreRoleManager roleMgr = new StoreRoleManager(new RoleStore<StoreRole>(context));

            string roleName = "Administrators";
            string userName = "Admin";
            string password = "secret";
            string email = "admin@example.com";

            if (!roleMgr.RoleExistsAsync(roleName).Result)
            {
                roleMgr.CreateAsync(new StoreRole(roleName)).Wait();
            }

            StoreUser user = userMgr.FindByNameAsync(userName).Result;
            if (user == null)
            {
                userMgr.CreateAsync(new StoreUser { UserName = userName, Email = email }, password).Wait();
                user = userMgr.FindByNameAsync(userName).Result;
            }

            //if (!userMgr.IsInRoleAsync(user.Id, roleName).Result)
            //{
            //    userMgr.AddToRoleAsync(user.Id, roleName).Wait();
            //}

            base.Seed(context);
        }
    }
}
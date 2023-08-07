using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SportsStore.Infrastructure.Identity
{

	public class StoreIdentityDbInitializer : CreateDatabaseIfNotExists<StoreIdentityDbContext>
	{
		protected override void Seed ( StoreIdentityDbContext context )
		{
            // UserManager<IdentityUser> userMgr = new UserManager<IdentityUser>(new UserStore<StoreUser>(context));
            // StoreRoleManager roleMgr = new StoreRoleManager(new RoleStore<StoreRole>(context));
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(context);
            UserManager<IdentityUser> userMgr = new UserManager<IdentityUser>(userStore);
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleMgr = new RoleManager<IdentityRole>(roleStore);

            string roleName = "Administrators";
            string userName = "Admin";
            string password = "secret";
            string email = "admin@example.com";

            if (!roleMgr.RoleExistsAsync(roleName).Result)
            {
                roleMgr.CreateAsync(new IdentityRole(roleName)).Wait();
            }

            IdentityUser user = userMgr.FindByNameAsync(userName).Result;
            if (user == null)
            {
                userMgr.CreateAsync(new IdentityUser { UserName = userName, Email = email }, password).Wait();
                user = userMgr.FindByNameAsync(userName).Result;
            }

			if (!userMgr.IsInRoleAsync(user.Id, roleName).Result)
			{
				userMgr.AddToRoleAsync(user.Id, roleName).Wait();
			}

			base.Seed(context);
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace SportsStore.Infrastructure.Identity
{
	public static class StoreIdentityManager
	{
		public static UserManager<IdentityUser> CreateUserManager(
			IdentityFactoryOptions<UserManager<IdentityUser>> options,
			IOwinContext context)
		{
			StoreIdentityDbContext dbContext = context.Get<StoreIdentityDbContext>();
			UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(dbContext);
			UserManager<IdentityUser> userMgr = new UserManager<IdentityUser>(userStore);
			return userMgr;
		}

		public static RoleManager<IdentityRole> CreateRoleManager (
			IdentityFactoryOptions<RoleManager<IdentityRole>> options,
			IOwinContext context)
		{
			StoreIdentityDbContext dbContext = context.Get<StoreIdentityDbContext>();
			RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(dbContext);
			RoleManager<IdentityRole> roleMgr = new RoleManager<IdentityRole>(roleStore);
			return roleMgr;
		}
	}
}
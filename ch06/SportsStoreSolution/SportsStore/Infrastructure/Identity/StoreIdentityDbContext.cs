using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SportsStore.Infrastructure.Identity
{
	public class StoreIdentityDbContext : // IdentityDbContext<IdentityUser>
		IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
	{
		public StoreIdentityDbContext () : base("SportsStoreIdentityDb")
		{
			Database.SetInitializer<StoreIdentityDbContext>(new StoreIdentityDbInitializer());
		}

		public static StoreIdentityDbContext Create()
		{
			return new StoreIdentityDbContext();
		}
    }
}
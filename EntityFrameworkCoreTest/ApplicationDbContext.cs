using EntityFrameworkCoreTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreTest
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Order> Orders { get; set; }
	}
}
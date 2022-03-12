using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreTest.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		public List<User> Users { get; set; }
	}
}

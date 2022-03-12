using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreTest.Models
{
	public class User
    {
		[Key]
	    public int Id { get; set; }

	    public string Name { get; set; }

	    public int Age { get; set; }

		public List<Order> Orders { get; set; }
    }
}
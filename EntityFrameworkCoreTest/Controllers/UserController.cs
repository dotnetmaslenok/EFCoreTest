using EntityFrameworkCoreTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreTest.Controllers
{
	[ApiController]
	[Route("api/user")]
	public class UserController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;

		public UserController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// api/user/create
		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateUser([FromBody] User user)
		{
			await _dbContext.Users.AddAsync(user);
			await _dbContext.SaveChangesAsync();

			return Ok(user.Id);
		}

		// api/user?u=1&s=2
		[HttpGet]
		public async Task<IActionResult> GetUserFromQuery([FromQuery(Name = "u")] int userId, [FromQuery(Name = "s")] int subscriberId)
		{
			await _dbContext.Users.FindAsync(userId);

			var user = await _dbContext.Users.FindAsync(userId);

			var users = await _dbContext.Users
				.ToListAsync();

			return Ok(users);
		}

		[HttpPatch]
		[Route("patch")]
		public async Task UpdateUserPatch(User updateUserModel)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == updateUserModel.Id);

			user.Age = updateUserModel.Age;
			user.Name = updateUserModel.Name;

			_dbContext.Users.Update(user);
			await _dbContext.SaveChangesAsync();
		}

		[HttpPut]
		[Route("put")]
		public async Task UpdateUserPut(User updateUserModel)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == updateUserModel.Id);

			var newUser = new User();
			newUser.Age = updateUserModel.Age;
			newUser.Name = updateUserModel.Name;

			_dbContext.Users.Remove(user);
			await _dbContext.Users.AddAsync(newUser);
			await _dbContext.SaveChangesAsync();
		}

		// api/user/1
		[HttpGet]
		[Route("{userId}")]
		public async Task<IActionResult> GetUserFromRoute([FromRoute] int userId)
		{
			var user = await _dbContext.Users.FindAsync(userId);

			var users = await _dbContext.Users
				.ToListAsync();

			return Ok(users);
		}

		// api/user/1
		[HttpDelete]
		[Route("{userId}")]
		public async Task<IActionResult> DeleteUser([FromRoute] int userId)
		{
			await _dbContext.Users.FindAsync(userId);

			var user = await _dbContext.Users.FindAsync(userId);

			var users = await _dbContext.Users
				.Include(x => x.Orders)
				.ToListAsync();

			return Ok(users);
		}
	}
}

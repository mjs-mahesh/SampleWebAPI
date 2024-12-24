using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")] // api/users
	public class UsersController : ControllerBase
	{
		private readonly DataContext dataContext;

		public UsersController(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
		{
			var users = await dataContext.Users.ToListAsync();
			return users;
		}

		[HttpGet("{id:int}")] // api/users/id
		public async Task<ActionResult<AppUser>> GetUserAsync(int id)
		{
			var user = await dataContext.Users.FindAsync(id);
			if (user == null) { return NotFound(); }
			return user;
		}
	}
}

using ApiCRUDWeb.Repositories.Interfaces;
using ApiCRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApiCRUDWeb.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Register([FromBody] User User)
		{
			var createUser = await _userRepository.AddUser(User);
			if(createUser is null)
			{
				return StatusCode(StatusCodes.Status400BadRequest);
			}
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Get(Guid id)
		{
			var getUser = await _userRepository.GetUser(id);
			if(getUser is null)
			{
				return StatusCode(StatusCodes.Status204NoContent);
			}
			return Ok(getUser);
		}
	}
}

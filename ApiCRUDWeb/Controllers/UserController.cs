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
		public async Task<IActionResult> RegisterAsync([FromBody] User User)
		{
			var createUser = await _userRepository.AddUser(User);
			if(createUser is null)
			{
				return BadRequest();
			}
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> RegisterOwnerAsync([FromBody] Owner Owner)
		{
			var createUser = await _userRepository.RegisterOwnerAsync(Owner);
			if (!createUser)
				return StatusCode(StatusCodes.Status500InternalServerError);

			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> RegisterInstitutuionAsync([FromBody] Institution Institution)
		{
			var createUser = await _userRepository.RegisterInstitutionAsync(Institution);
			if (!createUser)
				return StatusCode(StatusCodes.Status500InternalServerError);

			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> GetAsync(Guid id)
		{
			var getUser = await _userRepository.GetUser(id);
			if(getUser is null)
			{
				return NoContent();
			}
			return Ok(getUser);
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Login(string email, string password)
		{
			var getUser = await _userRepository.Login(email, password);
			if (getUser is null)
			{
				return NoContent();
			}
			var userDto = new UserDTO
			(
				getUser.UserId,
				getUser.Name
			);
			return Ok(userDto);
		}

		[HttpPut("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update(User User)
		{
			var updateUser = await _userRepository.UpdateUserAsync(User);

			if (!updateUser)
				return NoContent();

			return StatusCode(StatusCodes.Status201Created);
		}
	}
}

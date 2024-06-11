using ApiCRUDWeb.Models;
using ApiCRUDWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUDWeb.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PetController: ControllerBase
	{
		private readonly IPetRepository _petRepository;

		public PetController(IPetRepository petRepository)
		{
			_petRepository = petRepository;
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Get(Guid id)
		{
			var getPet = await _petRepository.GetPet(id);
			if (getPet is null)
			{
				return StatusCode(StatusCodes.Status204NoContent);
			}
			return Ok(getPet);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Register([FromBody] Pet pet)
		{
			var createPet = await _petRepository.AddPet(pet);
			if(createPet is null)
			{
				return StatusCode(StatusCodes.Status400BadRequest);
			}
			return StatusCode(StatusCodes.Status201Created);
		}
	}
}

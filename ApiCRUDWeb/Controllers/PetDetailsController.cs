using ApiCRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;
using ApiCRUDWeb.Repositories.Interfaces;

namespace ApiCRUDWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PetDetailsController : ControllerBase
	{
		private readonly IPetDetailsRepository _petDetailsRepository;

		public PetDetailsController(IPetDetailsRepository petDetailsRepository)
		{
			_petDetailsRepository = petDetailsRepository;
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Register([FromBody] PetDetails petDetails)
		{
			var register = await _petDetailsRepository.AddPetDetails(petDetails);
			if(register is null)
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
			var register = await _petDetailsRepository.GetPetDetails(id);
			if (register is null)
			{
				return StatusCode(StatusCodes.Status204NoContent);
			}
			return Ok(register);
		}

		[HttpPut("[action]/{id:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update(Guid id, PetDetails petDetails)
		{
			
			var query = await _petDetailsRepository.UpdatePetDetails(id, petDetails);
			if(query == null)
			{
				return StatusCode(StatusCodes.Status204NoContent);
			}
			return Ok(query);
		}
	}
}

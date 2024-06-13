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

		[HttpPost("[action]/{petId:Guid}")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> RegisterAsync([FromBody] PetDetails petDetails, Guid petId)
		{
			var register = await _petDetailsRepository.AddPetDetails(petDetails, petId);
			if(register is null)
			{
				return BadRequest() ;
			}
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> GetAsync(Guid petId)
		{
			var register = await _petDetailsRepository.GetPetDetails(petId);
			if (register is null)
			{
				return NoContent();
			}
			return Ok(register);
		}

		[HttpPut("[action]/{petId:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> UpdateAsync(Guid petId, [FromBody] PetDetails petDetails)
		{
			
			var query = await _petDetailsRepository.UpdatePetDetails(petId, petDetails);
			if(query == null)
			{
				return NoContent();
			}
			return Ok(query);
		}
	}
}

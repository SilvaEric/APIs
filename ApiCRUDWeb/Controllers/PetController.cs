using ApiCRUDWeb.Models;
using ApiCRUDWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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


		[HttpGet("[action]/{tutorId:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> GetAsync(Guid tutorId, Guid petId)
		{
			var getPet = await _petRepository.GetPet(tutorId, petId);
			if (getPet is null)
			{
				return NoContent();
			}
			return Ok(getPet);
		}

		[HttpGet("[action]/{tutorId:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> GetAllAsync(Guid tutorId)
		{
			var getPet = await _petRepository.GetAllPets(tutorId);
			if (getPet is null)
			{
				return NoContent();
			}
			return Ok(getPet);
		}


		[HttpPost("[action]/{tutorId:Guid}")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> RegisterAsync([FromBody] Pet pet, Guid tutorId)
		{
			var createPet = await _petRepository.AddPet(pet, tutorId);
			if(createPet is null)
			{
				return BadRequest();
			}
			return StatusCode(StatusCodes.Status201Created);
		}


		[HttpPut("[action]/{petId:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateAsync(Guid petId, [FromBody] Pet input)
		{
			var updatePet = await _petRepository.UpdatePet(petId, input);
			if (updatePet is null)
			{
				return NotFound();
			}
			return Ok();
		}


		[HttpDelete("[action]/{tutorId:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DeleteAsync(Guid tutorId, Guid petId)
		{
			if(await _petRepository.DeletePet(tutorId, petId))
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}

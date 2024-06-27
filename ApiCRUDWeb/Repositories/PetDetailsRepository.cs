using ApiCRUDWeb.Data;
using ApiCRUDWeb.Models;
using ApiCRUDWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Repositories
{
	public class PetDetailsRepository : IPetDetailsRepository
	{
		private readonly AppDbContext _context;
		public PetDetailsRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<PetDetails> AddPetDetails(PetDetails petDetails, Guid petId)
		{
			var _pet = await _context.Pets.Where(p => p.PetId == petId).FirstOrDefaultAsync();
			_pet.Details = petDetails;
			await _context.SaveChangesAsync();
			return _pet.Details;
		}
	

		public async Task<PetDetails> GetPetDetails(Guid petId)
		{
			var teste = await _context.PetsDetails.FirstOrDefaultAsync(p => p.PetId == petId);
			if (teste is null)
			{
				throw new InvalidOperationException("Esse pet não existe em nossa base de dados");
			}
			return teste;
		}

		public async Task<PetDetails> UpdatePetDetails(Guid petId, PetDetails input)
		{
			var petDetailsContext = await _context.PetsDetails.SingleOrDefaultAsync(p => p.PetId == petId);
			if (petDetailsContext == null)
				throw new InvalidOperationException("Detalhes do pet não exitem na base de dados");

			
			petDetailsContext.NonPredominantColor = input.NonPredominantColor;
			petDetailsContext.TongueColor = input.TongueColor;
			petDetailsContext.PredominantColor = input.PredominantColor;
			petDetailsContext.Heigth = input.Heigth;
			petDetailsContext.Pelage = input.Pelage;
			petDetailsContext.EyesColor = input.EyesColor;

			_context.PetsDetails.Update(petDetailsContext);
			await _context.SaveChangesAsync();
			return petDetailsContext;
		}
	}
}

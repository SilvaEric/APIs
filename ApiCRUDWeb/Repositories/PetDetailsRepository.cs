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
		public async Task<PetDetails> AddPetDetails(PetDetails petDetails)
		{
			try
			{
				await _context.PetsDetails.AddAsync(petDetails);
				await _context.SaveChangesAsync();
				return petDetails;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao adicionar detalhe do pet");
			}
		}
	

		public async Task<PetDetails> GetPetDetails(Guid id)
		{
			try
			{
				var petdetails = await _context.PetsDetails.FirstOrDefaultAsync(pd => pd.PetId == id);
				if (petdetails is null)
				{
					throw new InvalidOperationException("Esse pet não existe em nossa base de dados");
				}
				return petdetails;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao obter detalhes do pet");
			}
		}

		public async Task<PetDetails> UpdatePetDetails(Guid id, PetDetails newPetDetails)
		{
			var petDetails = await _context.PetsDetails.SingleOrDefaultAsync(pd => pd.Id == id);
			if (petDetails == null)
			{
				throw new InvalidOperationException("Detalhes do pet não exitem na base de dados");
			}
			
			_context.Update(petDetails);
			petDetails = newPetDetails;
			await _context.SaveChangesAsync();
			return newPetDetails;
		}
	}
}

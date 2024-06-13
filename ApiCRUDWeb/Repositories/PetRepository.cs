using ApiCRUDWeb.Data;
using ApiCRUDWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Repositories.Interfaces
{
	public class PetRepository : IPetRepository
	{
		private readonly AppDbContext _context;
		public PetRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<Pet> AddPet(Pet pet, Guid tutorId)
		{
			var _tutor = _context.Users.Where( t => t.UserId == tutorId)
								.FirstOrDefault();
			
			if(_tutor is null)
			{
				throw new InvalidOperationException("não foi possivel adicionar o pet na base de dados");
			}

			pet.Tutor = _tutor;
			var _pet = await _context.Pets.AddAsync(pet);
			await _context.SaveChangesAsync();

			return pet;
		}

		public async Task<bool> DeletePet(Guid tutorId, Guid petId)
		{
			var _pet = await _context.Pets.Where(p => p.Tutor.UserId == tutorId && p.PetId == petId)
											.FirstOrDefaultAsync();
			if(_pet is not null)
			{
				_context.Pets.Remove(_pet);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<Pet>> GetAllPets(Guid tutorId)
		{

			var _pets = await _context.Pets.Where(p => p.UserId == tutorId).ToListAsync();
				
			return _pets;

		}

		public async Task<Pet> GetPet(Guid tutorId, Guid petId)
		{
			var _pet = await _context.Pets.Include(p=>p.Details)
				.Where(pet=> pet.UserId == tutorId && pet.PetId == petId)
				.FirstOrDefaultAsync();
			///await _context.Entry(_pet).Reference(p => p.Details).LoadAsync();
			if(_pet is null)
			{
				throw new InvalidOperationException("Esse pet não existe em nossa base de dados");
			}

			return _pet;
		}

		public async Task<Pet> UpdatePet(Guid petId, Pet input)
		{
			var petContext = await _context.Pets.Where(p => p.PetId == petId)
				.SingleOrDefaultAsync();

			if (petContext is null)
				throw new InvalidOperationException("Este Pet não exite na base de dados");
			
			petContext.Name = input.Name;
			petContext.DateOfBirh = input.DateOfBirh;
			petContext.Name = input.Name;

			_context.Pets.Update(petContext);
			await _context.SaveChangesAsync();

			return petContext;
		}
	}
}

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
		public async Task<Pet> AddPet(Pet pet)
		{
			try
			{
				_context.Pets.Add(pet);
				await _context.SaveChangesAsync();
				return pet;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao adicionar pet");
			}
		}

		public async Task DeletePet(Guid id)
		{
			try
			{
				var pet = await GetPet(id);
				if(pet is not null)
				{
					_context.Pets.Remove(pet);
					await _context.SaveChangesAsync();
				}
				throw new InvalidOperationException("Esse pet não existe em nossa base de dados");
			}

			catch
			{
				throw new InvalidOperationException("Erro ao deletar pet");
			}
		}

		public async Task<List<Pet>> GetAllPets(Guid id)
		{
			try
			{
				List<Pet> pets = new List<Pet>();

				if(_context.Pets.Where(p => p.TutorId == id) is null)
				{
					throw new InvalidOperationException("Não há pet cadastrado");
				}

				foreach(Pet p in _context.Pets.Where(p => p.TutorId == id))
				{
					pets.Add(p);
				}
				
				return pets;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao obter pets");
			}
		}
		public async Task<Pet> GetPet(Guid id)
		{
			try
			{
				var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
				if (pet is null)
				{
					throw new InvalidOperationException("Esse pet não existe em nossa base de dados");
				}
				return pet;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao obter pet");
			}
		}

		public async Task<Pet> UpdatePet(Guid id, Pet newPet)
		{
			var pet = await _context.Pets.SingleOrDefaultAsync(p => p.Id == id);
			if (pet == null)
			{
				throw new InvalidOperationException("Detalhes do pet não exitem na base de dados");
			}

			_context.Update(pet);
			pet = newPet;
			await _context.SaveChangesAsync();
			return newPet;
		}
	}
}

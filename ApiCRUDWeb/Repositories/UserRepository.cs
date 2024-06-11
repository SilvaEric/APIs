using ApiCRUDWeb.Data;
using ApiCRUDWeb.Models;
using ApiCRUDWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;
		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<User> AddUser(User user)
		{
			try 
			{ 
				_context.Users.Add(user);
				await _context.SaveChangesAsync();
				return user;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao adicionar usuario");
			}
		}

		public async Task<List<User>> GetAllUser()
		{
			try
			{
				var users =  await _context.Users.ToListAsync();
				return users;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao obter usuarios");
			}
		}

		public async Task<User> GetUser(Guid id)
		{

			var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

			if(user is not null)
			{
				return user;
			}

			throw new InvalidOperationException("Não foi possivel encontrar o usuário");

		}
	}
}

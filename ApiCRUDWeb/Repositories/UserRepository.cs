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
				await _context.Users.AddAsync(user);
				await _context.SaveChangesAsync();
				return user;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao adicionar usuario");
			}
		}

		public async Task<User> Login(string email, string password)
		{
			try
			{
				var _user = await _context.Users
					.Where(u => u.EmailAdress == email && u.Password == password)
					.FirstOrDefaultAsync();
				return _user;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao obter usuarios");
			}
		}

		public async Task<User> GetUser(Guid id)
		{

			var user = await _context.Users.Include(u => u.Pets)
				.FirstOrDefaultAsync(u => u.UserId == id);

			if(user is not null)
			{
				return user;
			}

			throw new InvalidOperationException("Não foi possivel encontrar o usuário");

		}

		public async Task<bool> RegisterOwnerAsync(Owner owner)
		{
			var _user = await _context.Users.Where(u => u.UserId == owner.UserId)
				.FirstOrDefaultAsync();
			
			if(_user is not null)
			{
				var remove = _context.Users.Remove(_user);

				if (remove.State != EntityState.Deleted)
					return false;

				await _context.SaveChangesAsync();
			}

			var add = await _context.Users.AddAsync(owner);
			if (add.State != EntityState.Added)
				return false;

			await _context.SaveChangesAsync();


			return true;
		}

		public async Task<bool> RegisterInstitutionAsync(Institution institution)
		{
			var _user = await _context.Users.Where(u => u.UserId == institution.UserId)
				.FirstOrDefaultAsync();

			if(_user is not null)
			{
				var remove = _context.Users.Remove(_user);

				if (remove.State != EntityState.Deleted)
					return false;
				
				await _context.SaveChangesAsync();
			}
			
			var add = await _context.Users.AddAsync(institution);
			if (add.State != EntityState.Added)
				return false;

			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> UpdateUserAsync(User user)
		{
			var _user = await _context.Users.Where(u => u.UserId == user.UserId)
				.FirstOrDefaultAsync();

			if (_user is null)
				return false;

			_user.Name = user.Name;
			_user.Adress = user.Adress;
			_user.EmailAdress = user.EmailAdress;
			_user.PhoneNumber = user.PhoneNumber;
			_user.Password = user.Password;

			_context.Update(_user);
			await _context.SaveChangesAsync();

			return true;
;		}
	}
}

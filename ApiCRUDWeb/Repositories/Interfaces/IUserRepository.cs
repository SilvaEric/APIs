using System.Collections.Generic;
using ApiCRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUDWeb.Repositories.Interfaces
{
    public interface IUserRepository
    {
		Task<User> AddUser(User user);

		Task<User> GetUser(Guid id);

		Task<User> Login(string email, string password);

		Task<bool> RegisterOwnerAsync(Owner user);

		Task<bool> RegisterInstitutionAsync(Institution user);

		Task<bool> UpdateUserAsync(User user);

	}
}

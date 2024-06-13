using System.Collections.Generic;
using ApiCRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUDWeb.Repositories.Interfaces
{
    public interface IUserRepository
    {
		Task<User> AddUser(User user);

		Task<User> GetUser(Guid id);

		Task<ICollection<User>> GetAllUser();

	}
}

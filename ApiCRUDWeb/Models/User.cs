using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Models
{
	public class User
	{
		public Guid Id { get; set; } 
		public string Name { get; set; } 
		public string Login { get; set; } 
		public string EmailAdress { get; set; } 
		public string Password { get; set; }
		public ICollection<Pet> Pets { get; set; } = new List<Pet>();
	}
}

using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Models
{
	public class User
	{
		public Guid Id { get; set; } 
		[Required]
		public string Name { get; set; }
		[Required]
		public string Login { get; set; }
		[Required]
		public string EmailAdress { get; set; }
		[Required]
		public string Password { get; set; }
		public ICollection<Pet>? Pets { get; set; }
	}
}

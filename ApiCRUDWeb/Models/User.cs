using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCRUDWeb.Models
{
	public class User
	{
		public Guid? UserId { get; set; } 
		[Required]
		public string Name { get; set; }
		[Required]
		public string EmailAdress { get; set; }
		[Required]
		public string Password { get; set; }
		public string? Adress { get; set; }
		public string? PhoneNumber { get; set; }
		public List<Pet>? Pets { get; set; }
	}
}

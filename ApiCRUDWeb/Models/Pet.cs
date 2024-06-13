using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCRUDWeb.Models
{
	public class Pet
	{
		public Guid? PetId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime DateOfBirh { get; set; }
		[Required]
		public string Breed { get; set; }
		public PetDetails? Details{ get; set; }
		[JsonIgnore]
		public Guid UserId { get; set; }
		[JsonIgnore]
		public User? Tutor { get; set; }
	}
}
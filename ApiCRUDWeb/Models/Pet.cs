using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Models
{
	public class Pet
	{
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime DateOfBirh { get; set; }
		[Required]
		public string Breed { get; set; }
		public PetDetails? Details{ get; set; }
		public Guid TutorId { get; set;  }
		[Required]
		public User Tutor { get; set; }
	}
}
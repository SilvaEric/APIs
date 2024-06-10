using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Models
{
	public class Pet
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirh { get; set; }
		public string Breed { get; set; }
		public PetDetails? Details{ get; set; }
		public Guid TutorId { get; set;  }
		public User Tutor { get; set; }
	}
}
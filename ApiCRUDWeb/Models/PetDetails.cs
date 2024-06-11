using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiCRUDWeb.Models
{
	public class PetDetails
	{	
		[Key]
		public Guid Id { get; set;  } 
		public string PredominantColor { get; set; } 
		public string NonPredominantColor { get; set; } 
		public double Heigth { get; set; } 
		public string Pelage { get; set; }
		public string EyesColor { get; set; } 
		public string TongueColor { get; set; }
		public Guid PetId { get; set; }
		public Pet Pet { get; set; }
	}
}
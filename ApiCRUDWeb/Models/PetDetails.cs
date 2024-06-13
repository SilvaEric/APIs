using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiCRUDWeb.Models
{
	public class PetDetails
	{
		[JsonIgnore]
		public Guid PetDetailsId { get; set;  }
		[Required]
		public string PredominantColor { get; set; } 
		public string? NonPredominantColor { get; set; }
		[Required]
		public double Heigth { get; set; }
		[Required]
		public string? Pelage { get; set; }
		[Required]
		public string EyesColor { get; set; }
		public string? TongueColor { get; set; }
		[JsonIgnore]
		public Pet? Pet { get; set; }
		[JsonIgnore]
		public Guid? PetId { get; set; }
	}
}
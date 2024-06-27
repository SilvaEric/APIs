namespace ApiCRUDWeb.Models
{
	public class Owner : User
	{ 
		public DateTime DateOfBirth { get; set; }
		public string CPF { get; set; }  
	}
}
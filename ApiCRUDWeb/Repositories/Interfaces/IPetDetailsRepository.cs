using ApiCRUDWeb.Models;

namespace ApiCRUDWeb.Repositories.Interfaces
{
    public interface IPetDetailsRepository
    {
		Task<PetDetails> GetPetDetails(Guid id);
		Task<PetDetails> UpdatePetDetails(Guid id, PetDetails petDetails);
		Task<PetDetails> AddPetDetails(PetDetails petDetails);

	}
}

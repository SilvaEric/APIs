using ApiCRUDWeb.Models;

namespace ApiCRUDWeb.Repositories.Interfaces
{
    public interface IPetDetailsRepository
    {
		Task<PetDetails> GetPetDetails(Guid petId);
		Task<PetDetails> UpdatePetDetails(Guid petId, PetDetails petDetails);
		Task<PetDetails> AddPetDetails(PetDetails petDetails, Guid petId);

	}
}

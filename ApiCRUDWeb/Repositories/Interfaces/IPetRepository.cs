using ApiCRUDWeb.Models;

namespace ApiCRUDWeb.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAllPets(Guid tutorId);
        Task<Pet> GetPet(Guid tutorId, Guid petId);
        Task<Pet> UpdatePet(Guid petId, Pet input);
        Task<Pet> AddPet(Pet pet, Guid tutorId);
        Task<bool> DeletePet(Guid tutorId, Guid petId);

    }
}

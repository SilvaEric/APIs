using ApiCRUDWeb.Models;

namespace ApiCRUDWeb.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAllPets(Guid id);
        Task<Pet> GetPet(Guid id);
        Task<Pet> UpdatePet(Guid id, Pet pet);
        Task<Pet> AddPet(Pet pet);
        Task DeletePet(Guid id);

    }
}

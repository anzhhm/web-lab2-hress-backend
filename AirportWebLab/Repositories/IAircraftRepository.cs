using AirportWebLab.Models;

namespace AirportWebLab.Repositories
{
    public interface IAircraftRepository
    {
        Task<IEnumerable<Aircraft>> GetAllAsync();
        Task<Aircraft?> GetByIdAsync(int id);
        Task AddAsync(Aircraft aircraft);
        Task UpdateAsync(Aircraft aircraft);
        Task DeleteAsync(int id);
    }
}

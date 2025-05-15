using AirportWebLab.Models;
using AirportWebLab.Repositories;

namespace AirportWebLab.Services
{
    public class AircraftService
    {
        private readonly IAircraftRepository _repository;

        public AircraftService(IAircraftRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Aircraft>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Aircraft?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Aircraft aircraft) => _repository.AddAsync(aircraft);

        public Task UpdateAsync(Aircraft aircraft) => _repository.UpdateAsync(aircraft);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }

}

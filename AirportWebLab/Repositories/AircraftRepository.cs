using AirportWebLab.Data;
using AirportWebLab.Models;
using Microsoft.EntityFrameworkCore;


namespace AirportWebLab.Repositories
{
    // Repositories/Implementations/AircraftRepository.cs
    public class AircraftRepository : IAircraftRepository
    {
        private readonly AirlineContext _context;

        public AircraftRepository(AirlineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aircraft>> GetAllAsync()
        {
            return await _context.Aircrafts
                .Include(a => a.Manufacturer)
                .Include(a => a.Company)
                .ToListAsync();
        }

        public async Task<Aircraft?> GetByIdAsync(int id)
        {
            return await _context.Aircrafts
                .Include(a => a.Manufacturer)
                .Include(a => a.Company)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Aircraft aircraft)
        {
            _context.Aircrafts.Add(aircraft);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aircraft aircraft)
        {
            var existingAircraft = await _context.Aircrafts
                .FirstOrDefaultAsync(a => a.Id == aircraft.Id);

            if (existingAircraft == null)
            {
                throw new ArgumentException("Aircraft not found");
            }

            existingAircraft.Model = aircraft.Model;
            existingAircraft.Capacity = aircraft.Capacity;
            existingAircraft.ManufacturerId = aircraft.ManufacturerId;
            existingAircraft.CompanyId = aircraft.CompanyId;

            var manufacturerExists = await _context.Manufacturers
                .AnyAsync(m => m.Id == aircraft.ManufacturerId);
            if (!manufacturerExists)
            {
                throw new ArgumentException("Manufacturer not found");
            }

            var companyExists = await _context.Companies
                .AnyAsync(c => c.Id == aircraft.CompanyId);
            if (!companyExists)
            {
                throw new ArgumentException("Company not found");
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Aircrafts.FindAsync(id);
            if (entity != null)
            {
                _context.Aircrafts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

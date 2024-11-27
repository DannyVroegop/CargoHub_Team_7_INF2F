using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the Location model

namespace Services
{
    public class LocationService : ILocationService
    {
        private readonly CargoContext _context;

        public LocationService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id); // Retrieve location by ID
        }

        public async Task<Location> AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location?> UpdateLocationAsync(int id, Location updatedLocation)
        {
            var existingLocation = await _context.Locations.FindAsync(id);

            if (existingLocation == null)
            {
                return null; // Return null if the location doesn't exist
            }

            // Update the fields of the existing location
            existingLocation.Warehouse_Id = updatedLocation.Warehouse_Id;
            existingLocation.Code = updatedLocation.Code;
            existingLocation.Name = updatedLocation.Name;
            existingLocation.Created_at = updatedLocation.Created_at;
            existingLocation.Updated_at = updatedLocation.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingLocation; // Return the updated location
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return false; // Return false if the location doesn't exist
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return true; // Return true if the location was successfully deleted
        }
    }
}
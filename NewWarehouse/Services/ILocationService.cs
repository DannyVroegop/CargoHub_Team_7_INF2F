using Models; // Namespace for the Location model

namespace Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
        Task<Location> AddLocationAsync(Location location);
        Task<Location?> UpdateLocationAsync(int id, Location updatedlocation);
        Task<bool> DeleteLocationAsync(int id);
    }
}

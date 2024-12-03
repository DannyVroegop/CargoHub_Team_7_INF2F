using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the Client model

namespace Services
{
    public class ClientService : IClientService
    {
        private readonly CargoContext _context;

        public ClientService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id); // Retrieve Client by ID
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> UpdateClientAsync(int id, Client updatedClient)
        {
            var existingClient = await _context.Clients.FindAsync(id);

            if (existingClient == null)
            {
                return null; // Return null if the Client doesn't exist
            }

            // Update the fields of the existing Client
            existingClient.Name = updatedClient.Name;
            existingClient.Address = updatedClient.Address;
            existingClient.City = updatedClient.City;
            existingClient.Zip_Code = updatedClient.Zip_Code;
            existingClient.Province = updatedClient.Province;
            existingClient.Country = updatedClient.Country;
            existingClient.Contact_Name = updatedClient.Contact_Name;
            existingClient.Contact_Phone = updatedClient.Contact_Phone;
            existingClient.Contact_Email = updatedClient.Contact_Email;
            existingClient.Created_at = updatedClient.Created_at;
            existingClient.Updated_at = updatedClient.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingClient; // Return the updated Client
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return false; // Return false if the Client doesn't exist
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true; // Return true if the client was successfully deleted
        }
    }
}
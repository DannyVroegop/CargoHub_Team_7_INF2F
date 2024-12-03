using Models; // Namespace for the Client model

namespace Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> AddClientAsync(Client client);
        Task<Client?> UpdateClientAsync(int id, Client updatedclient);
        Task<bool> DeleteClientAsync(int id);
    }
}

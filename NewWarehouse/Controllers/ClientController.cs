using Microsoft.AspNetCore.Mvc;
using Models; // For Client
using Services;

namespace Controllers
{
    [Route("api/v2/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/v2/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        // GET: api/v2/clients/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound(); // Return 404 if Client not found
            }
            return Ok(client); // Return the Client 
        }

        // POST: api/v2/clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }
            var createdClient = await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClients), new { id = createdClient.Id }, createdClient);
        }

        // PUT: api/v2/clients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest("Client ID mismatch.");
            }

            var updatedClient = await _clientService.UpdateClientAsync(id, client);

            if (updatedClient == null)
            {
                return NotFound();
            }
            return Ok(updatedClient);
        }

        // DELETE: api/v2/clients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound(); // Return 404 if the Client is not found
            }

            var result = await _clientService.DeleteClientAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the client."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }

    }
}
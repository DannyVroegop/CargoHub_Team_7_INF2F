using Microsoft.AspNetCore.Mvc;
using Models; // For Location
using Services;

namespace Controllers
{
    [Route("api/v2/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/v2/locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/v2/locations/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound(); // Return 404 if location not found
            }
            return Ok(location); // Return the location 
        }

        // POST: api/v2/locations
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocatione(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }
            var createdLocation = await _locationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetLocations), new { id = createdLocation.Id }, createdLocation);
        }

        // PUT: api/v2/locations/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest("Location ID mismatch.");
            }

            var updatedLocation = await _locationService.UpdateLocationAsync(id, location);

            if (updatedLocation == null)
            {
                return NotFound();
            }
            return Ok(updatedLocation);
        }

        // DELETE: api/v2/locations/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound(); // Return 404 if the location is not found
            }

            var result = await _locationService.DeleteLocationAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the location."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }

    }
}
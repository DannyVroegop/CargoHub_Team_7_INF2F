using Microsoft.AspNetCore.Mvc;
using Models; // For Shipment and ShipmentItem models
using Services;

namespace Controllers
{
    [Route("api/v2/shipments")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        // GET: api/v2/shipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentDTO>>> GetShipments()
        {
            var shipments = await _shipmentService.GetAllShipmentsAsync();
            var shipmentDTOs = shipments.Select(MapShipmentToDTO);
            return Ok(shipmentDTOs);
        }

        // GET: api/v2/shipments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentDTO>> GetShipmentById(int id)
        {
            var shipment = await _shipmentService.GetShipmentByIdAsync(id);
            if (shipment == null)
            {
                return NotFound(); // Return 404 if shipment not found
            }

            var shipmentDTO = MapShipmentToDTO(shipment);
            return Ok(shipmentDTO); // Return the shipment DTO
        }

        // POST: api/v2/shipments
        [HttpPost]
        public async Task<ActionResult<ShipmentDTO>> PostShipment([FromBody] ShipmentDTO shipmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Map DTO to Shipment entity
            var shipment = MapDTOToShipment(shipmentDTO);

            // Save Shipment to the database
            var createdShipment = await _shipmentService.AddShipmentAsync(shipment);

            // Map created Shipment back to DTO
            var createdShipmentDto = MapShipmentToDTO(createdShipment);

            // Return the created Shipment
            return CreatedAtAction(nameof(GetShipments), new { id = createdShipmentDto.Id }, createdShipmentDto);
        }

        // PUT: api/v2/shipments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment(int id, ShipmentDTO shipmentDTO)
        {
            if (id != shipmentDTO.Id)
            {
                return BadRequest("Shipment ID mismatch.");
            }

            // Map DTO to Model
            var shipment = MapDTOToShipment(shipmentDTO);

            var updatedShipment = await _shipmentService.UpdateShipmentAsync(id, shipment);

            if (updatedShipment == null)
            {
                return NotFound();
            }

            // Map Model back to DTO for the response
            var updatedShipmentDTO = MapShipmentToDTO(updatedShipment);
            return Ok(updatedShipmentDTO);
        }

        // DELETE: api/v2/shipments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipments(int id)
        {
            var shipment = await _shipmentService.GetShipmentByIdAsync(id);
            if (shipment == null)
            {
                return NotFound(); // Return 404 if the shipment is not found
            }

            var result = await _shipmentService.DeleteShipmentAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the shipment."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }


        private ShipmentDTO MapShipmentToDTO(Shipment shipment)
        {
            return new ShipmentDTO
            {
                Id = shipment.Id,
                Order_Id = shipment.Order_Id,
                Source_Id = shipment.Source_Id,
                Order_Date = shipment.Order_Date,
                Request_date = shipment.Request_date,

                Shipment_Date = shipment.Shipment_Date,
                Shipment_Type = shipment.Shipment_Type,
                Shipment_Status = shipment.Shipment_Status,
                Notes = shipment.Notes,
                Carrier_Code = shipment.Carrier_Code,
                Carrier_Description = shipment.Carrier_Description,
                Service_Code = shipment.Service_Code,
                Payment_Type = shipment.Payment_Type,
                Transfer_Mode = shipment.Transfer_Mode,
                Total_Package_Count = shipment.Total_Package_Count,
                Total_Package_Weight = shipment.Total_Package_Weight,
                Created_at = shipment.Created_at,
                Updated_at = shipment.Updated_at,
                Items = shipment.Items?.Select(item => new ShipmentItemDTO
                {
                    Item_Id = item.Item_Uid,
                    Amount = item.Quantity
                }).ToList()
            };
        }


        private Shipment MapDTOToShipment(ShipmentDTO shipmentDto)
        {
            return new Shipment
            {
                Id = shipmentDto.Id,
                Order_Id = shipmentDto.Order_Id,
                Source_Id = shipmentDto.Source_Id,
                Order_Date = shipmentDto.Order_Date,
                Request_date = shipmentDto.Request_date,
                Shipment_Date = shipmentDto.Shipment_Date,
                Shipment_Type = shipmentDto.Shipment_Type,
                Shipment_Status = shipmentDto.Shipment_Status,
                Notes = shipmentDto.Notes,
                Carrier_Code = shipmentDto.Carrier_Code,
                Carrier_Description = shipmentDto.Carrier_Description,
                Service_Code = shipmentDto.Service_Code,
                Payment_Type = shipmentDto.Payment_Type,
                Transfer_Mode = shipmentDto.Transfer_Mode,
                Total_Package_Count = shipmentDto.Total_Package_Count,
                Total_Package_Weight = shipmentDto.Total_Package_Weight,
                Created_at = shipmentDto.Created_at,
                Updated_at = shipmentDto.Updated_at,
                Items = shipmentDto.Items?.Select(itemDto => new ShipmentItem
                {
                    Item_Uid = itemDto.Item_Id,
                    Quantity = itemDto.Amount
                }).ToList()
            };
        }
    }
}

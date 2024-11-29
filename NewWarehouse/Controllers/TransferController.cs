using Microsoft.AspNetCore.Mvc;
using Models; // For Transfer and TransferItem models
using Services;

namespace Controllers
{
    [Route("api/v2/transfers")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        // GET: api/v2/transfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferDTO>>> GetTransfers()
        {
            var transfers = await _transferService.GetAllTransfersAsync();
            var transferDTOs = transfers.Select(MapTransferToDTO);
            return Ok(transferDTOs);
        }

        // GET: api/v2/transfers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransferDTO>> GetTransferById(int id)
        {
            var transfer = await _transferService.GetTransferByIdAsync(id);
            if (transfer == null)
            {
                return NotFound(); // Return 404 if transfer not found
            }

            var transferDTO = MapTransferToDTO(transfer);
            return Ok(transferDTO); // Return the transfer DTO
        }

        // POST: api/v2/transfers
        [HttpPost]
        public async Task<ActionResult<TransferDTO>> PostTransfer([FromBody] TransferDTO transferDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Map DTO to Transfer entity
            var transfer = MapDTOToTransfer(transferDto);

            // Save Transfer to the database
            var createdTransfer = await _transferService.AddTransferAsync(transfer);

            // Map created Transfer back to DTO
            var createdTransferDto = MapTransferToDTO(createdTransfer);

            // Return the created Transfer
            return CreatedAtAction(nameof(GetTransfers), new { id = createdTransferDto.Id }, createdTransferDto);
        }

        // PUT: api/v2/transfers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransfer(int id, TransferDTO transferDTO)
        {
            if (id != transferDTO.Id)
            {
                return BadRequest("Transfer ID mismatch.");
            }

            // Map DTO to Model
            var transfer = MapDTOToTransfer(transferDTO);

            var updatedTransfer = await _transferService.UpdateTransferAsync(id, transfer);

            if (updatedTransfer == null)
            {
                return NotFound();
            }

            // Map Model back to DTO for the response
            var updatedTransferDTO = MapTransferToDTO(updatedTransfer);
            return Ok(updatedTransferDTO);
        }

        // DELETE: api/v2/transfers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransfer(int id)
        {
            var transfer = await _transferService.GetTransferByIdAsync(id);
            if (transfer == null)
            {
                return NotFound(); // Return 404 if the transfer is not found
            }

            var result = await _transferService.DeleteTransferAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the transfer."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }


        private TransferDTO MapTransferToDTO(Transfer transfer)
        {
            return new TransferDTO
            {
                Id = transfer.Id,
                Reference = transfer.Reference,
                Transfer_From = transfer.Transfer_From,
                Transfer_To = transfer.Transfer_To,
                Transfer_Status = transfer.Transfer_Status,
                Created_at = transfer.Created_at,
                Updated_at = transfer.Updated_at,
                Items = transfer.TransferItems?.Select(item => new TransferItemDTO
                {
                    Item_Id = item.Item_Uid,
                    Amount = item.Quantity
                }).ToList()
            };
        }


        private Transfer MapDTOToTransfer(TransferDTO transferDto)
        {
            return new Transfer
            {
                Id = transferDto.Id,
                Reference = transferDto.Reference,
                Transfer_From = transferDto.Transfer_From,
                Transfer_To = transferDto.Transfer_To,
                Transfer_Status = transferDto.Transfer_Status,
                Created_at = transferDto.Created_at,
                Updated_at = transferDto.Updated_at,
                TransferItems = transferDto.Items?.Select(itemDto => new TransferItem
                {
                    Item_Uid = itemDto.Item_Id,
                    Quantity = itemDto.Amount
                }).ToList()
            };
        }
    }
}

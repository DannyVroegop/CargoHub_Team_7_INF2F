using Models; // Namespace for the Shipment model

namespace Services
{
    public interface IShipmentService
    {
        Task<IEnumerable<Shipment>> GetAllShipmentsAsync();
        Task<Shipment> GetShipmentByIdAsync(int id);
        Task<Shipment> AddShipmentAsync(Shipment shipmentDto);
        Task<Shipment?> UpdateShipmentAsync(int id, Shipment updatedshipment);
        Task<bool> DeleteShipmentAsync(int id);
    }
}

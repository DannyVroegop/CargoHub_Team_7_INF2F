using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Shipment{
        public int Id{ get; set; }
        public int Order_Id{ get; set; }
        public int Source_Id{ get; set; }
        public string Order_Date{ get; set; }
        public string Request_date{ get; set; }
        public string Shipment_Date{ get; set; }
        public string Shipment_Type{ get; set; }
        public string Shipment_Status{ get; set; }
        public string Notes{ get; set; }
        public string Carrier_Code{ get; set; }
        public string Carrier_Description{ get; set; }
        public string Service_Code{ get; set; }
        public string Payment_Type{ get; set; }
        public string Transfer_Mode{ get; set; }
        public int Total_Package_Count{ get; set; }
        public double Total_Package_Weight{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        public ICollection<ShipmentItem> ShipmentItems { get; set; }

        public Shipment(){}

        public Shipment(int id,int order_Id, int source_Id, string order_Date, string request_date , string shipment_Date, string shipment_Type, string shipment_Status, string notes, string carrier_Code, string carrier_Description, string service_Code, string payment_Type, string transfer_Mode, int total_Package_Count, double total_Package_Weight, string created_at, string updated_at, ICollection<ShipmentItem> shipmentItems){
            Id = id;
            Order_Id = order_Id;
            Source_Id = source_Id;
            Order_Date = order_Date;
            Request_date = request_date;
            Shipment_Date = shipment_Date;
            Shipment_Type = shipment_Type;
            Shipment_Status = shipment_Status;
            Notes = notes;
            Carrier_Code = carrier_Code;
            Carrier_Description = carrier_Description;
            Service_Code = service_Code;
            Payment_Type = payment_Type;
            Transfer_Mode = transfer_Mode;
            Total_Package_Count = total_Package_Count;
            Total_Package_Weight = total_Package_Weight;
            Created_at = created_at;
            Updated_at = updated_at;
            ShipmentItems = shipmentItems;
        }
    }

    public class ShipmentDTO
    {
        public int Id { get; set; } // Optional for input, but useful for mapping back to the full object
        public int Order_Id { get; set; }
        public int Source_Id { get; set; }
        public string Order_Date { get; set; }
        public string Request_date { get; set; }
        public string Shipment_Date { get; set; }
        public string Shipment_Type { get; set; }
        public string Shipment_Status { get; set; }
        public string Notes { get; set; }
        public string Carrier_Code { get; set; }
        public string Carrier_Description { get; set; }
        public string Service_Code { get; set; }
        public string Payment_Type { get; set; }
        public string Transfer_Mode { get; set; }
        public int Total_Package_Count { get; set; }
        public double Total_Package_Weight { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        
        // List of ShipmentItemDTO to represent items in the shipment
        public List<ShipmentItemDTO> ShipmentItems { get; set; }
        
        public ShipmentDTO()
        {
            ShipmentItems = new List<ShipmentItemDTO>();
        }
    }

    public class ShipmentItemDTO
    {
        public string Item_Id { get; set; } // The ID of the item in the shipment
        public int Amount { get; set; } // The quantity or amount of the item in the shipment
    }
}
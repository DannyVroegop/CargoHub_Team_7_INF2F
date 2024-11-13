using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Shipment{
        public int Id{ get; set; }
        public int OrderId{ get; set; }
        public int SourceId{ get; set; }
        public string OrderDate{ get; set; }
        public string Requestdate{ get; set; }
        public string ShipmentDate{ get; set; }
        public string ShipmentType{ get; set; }
        public string ShipmentStatus{ get; set; }
        public string Notes{ get; set; }
        public string CarrierCode{ get; set; }
        public string CarrierDescription{ get; set; }
        public string ServiceCode{ get; set; }
        public string PaymentType{ get; set; }
        public string TransferMode{ get; set; }
        public int TotalPackageCount{ get; set; }
        public double TotalPackageWeight{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        public Dictionary<int, int> Items{ get; set; }

        public Shipment(){}

        public Shipment(int id,int orderId, int sourceId, string orderDate, string requestdate , string shipmentDate, string shipmentType, string shipmentStatus, string notes, string carrierCode, string carrierDescription, string serviceCode, string paymentType, string transferMode, int totalPackageCount, double totalPackageWeight, string created_at, string updated_at, Dictionary<int, int> items){
            Id = id;
            OrderId = orderId;
            SourceId = sourceId;
            OrderDate = orderDate;
            Requestdate = requestdate;
            ShipmentDate = shipmentDate;
            ShipmentType = shipmentType;
            ShipmentStatus = shipmentStatus;
            Notes = notes;
            CarrierCode = carrierCode;
            CarrierDescription = carrierDescription;
            ServiceCode = serviceCode;
            PaymentType = paymentType;
            TransferMode = transferMode;
            TotalPackageCount = totalPackageCount;
            TotalPackageWeight = totalPackageWeight;
            Created_at = created_at;
            Updated_at = updated_at;
            Items = items;
        }
    }
}
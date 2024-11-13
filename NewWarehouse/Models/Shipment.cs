using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Shipment{
        public int Id;
        public int OrderId;
        public int SourceId;
        public string OrderDate;
        public string Requestdate;
        public string ShipmentDate;
        public string ShipmentType;
        public string ShipmentStatus;
        public string Notes;
        public string CarrierCode;
        public string CarrierDescription;
        public string ServiceCode;
        public string PaymentType;
        public string TransferMode;
        public int TotalPackageCount;
        public double TotalPackageWeight;
        public string Created_at;
        public string Updated_at;
        public Dictionary<int, int> Items;

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
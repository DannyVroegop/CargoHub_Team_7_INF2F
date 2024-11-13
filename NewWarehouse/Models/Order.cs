using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Order{
        public int Id;
        public int SourceId;
        public string OrderDate;
        public string Requestdate;
        public string Reference;
        public string ReferenceExtra;
        public string OrderStatus;
        public string Notes;
        public string ShippingNotes;
        public string PickingNotes;
        public int WarehouseId;
        public int ShipTo;
        public int BillTo;
        public int ShipmentId;
        public double TotalAmmount;
        public double TotalDiscount;
        public double TotalTax;
        public double TotalSurcharge;
        public string Created_at;
        public string Updated_at;
        public Dictionary<int, int> Items;

        public Order(int id, int sourceId, string orderDate, string requestdate , string reference, string referenceExtra, string orderStatus, string notes, string shippingNotes, string pickingnotes, int warehouseId, int shipTo, int billTo, int shipmentId, double totalAmmount, double totalDiscount, double totalTax, double totalSurcharge, string created_at, string updated_at, Dictionary<int, int> items){
            Id = id;
            SourceId = sourceId;
            OrderDate = orderDate;
            Requestdate = requestdate;
            Reference = reference;
            ReferenceExtra = referenceExtra;
            OrderStatus = orderStatus;
            Notes = notes;
            ShippingNotes = shippingNotes;
            PickingNotes = pickingnotes;
            WarehouseId = warehouseId;
            ShipTo = shipTo;
            BillTo = billTo;
            ShipmentId = shipmentId;
            TotalAmmount = totalAmmount;
            TotalDiscount = totalDiscount;
            TotalTax = totalTax;
            TotalSurcharge = totalSurcharge;
            Created_at = created_at;
            Updated_at = updated_at;
            Items = items;
        }
    }
}
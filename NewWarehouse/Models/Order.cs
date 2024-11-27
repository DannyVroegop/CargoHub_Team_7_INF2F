using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{
    public class Order{
        public int Id{ get; set; }
        public int SourceId{ get; set; }
        public string OrderDate{ get; set; }
        public string Requestdate{ get; set; }
        public string Reference{ get; set; }
        public string ReferenceExtra{ get; set; }
        public string OrderStatus{ get; set; }
        public string Notes{ get; set; }
        public string ShippingNotes{ get; set; }
        public string PickingNotes{ get; set; }
        public int WarehouseId{ get; set; }
        public int ShipTo{ get; set; }
        public int BillTo{ get; set; }
        public int ShipmentId{ get; set; }
        public double TotalAmmount{ get; set; }
        public double TotalDiscount{ get; set; }
        public double TotalTax{ get; set; }
        public double TotalSurcharge{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        #pragma warning disable CS8618
        public Order(){}
        #pragma warning restore CS8618
        public Order(int id, int sourceId, string orderDate, string requestdate , string reference, string referenceExtra, string orderStatus, string notes, string shippingNotes, string pickingnotes, int warehouseId, int shipTo, int billTo, int shipmentId, double totalAmmount, double totalDiscount, double totalTax, double totalSurcharge, string created_at, string updated_at, ICollection<OrderItem> orderItems){
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
            OrderItems = orderItems;
        }
    }
}
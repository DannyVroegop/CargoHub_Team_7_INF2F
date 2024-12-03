using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{
    public class Order{
        public int Id{ get; set; }
        public int Source_Id{ get; set; }
        public string Order_Date{ get; set; }
        public string Request_date{ get; set; }
        public string Reference{ get; set; }
        public string Reference_Extra{ get; set; }
        public string Order_Status{ get; set; }
        public string Notes{ get; set; }
        public string Shipping_Notes{ get; set; }
        public string Picking_Notes{ get; set; }
        public int Warehouse_Id{ get; set; }
        public int Ship_To{ get; set; }
        public int Bill_To{ get; set; }
        public int Shipment_Id{ get; set; }
        public double Total_Ammount{ get; set; }
        public double Total_Discount{ get; set; }
        public double Total_Tax{ get; set; }
        public double Total_Surcharge{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order(){}

        public Order(int id, int source_Id, string order_Date, string request_date , string reference, string order_Status, string notes, string shipping_Notes, string picking_notes, int warehouse_Id, int ship_To, int bill_To, int shipment_Id, double total_Ammount, double total_Discount, double total_Tax, double total_Surcharge, string created_at, string updated_at, ICollection<OrderItem> orderItems, string reference_Extra = "empty"){
            Id = id;
            Source_Id = source_Id;
            Order_Date = order_Date;
            Request_date = request_date;
            Reference = reference;
            Reference_Extra = reference_Extra;
            Order_Status = order_Status;
            Notes = notes;
            Shipping_Notes = shipping_Notes;
            Picking_Notes = picking_notes;
            Warehouse_Id = warehouse_Id;
            Ship_To = ship_To;
            Bill_To = bill_To;
            Shipment_Id = shipment_Id;
            Total_Ammount = total_Ammount;
            Total_Discount = total_Discount;
            Total_Tax = total_Tax;
            Total_Surcharge = total_Surcharge;
            Created_at = created_at;
            Updated_at = updated_at;
            OrderItems = orderItems;
        }
    }
    public class OrderDTO
    {
        public int Id { get; set; } // Optional for input, useful for mapping
        public int Source_Id { get; set; }
        public string Order_Date { get; set; }
        public string Request_date { get; set; }
        public string Reference { get; set; }
        public string Reference_Extra { get; set; } = "empty";
        public string Order_Status { get; set; }
        public string Notes { get; set; }
        public string Shipping_Notes { get; set; }
        public string Picking_Notes { get; set; }
        public int Warehouse_Id { get; set; }
        public int Ship_To { get; set; }
        public int Bill_To { get; set; }
        public int Shipment_Id { get; set; }
        public double Total_Ammount { get; set; }
        public double Total_Discount { get; set; }
        public double Total_Tax { get; set; }
        public double Total_Surcharge { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // List of OrderItemDTO to represent items in the order
        public List<OrderItemDTO> OrderItems { get; set; }

        public OrderDTO()
        {
            OrderItems = new List<OrderItemDTO>();
        }
    }

    public class OrderItemDTO
    {
        public string Item_Id { get; set; } // The ID of the item in the order
        public int Quantity { get; set; } // Quantity of the item
        public double Unit_Price { get; set; } // Unit price of the item
        public double Discount { get; set; } // Discount applied to the item
        public double Tax { get; set; } // Tax applied to the item
        public double Surcharge { get; set; } // Surcharge applied to the item
    }
}
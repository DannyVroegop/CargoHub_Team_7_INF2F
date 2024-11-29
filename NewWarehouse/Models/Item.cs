using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Item{
        public string Uid{ get; set; }
        public string Code{ get; set; }
        public string Description{ get; set; }
        public string Short_Description{ get; set; }
        public string Upc_Code{ get; set; }
        public string Model_Number{ get; set; }
        public string Commodity_Code{ get; set; }
        public int Item_Line{ get; set; }
        public int Item_Group{ get; set; }
        public int Item_Type{ get; set; }
        public int Unit_Purchase_Quantity{ get; set; }
        public int Unit_Order_Quantity{ get; set; }
        public int Pack_Order_Quantity{ get; set; }
        public int Supplier_Id{ get; set; }
        public string Supplier_Code{ get; set; }
        public string Supplier_Part_Number{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }

        public Item(){}

        public Item(string uid, string code, string description, string short_Description, string upc_Code, string model_Number, string commodity_Code, int item_Line, int item_Group, int item_Type, int unit_Purchase_Quantity, int unit_Order_Quantity, int pack_Order_Quantity, int supplier_Id, string supplier_Code, string supplier_Part_Number, string created_at, string updated_at){
            Uid = uid;
            Code = code;
            Description = description;
            Short_Description = short_Description;
            Upc_Code = upc_Code;
            Model_Number = model_Number;
            Commodity_Code = commodity_Code;
            Item_Line = item_Line;
            Item_Group = item_Group;
            Item_Type = item_Type;
            Unit_Purchase_Quantity = unit_Purchase_Quantity;
            Unit_Order_Quantity = unit_Order_Quantity;
            Pack_Order_Quantity = pack_Order_Quantity;
            Supplier_Id = supplier_Id;
            Supplier_Code = supplier_Code;
            Supplier_Part_Number = supplier_Part_Number;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Item{
        public int Id;
        public string Code;
        public string Description;
        public string ShortDescription;
        public string UpcCode;
        public string ModelNumber;
        public string CommodityCode;
        public int ItemLineId;
        public int ItemGroupId;
        public int ItemTypeId;
        public int UnitPurchaseQuantity;
        public int UnitOrderQuantity;
        public int PackOrderQuantity;
        public int SupplierId;
        public string SupplierCode;
        public string SupplierPartNumber;
        public string Created_at;
        public string Updated_at;

        public Item(int id, string code, string description, string shortDescription, string upcCode, string modelNumber, string commodityCode, int itemLineId, int itemGroupId, int itemTypeId, int unitPurchaseQuantity, int unitOrderQuantity, int packOrderQuantity, int supplierId, string supplierCode, string supplierPartNumber, string created_at, string updated_at){
            Id = id;
            Code = code;
            Description = description;
            ShortDescription = shortDescription;
            UpcCode = upcCode;
            ModelNumber = modelNumber;
            CommodityCode = commodityCode;
            ItemLineId = itemLineId;
            ItemGroupId = itemGroupId;
            ItemTypeId = itemTypeId;
            UnitPurchaseQuantity = unitPurchaseQuantity;
            UnitOrderQuantity = unitOrderQuantity;
            PackOrderQuantity = packOrderQuantity;
            SupplierId = supplierId;
            SupplierCode = supplierCode;
            SupplierPartNumber = supplierPartNumber;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}
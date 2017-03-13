//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradeBusiness
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductStock
    {
        public int ProductStockId { get; set; }
        public int ProductId { get; set; }
        public int MeasurementId { get; set; }
        public string Barcode { get; set; }
        public int PurchaseId { get; set; }
        public Nullable<decimal> PurchaseQuantity { get; set; }
        public Nullable<decimal> ProductVat { get; set; }
        public Nullable<decimal> CommisionRate { get; set; }
        public Nullable<decimal> DiscountRate { get; set; }
        public decimal ProductBuyRetailPrice { get; set; }
        public decimal ProductBuyWholeSalePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public decimal ProductWholeSalePrice { get; set; }
        public int PriceTypeId { get; set; }
        public Nullable<decimal> StockBalance { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<System.DateTime> ProductExpireDate { get; set; }
        public Nullable<int> WarrantyPeriod { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<byte> SortedBy { get; set; }
        public string Remarks { get; set; }
    
        public virtual Measurement Measurement { get; set; }
        public virtual PriceType PriceType { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductStock ProductStock1 { get; set; }
        public virtual ProductStock ProductStock2 { get; set; }
        public virtual ProductStock ProductStock11 { get; set; }
        public virtual ProductStock ProductStock3 { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual UserInfo UserInfo1 { get; set; }
    }
}

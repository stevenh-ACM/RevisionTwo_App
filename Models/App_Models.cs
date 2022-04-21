#nullable enable

using System.ComponentModel.DataAnnotations;

namespace RevisionTwo_App.Models;

/// <summary>
///  Models for RevisionTwo_App that use standard C# types. 
///  Generally used for input/output of Razor Pages.
/// </summary>
public class App
{ 
    /// <summary>
    /// Custom classes with std C# types that map to the Default classes
    /// <see cref="Conversion"/>
    /// </summary>
    public class Bill_App
    {
        #region Bills_App
        public int Id { get; set; }
        public string?   Type { get; set; }
        public string?   ReferenceNbr { get; set; }
        public string?   Status { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public string?   PostPeriod { get; set; }
        public string?   Vendor { get; set; }
        public string?   Description { get; set; }
        public string?   VendorRef { get; set; }
        public decimal?  Amount { get; set; }
        public string?   CurrencyID { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastModifiedDateTime { get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class BillDetail_App
    {
        #region BillDetail_App
        public int Id { get; set; }
        public string?   Branch { get; set; }
        public string?   InventoryID { get; set; }
        public string?   TransactionDescription { get; set; }
        public decimal?  Qty { get; set; }
        public decimal?  UnitCost { get; set; }
        public decimal?  Amount { get; set; }
        public string?   Account { get; set; }
        public string?   Description { get; set; }
        public string?   CostCode { get; set; }
        public string?   POOrderNbr { get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class Case_App
    {
        #region Case_App
        public int Id { get; set; }
        public string?   CaseID { get; set; }
        public string?   Subject { get; set; }
        public string?   BusinessAccount { get; set; }
        public string?   BusinessAccountName { get; set; }
        public string?   Status { get; set; }
        public string?   Reason { get; set; }
        public string?   Severity { get; set; }
        public string?   Priority { get; set; }
        public string?   Owner { get; set; }
        public string?   Workgroup { get; set; }
        public string?   ClassID { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastActivityDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastModifiedDateTime { get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class Contact_App
    {
        #region Contact_App
        public int Id { get; set; }
        public bool      Active { get; set; }
        public int?      ContactID { get; set; }
        public string?   DisplayName { get; set; }
        public string?   BusinessAccount { get; set; }
        public string?   JobTitle { get; set; }
        public string?   Owner { get; set; }
        public string?   CompanyName { get; set; }
        public string?   ContactClass { get; set; }
        public string?   Email { get; set; }
        public string?   Phone1 { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastModifiedDateTime { get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class Opportunity_App
    {
        #region Opportunity_App
        public int Id { get; set; }
        public string?   OpportunityID { get; set; }
        public string?   Subject { get; set; }
        public string?   Status { get; set; }
        public string?   Stage { get; set; }
        public string?   CurrencyID { get; set; }
        public decimal?  Total { get; set; }
        public string?   ClassID { get; set; }
        public string?   Owner { get; set; }
        public int?      ContactID { get; set; }
        public string?   ContactDisplayName { get; set; }
        public string?   BusinessAccount { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastModifiedDateTime{ get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class SalesOrder_App
    {
        #region SalesOrder_App
        public int Id { get; set; }
        public string?   OrderType { get; set; }
        public string?   OrderNbr { get; set; }
        public string?   Status { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime?Date { get; set; }
        public string?   CustomerID { get; set; }
        public string?   CustomerName { get; set; }
        public decimal?  OrderedQty { get; set; }
        public decimal?  OrderTotal { get; set; }
        public string?   CurrencyID { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ShipmentDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastModified { get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class Shipment_App
    {
        #region Shipments_App
        public int Id { get; set; }
        public string?   Type { get; set; }
        public string?   ShipmentNbr { get; set; }
        public string?   Status { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ShipmentDate { get; set; }
        public string?   CustomerID { get; set; }
        public string?   CustomerName { get; set; }
        public string?   WarehouseID { get; set; }
        public decimal?  ShippedQty { get; set; }
        public decimal?  ShippedWeight { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDateTime { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastModified { get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class ShipmentDetail_App
    {
        #region ShipmentDetail_App
        public int Id { get; set; }
        public string?   OrderType { get; set; }
        public string?   OrderNbr { get; set; }
        public string?   InventoryID { get; set; }
        public string?   WarehouseID { get; set; }
        public decimal?  ShippedQty { get; set; }
        public decimal?  OrderedQty { get; set; }
        public string?   Description { get; set; }
        #endregion
    }
    /// <summary>
    ///  mapping class for standard output form
    /// </summary>
    public class Address_App
    {
        #region Address_App
        public string?   AddressLine1 { get; set; }
        public string?   AddressLine2 { get; set; }
        public string?   City { get; set; }
        public string?   Country { get; set; }
        public string?   PostalCode { get; set; }
        public string?   State { get; set; }
        #endregion
    }
}
#nullable enable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevisionTwo_App.Models.App;

/// <summary>
///  Models for RevisionTwo_App that use standard C# types. 
///  Generally used for input/output of Razor Pages.
///
/// Custom classes with std C# types that map to the Default classes
/// <see cref="Conversion"/>
/// </summary>
public class Bill_App
{
    #region Bills_App

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(20)]
    public string?   Type { get; set; }

    [Display(Name = "Ref Nbr")]
    [StringLength(20)]
    public string?   ReferenceNbr { get; set; }

    [StringLength(20)]
    public string?   Status { get; set; }

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Date { get; set; }

    [Display(Name = "Post Period")]
    [StringLength(20)]
    public string?   PostPeriod { get; set; }

    [StringLength(20)]
    public string?   Vendor { get; set; }

    [StringLength(50)]
    public string?   Description { get; set; }

    [Display(Name = "Vendor Ref Nbr")]
    [StringLength(20)]
    public string?   VendorRef { get; set; }

    [DataType(DataType.Currency),DisplayFormat(DataFormatString = "{C2}")]
    public decimal?  Amount { get; set; }

    [Display(Name = "Currency Denom.")]
    [StringLength(20)]
    public string? CurrencyID { get; set; }

    [Display(Name = "Last Modified")]
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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

[StringLength(20)]
    public string?   Branch { get; set; }

    [Display(Name = "Inventory ID")]
    [StringLength(20)]
    public string?   InventoryID { get; set; }

    [Display(Name = "Trans Descrip")]
    [StringLength(50)]
    public string?   TransactionDescription { get; set; }

    [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{N}")]
    public decimal?  Qty { get; set; }

    [Display(Name = "Unit Cost")]
    [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{C2}")]
    public decimal?  UnitCost { get; set; }

    [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{C2}")]
    public decimal?  Amount { get; set; }

    [StringLength(20)]
    public string?   Account { get; set; }

    [StringLength(50)]
    public string?   Description { get; set; }

    [Display(Name = "Cost Code")]
    [StringLength(20)]
    public string?   CostCode { get; set; }

    [Display(Name = "PO OrderNbr")]
    [StringLength(20)]
    public string?   POOrderNbr { get; set; }

    #endregion
}
/// <summary>
///  mapping class for standard output form
/// </summary>
public class Case_App
{
    #region Case_App

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [StringLength(20)]
    public string?   CaseID { get; set; }
    
    [StringLength(30)]
    public string?   Subject { get; set; }

    [Display(Name = "Account ID")]
    [StringLength(20)]
    public string?   BusinessAccount { get; set; }

    [StringLength(30)]
    [Display(Name = "Account Name")]
    public string?   BusinessAccountName { get; set; }

    [StringLength(20)]
    public string?   Status { get; set; }

    [StringLength(20)]
    public string?   Reason { get; set; }

    [StringLength(20)]
    public string?   Severity { get; set; }

    [StringLength(20)]
    public string?   Priority { get; set; }

    [StringLength(30)]
    public string?   Owner { get; set; }

    [StringLength(20)]
    public string?   Workgroup { get; set; }

    [Display(Name = "Class")]
    [StringLength(20)]
    public string?   ClassID { get; set; }

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Date { get; set; }

    [Display(Name = "Last Activity")]
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? LastActivityDate { get; set; }

    [Display(Name = "Last Modified")]
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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool      Active { get; set; }

    [Display(Name = "Contact ID")]
    [StringLength(20)]
    public int?      ContactID { get; set; }
    [StringLength(30)]

    [Display(Name = "Contact Name")]
    public string?   DisplayName { get; set; }

    [StringLength(30)]
    [Display(Name = "Account ID")]
    public string?   BusinessAccount { get; set; }

    [Display(Name = "Job Title")]
    [StringLength(20)]
    public string?   JobTitle { get; set; }

    [StringLength(30)]
    public string?   Owner { get; set; }

    [Display(Name = "Company Name")]
    [StringLength(30)]
    public string?   CompanyName { get; set; }

    [Display(Name = "Class")]
    [StringLength(20)]
    public string?   ContactClass { get; set; }

    [DataType(DataType.EmailAddress)]
    public string?   Email { get; set; }

    [Display(Name = "Phone")]
    [DataType(DataType.PhoneNumber)]
    public string?   Phone1 { get; set; }

    [Display(Name = "Last Modified")]
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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Oppty ID")]
    [StringLength(20)]
    public string?   OpportunityID { get; set; }

    [StringLength(20)]
    public string?   Subject { get; set; }

    [StringLength(20)]
    public string?   Status { get; set; }

    [StringLength(20)]
    public string?   Stage { get; set; }

    [Display(Name = "Currency Denom.")]
    [StringLength(20)]
    public string?   CurrencyID { get; set; }

    [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{C2}")]
    public decimal?  Total { get; set; }

    [Display(Name = "Class")]
    [StringLength(20)]
    public string?   ClassID { get; set; }

    [StringLength(20)]
    public string?   Owner { get; set; }

    [Display(Name = "Contact ID")]
    [StringLength(20)]
    public int?      ContactID { get; set; }

    [Display(Name = "Contact Name")]
    [StringLength(30)]
    public string?   ContactDisplayName { get; set; }

    [Display(Name = "Account ID")]
    [StringLength(20)]
    public string?   BusinessAccount { get; set; }

    [Display(Name = "Last Modified")]
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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Order Type")]
    [StringLength(20)]
    public string?   OrderType { get; set; }

    [StringLength(20)]
    public string?   OrderNbr { get; set; }

    [StringLength(20)]
    public string?   Status { get; set; }

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime?Date { get; set; }

    [Display(Name = "Customer ID")]
    [StringLength(20)]
    public string?   CustomerID { get; set; }

    [StringLength(30)]
    [Display(Name = "Customer Name")]
    public string?   CustomerName { get; set; }

    [Display(Name = "Qty Ordered")]
    [DisplayFormat(DataFormatString = "{N}")]
    public decimal?  OrderedQty { get; set; }

    [Display(Name = "Order Total")]
    [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{C2}")]
    public decimal?  OrderTotal { get; set; }

    [Display(Name = "Currency Denom.")]
    [StringLength(20)]
    public string?   CurrencyID { get; set; }

    [Display(Name = "Ship Date")]

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ShipmentDate { get; set; }

    [Display(Name = "Last Modified")]

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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(20)]
    public string?   Type { get; set; }

    [Display(Name = "Shipment Nbr")]
    [StringLength(20)]
    public string?   ShipmentNbr { get; set; }

    [StringLength(20)]
    public string?   Status { get; set; }

    [Display(Name = "Ship Date")]
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ShipmentDate { get; set; }

    [Display(Name = "Customer ID")]
    [StringLength(20)]
    public string?   CustomerID { get; set; }

    [Display(Name = "Customer Name")]
    [StringLength(20)]
    public string?   CustomerName { get; set; }

    [Display(Name = "Warehouse ID")]
    [StringLength(20)]
    public string?   WarehouseID { get; set; }

    [Display(Name = "Qty Shipped")]
    [DisplayFormat(DataFormatString = "{N}")]
    public decimal?  ShippedQty { get; set; }

    [Display(Name = "Shipment Weight")]
    [DisplayFormat(DataFormatString = "{N}")]
    public decimal?  ShippedWeight { get; set; }

    [Display(Name = "Date Created")]
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? CreatedDateTime { get; set; }

    [Display(Name = "Last Modified")]
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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Order Type")]
    [StringLength(20)]
    public string?   OrderType { get; set; }

    [StringLength(20)]
    public string?   OrderNbr { get; set; }

    [Display(Name = "Inventory ID")]
    [StringLength(20)]
    public string?   InventoryID { get; set; }

    [Display(Name = "Warehouse ID")]
    [StringLength(20)]
    public string?   WarehouseID { get; set; }

    [Display(Name = "Qty Shipped")]
    [DisplayFormat(DataFormatString = "{N}")]
    public decimal?  ShippedQty { get; set; }

    [Display(Name = "Qty Ordered")]
    [DisplayFormat(DataFormatString = "{N}")]
    public decimal?  OrderedQty { get; set; }

    [StringLength(50)]
    public string?   Description { get; set; }

    #endregion
}
/// <summary>
///  mapping class for standard output form
/// </summary>
public class Address_App
{
    #region Address_App

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Street Addr")]
    [StringLength(50)]
    public string?   AddressLine1 { get; set; }

    [StringLength(50)]
    [Display(Name = "STE, Bldg")]
    public string?   AddressLine2 { get; set; }

    [StringLength(50)]
    public string?   City { get; set; }

    [StringLength(50)]
    public string?   Country { get; set; }

    [Display(Name = "Zip Code")]
    [DataType(DataType.PostalCode)]
    public string?   PostalCode { get; set; }

    [StringLength(50)]
    public string?   State { get; set; }

#endregion
}

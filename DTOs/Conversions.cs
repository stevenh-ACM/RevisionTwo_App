#nullable disable

using Acumatica.Default_20_200_001.Model;
using Acumatica.RESTClient.Model;

using RevisionTwo_App.Models;

namespace RevisionTwo_App.DTOs;

#region classes
/// <summary>
/// Conversion classes using inheritance of custom models
/// </summary>

#region Addr
public class ConvertToAddr : Addr
{
    public ConvertToAddr(Address ad)
    {
        AddressLine1 = ad.AddressLine1.Value;
        AddressLine2 = ad.AddressLine1.Value;
        City = ad.AddressLine1.Value;
        Country = ad.AddressLine1.Value;
        PostalCode = ad.AddressLine1.Value;
        State = ad.AddressLine1.Value;
    }
}
#endregion

#region Addr
public class ConvertToAddress : Address
{
    public ConvertToAddress(Addr ad)
    {
        AddressLine1 = ad.AddressLine1;
        AddressLine2 = ad.AddressLine1;
        City = ad.AddressLine1;
        Country = ad.AddressLine1;
        PostalCode = ad.AddressLine1;
        State = ad.AddressLine1;
    }
}
#endregion

#region ConvertToAR_Bill
/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToAR_Bill : AR_Bill
{
    public ConvertToAR_Bill(Bill bill)
    {
        Type = bill.Type.Value;
        ReferenceNbr = bill.ReferenceNbr.Value;
        Status = bill.Status.Value;
        Date = (DateTime)bill.Date.Value;
        PostPeriod = bill.PostPeriod.Value;
        Vendor = bill.Vendor.Value;
        Description = bill.Description.Value;
        VendorRef = bill.VendorRef.Value;
        Amount = (decimal)bill.Amount.Value;
        CurrencyID = bill.CurrencyID.Value;
        LastModifiedDateTime = (DateTime)bill.LastModifiedDateTime.Value;
    }
}
#endregion

#region ConvertToBill
/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToBill : Bill
{
    public ConvertToBill(AR_Bill bill)
    {
        Type = bill.Type;
        ReferenceNbr = bill.ReferenceNbr;
        Status = bill.Status;
        Date = bill.Date;
        PostPeriod = bill.PostPeriod;
        Vendor = bill.Vendor;
        Description = bill.Description;
        VendorRef = bill.VendorRef;
        Amount = bill.Amount;
        CurrencyID = bill.CurrencyID;
        LastModifiedDateTime = LastModifiedDateTime;
    }
}
#endregion

#region ConvertToAR_BillDetail
/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToAR_BillDetail : AR_BillDetail
{
    public ConvertToAR_BillDetail(BillDetail bill)
    {
        Branch = bill.Branch.Value;
        InventoryID = bill.InventoryID.Value;
        TransactionDescription = bill.TransactionDescription.Value;
        Qty = bill.Qty.Value;
        UnitCost = bill.UnitCost.Value;
        Amount = bill.Amount.Value;
        Account = bill.Account.Value;
        Description = bill.Description.Value;
        CostCode = bill.CostCode.Value;
        POOrderNbr = bill.POOrderNbr.Value;
    }
}
#endregion

#region ConverttoBillDetail
/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToBillDetail : BillDetail
{

    public ConvertToBillDetail(AR_BillDetail bill)
    {
        Branch = bill.Branch;
        InventoryID = bill.InventoryID;
        TransactionDescription = bill.TransactionDescription;
        Qty = bill.Qty;
        UnitCost = bill.UnitCost;
        Amount = bill.Amount;
        Account = bill.Account;
        Description = bill.Description;
        CostCode = bill.CostCode;
        POOrderNbr = bill.POOrderNbr;
    }
}
#endregion

#region ConverttoCRCase
/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToCRCase : CRCase
{
    public ConvertToCRCase(Case cr)
    {
        CaseID = cr.CaseID.Value;
        Subject = cr.Subject.Value;
        BusinessAccount = cr.BusinessAccount.Value;
        BusinessAccountName = cr.BusinessAccountName.Value;
        Status = cr.Status.Value;
        Reason = cr.Reason.Value;
        Severity = cr.Severity.Value;
        Priority = cr.Priority.Value;
        Owner = cr.Owner.Value;
        Workgroup = cr.Workgroup.Value;
        ClassID = cr.ClassID.Value;
        DateReported = (DateTime)cr.DateReported.Value;
        LastActivityDate = (DateTime)cr.LastActivityDate.Value;
        LastModifiedDateTime = (DateTime)cr.LastModifiedDateTime.Value;
    }
}
#endregion

#region ConverttoCase
/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToCase : Case
{
    public ConvertToCase(CRCase cr)
    {
        CaseID = cr.CaseID;
        Subject = cr.Subject;
        BusinessAccount = cr.BusinessAccount;
        BusinessAccountName = cr.BusinessAccountName;
        Status = cr.Status;
        Reason = cr.Reason;
        Severity = cr.Severity;
        Priority = cr.Priority;
        Owner = cr.Owner;
        Workgroup = cr.Workgroup;
        ClassID = cr.ClassID;
        DateReported = cr.DateReported;
        LastActivityDate = cr.LastActivityDate;
        LastModifiedDateTime = cr.LastModifiedDateTime;
    }
}
#endregion

#region ConvertToCO
/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToCO : CO
{
    public ConvertToCO(Contact co)
    {
        Active = (bool)co.Active.Value;
        ContactID = co.ContactID.Value;
        DisplayName = co.DisplayName.Value;
        BusinessAccount = co.BusinessAccount.Value;
        JobTitle = co.JobTitle.Value;
        Owner = co.Owner.Value;
        CompanyName = co.CompanyName.Value;
        ContactClass = co.ContactClass.Value;
        Email = co.Email.Value;
        Phone1 = co.Phone1.Value;
        LastModifiedDateTime = (DateTime)co.LastModifiedDateTime.Value;
    }
}
#endregion

#region ConverttoContact
/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToContact : Contact
{
    public ConvertToContact(CO co)
    {
        Active = (bool)co.Active;
        ContactID = co.ContactID.Value;
        DisplayName = co.DisplayName;
        BusinessAccount = co.BusinessAccount;
        JobTitle = co.JobTitle;
        Owner = co.Owner;
        CompanyName = co.CompanyName;
        ContactClass = co.ContactClass;
        Email = co.Email;
        Phone1 = co.Phone1;
        LastModifiedDateTime = co.LastModifiedDateTime.Value;
    }
}
#endregion

#region ConvertToOP
/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToOP : OP
{
    public ConvertToOP(Opportunity op)
    {
        OpportunityID = op.OpportunityID.Value;
        Subject = op.Subject.Value;
        Status = op.Status.Value;
        Stage = op.Stage.Value;
        CurrencyID = op.CurrencyID.Value;
        Total = (decimal)op.Total.Value;
        ClassID = op.ClassID.Value;
        Owner = op.Owner.Value;
        ContactDisplayName = op.ContactDisplayName.Value;
        BusinessAccount = op.BusinessAccount.Value;
        LastModifiedDateTime = (DateTime)op.LastModifiedDateTime.Value;
    }
}
#endregion

#region LastModifiedDateTime
/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToOpportunity : Opportunity
{
    public ConvertToOpportunity(OP op)
    {
        OpportunityID = op.OpportunityID;
        Subject = op.Subject;
        Status = op.Status;
        Stage = op.Stage;
        CurrencyID = op.CurrencyID;
        Total = op.Total;
        ClassID = op.ClassID;
        Owner = op.Owner;
        ContactDisplayName = op.ContactDisplayName;
        BusinessAccount = op.BusinessAccount;
        LastModifiedDateTime = op.LastModifiedDateTime;
    }
}
#endregion

#region ConvertToSO
/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToSO : SO
{
    public ConvertToSO(SalesOrder so, BusinessAccount ba, DateTimeValue sp)
    {
        OrderType = so.OrderType.Value;
        OrderNbr = so.OrderNbr.Value;
        Status = so.Status.Value;
        Date = (DateTime)so.Date.Value;
        CustomerID = so.CustomerID.Value;
        CustomerName = ba.Name.Value;
        OrderedQty = (decimal)so.OrderedQty.Value;
        OrderTotal = (decimal)so.OrderTotal.Value;
        CurrencyID = so.CurrencyID.Value;
        ShipmentDate = (DateTime)sp.Value;
        LastModified = (DateTime)so.LastModified.Value;
    }
}
#endregion

#region ConverttoSalesOrder
/// <summary>
/// Conversion to Default model from App model using inheritance and
/// </summary>
public class ConvertToSalesOrder : SalesOrder
{
    public ConvertToSalesOrder(SO so)
    {
        OrderType = so.OrderType;
        OrderNbr = so.OrderNbr;
        Status = so.Status;
        Date = so.Date;
        CustomerID = so.CustomerID;
        OrderedQty = so.OrderedQty;
        OrderTotal = so.OrderTotal;
        CurrencyID = so.CurrencyID;
        LastModified = so.LastModified;
    }
}
#endregion
#region ConvertToSP

/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToSP : SP
{
    public ConvertToSP(Shipment sp, BusinessAccount ba)
    {
        @Type = sp.Type.Value;
        ShipmentNbr = sp.ShipmentNbr.Value;
        Status = sp.Status.Value;
        ShipmentDate = (DateTime)sp.ShipmentDate.Value;
        CustomerID = sp.CustomerID.Value;
        CustomerName = ba.Name.Value;
        WarehouseID = sp.WarehouseID.Value;
        ShippedQty = (decimal)sp.ShippedQty.Value;
        ShippedWeight = (decimal)sp.ShippedWeight.Value;
        CreatedDateTime = (DateTime)sp.CreatedDateTime.Value;
        LastModifiedDateTime = (DateTime)sp.LastModifiedDateTime.Value;
    }
}
#endregion

#region ConvertToShipment
/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToShipment : Shipment
{
    public ConvertToShipment(SP sp)
    {
        @Type = sp.Type;
        ShipmentNbr = sp.ShipmentNbr;
        Status = sp.Status;
        ShipmentDate = sp.ShipmentDate;
        CustomerID = sp.CustomerID;
        WarehouseID = sp.WarehouseID;
        ShippedQty = sp.ShippedQty;
        ShippedWeight = sp.ShippedWeight;
        CreatedDateTime = sp.CreatedDateTime;
        LastModifiedDateTime = sp.LastModifiedDateTime;
    }
}
#endregion

#region ConvertToSPDetail
/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToSPDetail : SPDetail
{
    public ConvertToSPDetail(ShipmentDetail sp)
    {
        OrderType = sp.OrderType.Value;
        OrderNbr = sp.OrderNbr.Value;
        InventoryID = sp.InventoryID.Value;
        WarehouseID = sp.WarehouseID.Value;
        ShippedQty = sp.ShippedQty.Value;
        OrderedQty = sp.OrderedQty.Value;
        Description = sp.Description.Value;
    }
}
#endregion

#region ConvertToShipmentDetail
/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToShipmentDetail : ShipmentDetail
{
    public ConvertToShipmentDetail(SPDetail sp)
    {
        OrderType = sp.OrderType;
        OrderNbr = sp.OrderNbr;
        InventoryID = sp.InventoryID;
        WarehouseID = sp.WarehouseID;
        ShippedQty = sp.ShippedQty;
        OrderedQty = sp.OrderedQty;
        Description = sp.Description;
    }
}
#endregion
#endregion
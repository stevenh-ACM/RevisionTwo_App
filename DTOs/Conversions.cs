#nullable disable

using Acumatica.Default_20_200_001.Model;
using Acumatica.RESTClient.Model;

using RevisionTwo_App.Models;

using System;

namespace RevisionTwo_App.DTOs;

/// <summary>
/// Conversion classes using inheritance of custom models
/// </summary>

#region classes

#region ConvertToAR_Bill

/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToAR_Bill : AR_Bill
{
    public ConvertToAR_Bill(Bill bill)
    {

    }
}
#endregion

#region ConvertToBill

/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToBill : Bill
{
    public ConvertToBill(AR_Bill ar_bill)
    {

    }
}
#endregion

#region ConvertToAR_BillDetail

/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToAR_BillDetail : AR_BillDetail
{
    public ConvertToAR_BillDetail(BillDetail billdetail)
    {

    }
}
#endregion

#region ConverttoBillDetail

/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToBillDetail : BillDetail
{

    public ConvertToBillDetail(AR_BillDetail arbill)
    {

    }
}
#endregion

#region ConverttoCRCase

/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToCRCase : CRCase
{
    public ConvertToCRCase(Case _case)
    {
        CaseID = _case.CaseID.Value;
        Subject = _case.Subject.Value;
        BusinessAccount = _case.BusinessAccount.Value;
        BusinessAccountName = _case.BusinessAccountName.Value;
        Status = _case.Status.Value;
        Reason = _case.Reason.Value;
        Severity = _case.Severity.Value;
        Priority = _case.Priority.Value;
        Owner = _case.Owner.Value;
        Workgroup = _case.Workgroup.Value;
        ClassID = _case.ClassID.Value;
        DateReported = _case.DateReported.Value;
        LastActivityDate = _case.LastActivityDate.Value;
        LastModifiedDateTime = _case.LastModifiedDateTime.Value;
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
        Active = (bool)co.Active;
        ContactID = co.ContactID.Value;
        DisplayName = co.DisplayName.Value;
        BusinessAccount = co.BusinessAccount.Value;
        JobTitle = co.JobTitle.Value;
        Owner = co.Owner.Value;
        CompanyName = co.CompanyName.Value;
        ContactClass = co.ContactClass.Value;
        Email = co.Email.Value;
        Phone1 = co.Phone1.Value;
        LastModifiedDateTime = co.LastModifiedDateTime.Value;
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
    public ConvertToOP(Opportunity opportunity)
    {

    }
}
#endregion

#region ConverttoOpportunity

/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToOpportunity : Opportunity
{
    public ConvertToOpportunity(OP op)
    {

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
    public ConvertToSP(Shipment shipment)
    {

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

    }
}
#endregion

#region ConvertToSPDetail

/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToSPDetail : SPDetail
{
    public ConvertToSPDetail(ShipmentDetail ShipmentDetail)
    {

    }
}
#endregion

#region ConvertToShipmentDetail

/// <summary>
/// Conversion to Default model from App model using inheritance
/// </summary>
public class ConvertToShipmentDetail : ShipmentDetail
{
    public ConvertToShipmentDetail(SPDetail spd)
    {

    }
    #endregion
}

#endregion

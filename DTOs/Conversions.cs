#nullable disable

using Acumatica.Default_20_200_001.Model;
using Acumatica.RESTClient.Model;

using RevisionTwo_App.Models;

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

    }
}
    #endregion
    
    #region ConvertToCO

/// <summary>
/// Conversion to App model from Default model using inheritance 
/// </summary>
public class ConvertToCO : CO
{
    public ConvertToCO(Contact contact)
    {

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

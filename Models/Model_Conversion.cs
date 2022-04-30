﻿#nullable disable

using Acumatica.Default_20_200_001.Model;
using Acumatica.RESTClient.Model;

using RevisionTwo_App.Models.App;
using RevisionTwo_App.Models.Default;

namespace RevisionTwo_App.Models.Conversion;


/// <summary>
/// Conversion classes using inheritance of custom models
/// </summary>

    #region classes

    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToBill_App : Bill_App
    {
        #region toBill_App
        public ToBill_App(Bill_Model Bill_Model)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance
    /// </summary>
    public class ToBill_Model : Bill_Model
    {
        #region toBill_Model
        public ToBill_Model(SalesOrder_App Bill_App)
        {

        }
        #endregion
    }

    /// <summary>
    /// Create custom Default model from API Response, add new properties
    /// potentially from other Default Models by constructor
    /// </summary>
    public class Create_Bill_Model : Bill
    {
        #region Create_Bill_Model
        //ctor
        public Create_Bill_Model()
        { }
        public Create_Bill_Model(Bill sp_value)
        { }
        #endregion
    }

    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToBillDetail_App : BillDetail_App
    {
        #region toBillDetail_App
        public ToBillDetail_App(BillDetail_Model BillDetail_Model)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance
    /// </summary>
    public class ToBillDetail_Model : BillDetail_Model
    {
        #region toBillDetail_Model
        public ToBillDetail_Model(SalesOrder_App BillDetail_App)
        {

        }
        #endregion
    }

    /// <summary>
    /// Create custom Default model from API Response, add new properties
    /// potentially from other Default Models by constructor
    /// </summary>
    public class Create_BillDetail_Model : BillDetail
    {
        #region Create_BillDetail_Model
        //ctor
        public Create_BillDetail_Model()
        { }
        public Create_BillDetail_Model(BillDetail sp_value)
        { }
        #endregion
    }
    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToCase_App : Case_App
    {
        #region toCase_App
        public ToCase_App(Case_Model Case_Model)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance
    /// </summary>
    public class ToCase_Model : Case_Model
    {
        #region toCase_Model
        public ToCase_Model(SalesOrder_App Case_App)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToContact_App : Contact_App
    {
        #region toContact_App
        public ToContact_App(Contact_Model Contact_Model)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance
    /// </summary>
    public class ToContact_Model : Contact_Model
    {
        #region toContact_Model
        public ToContact_Model(SalesOrder_App Contact_App)
        {

        }
        #endregion
    }

    /// <summary>
    /// Create custom Default model from API Response, add new properties
    /// potentially from other Default Models by constructor
    /// </summary>
    public class Create_Contact_Model : Contact
    {
        #region Create_Contact_Model
        //ctor
        public Create_Contact_Model()
        { }
        public Create_Contact_Model(Contact sp_value)
        { }
        #endregion
    }

    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToOpportunity_App : Opportunity_App
    {
        #region toOpportunity_App
        public ToOpportunity_App(Opportunity_Model Opportunity_Model)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance
    /// </summary>
    public class ToOpportunity_Model : Opportunity_Model
    {
        #region toOpportunity_Model
        public ToOpportunity_Model(SalesOrder_App Opportunity_App)
        {

        }
        #endregion
    }

    /// <summary>
    /// Create custom Default model from API Response, add new properties
    /// potentially from other Default Models by constructor
    /// </summary>
    public class Create_Opportunity_Model : Opportunity
    {
        #region Create_Opportunity_Model
        //ctor
        public Create_Opportunity_Model()
        { }
        public Create_Opportunity_Model(Opportunity sp_value)
        { }
        #endregion
    }

    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToSalesOrder_App : SalesOrder_App
    {    
        #region toSalesOrder_App
        public ToSalesOrder_App(SalesOrder_Model salesOrder_Model)
        {
            OrderType     = salesOrder_Model.OrderType.Value;
            OrderNbr      = salesOrder_Model.OrderNbr.Value;
            Status        = salesOrder_Model.Status.Value;
            Date          = (DateTime)salesOrder_Model.Date.Value;
            CustomerID    = salesOrder_Model.CustomerID.Value;
            CustomerName  = salesOrder_Model.CustomerName.Value;
            OrderedQty    = (decimal)salesOrder_Model.OrderedQty.Value;
            OrderTotal    = (decimal)salesOrder_Model.OrderTotal.Value;
            CurrencyID    = salesOrder_Model.CurrencyID.Value;
            ShipmentDate  = (DateTime)salesOrder_Model.ShipmentDate.Value;
            LastModified  = (DateTime)salesOrder_Model.LastModified.Value;
        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance and
    /// </summary>
    public class ToSalesOrder_Model : SalesOrder_Model
    {
        #region toSalesOrder_Model
        public ToSalesOrder_Model(SalesOrder_App salesOrder_App)
        {
            OrderType    = salesOrder_App.OrderType;
            OrderNbr     = salesOrder_App.OrderNbr;
            Status       = salesOrder_App.Status;
            Date         = salesOrder_App.Date;
            CustomerID   = salesOrder_App.CustomerID;
            OrderedQty   = salesOrder_App.OrderedQty;
            OrderTotal   = salesOrder_App.OrderTotal;
            CurrencyID   = salesOrder_App.CurrencyID;
            LastModified = salesOrder_App.LastModified;
            ShipmentDate = salesOrder_App.ShipmentDate;
            CustomerName = salesOrder_App.CustomerName;
        }
        #endregion
    }

    /// <summary>
    /// Create custom Default model from API Response, add new properties
    /// potentially from other Default Models by constructor
    /// </summary>
    public class Create_SalesOrder_Model : SalesOrder_Model
    {
        #region Create_SalesOrder_Model
        //ctor
        public Create_SalesOrder_Model()
        { }
        public Create_SalesOrder_Model(SalesOrder so_value, DateTimeValue sp_value, StringValue ba_value)
        {
            OrderType     = so_value.OrderType;
            OrderNbr      = so_value.OrderNbr;
            Status        = so_value.Status;
            Date          = so_value.Date;
            CustomerID    = so_value.CustomerID;
            CustomerName  = ba_value;
            OrderedQty    = so_value.OrderedQty;
            OrderTotal    = so_value.OrderTotal;
            CurrencyID    = so_value.CurrencyID;
            ShipmentDate  = sp_value;
            LastModified  = so_value.LastModified;
        }
        #endregion
    }

    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToShipment_App : Shipment_App
    {
        #region toShipment_App
        public ToShipment_App(Shipment_Model shipment_Model)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance
    /// </summary>
    public class ToShipment_Model : Shipment_Model
    {
        #region toShipment_Model
        public ToShipment_Model(SalesOrder_App shipment_App)
        {

        }
        #endregion
    }

    /// <summary>
    /// Create custom Default model from API Response, add new properties
    /// potentially from other Default Models by constructor
    /// </summary>
    public class Create_Shipment_Model : Shipment
    {
        #region Create_Shipment_Model
        //ctor
        public Create_Shipment_Model()
        { }
        public Create_Shipment_Model(Shipment sp_value)
        { }
        #endregion
    }

    /// <summary>
    /// Conversion to App model from Default model using inheritance 
    /// </summary>
    public class ToShipmentDetail_App : ShipmentDetail_App
    {
        #region toShipmentDetail_App
        public ToShipmentDetail_App(ShipmentDetail_Model ShipmentDetail_Model)
        {

        }
        #endregion
    }

    /// <summary>
    /// Conversion to Default model from App model using inheritance
    /// </summary>
    public class ToShipmentDetail_Model : ShipmentDetail_Model
    {
        #region toShipmentDetail_Model
        public ToShipmentDetail_Model(SalesOrder_App ShipmentDetail_App)
        {

        }
        #endregion
    }

    /// <summary>
    /// Create custom Default model from API Response, add new properties
    /// potentially from other Default Models by constructor
    /// </summary>
    public class Create_ShipmentDetail_Model : ShipmentDetail
    {
        #region Create_ShipmentDetail_Model
        //ctor
        public Create_ShipmentDetail_Model()
        { }
        public Create_ShipmentDetail_Model(ShipmentDetail sp_value)
        { }
        #endregion
    }

    #endregion

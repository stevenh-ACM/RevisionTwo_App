using Acumatica.RESTClient.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Acumatica.Default_20_200_001.Model
{
	[DataContract]
	public class Bill : Entity_v4
	{

		[DataMember(Name="Amount", EmitDefaultValue=false)]
		public decimal Amount { get; set; }

		[DataMember(Name="Applications", EmitDefaultValue=false)]
		public List<BillApplicationDetail> Applications { get; set; }

		[DataMember(Name="ApprovedForPayment", EmitDefaultValue=false)]
		public bool ApprovedForPayment { get; set; }

		[DataMember(Name="Balance", EmitDefaultValue=false)]
		public decimal Balance { get; set; }

		[DataMember(Name="BranchID", EmitDefaultValue=false)]
		public string BranchID { get; set; }

		[DataMember(Name="CashAccount", EmitDefaultValue=false)]
		public string CashAccount { get; set; }

		[DataMember(Name="CurrencyID", EmitDefaultValue=false)]
		public string CurrencyID { get; set; }

		[DataMember(Name="Date", EmitDefaultValue=false)]
		public DateTime Date { get; set; }

		[DataMember(Name="Description", EmitDefaultValue=false)]
		public string Description { get; set; }

		[DataMember(Name="Details", EmitDefaultValue=false)]
		public List<BillDetail> Details { get; set; }

		[DataMember(Name="DueDate", EmitDefaultValue=false)]
		public DateTime DueDate { get; set; }

		[DataMember(Name="Hold", EmitDefaultValue=false)]
		public bool Hold { get; set; }

		[DataMember(Name="LocationID", EmitDefaultValue=false)]
		public string LocationID { get; set; }

		[DataMember(Name="PostPeriod", EmitDefaultValue=false)]
		public string PostPeriod { get; set; }

		[DataMember(Name="Project", EmitDefaultValue=false)]
		public string Project { get; set; }

		[DataMember(Name="ReferenceNbr", EmitDefaultValue=false)]
		public string ReferenceNbr { get; set; }

		[DataMember(Name="Status", EmitDefaultValue=false)]
		public string Status { get; set; }

		[DataMember(Name="TaxDetails", EmitDefaultValue=false)]
		public List<BillTaxDetail> TaxDetails { get; set; }

		[DataMember(Name="TaxTotal", EmitDefaultValue=false)]
		public decimal TaxTotal { get; set; }

		[DataMember(Name="Terms", EmitDefaultValue=false)]
		public string Terms { get; set; }

		[DataMember(Name="Type", EmitDefaultValue=false)]
		public string Type { get; set; }

		[DataMember(Name="Vendor", EmitDefaultValue=false)]
		public string Vendor { get; set; }

		[DataMember(Name="VendorRef", EmitDefaultValue=false)]
		public string VendorRef { get; set; }

		[DataMember(Name="LastModifiedDateTime", EmitDefaultValue=false)]
		public DateTime LastModifiedDateTime { get; set; }

	}
}
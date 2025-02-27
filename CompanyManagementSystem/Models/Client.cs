namespace CompanyManagementSystem.Models
{
  public class Client
  {
    // Client details
    public int Id { get; set; }
    public string Name { get; set; }
    public string PANNo { get; set; }
    public string Code { get; set; }
    public string Station { get; set; }
    public string CreditPeriod { get; set; }
    public string GSTNo { get; set; }
    public string CINNo { get; set; }
    public string IECNo { get; set; }
    public DateTime? GSTDate { get; set; }
    public string SACCode { get; set; }
    public int? LedgerId { get; set; }
    public Company? Ledger { get; set; }
    // Other details
    public string VATNo { get; set; }
    public string TINno { get; set; }
    public string STNo { get; set; }
    public string Remarks { get; set; }
    // Contact details making payment
    public string ContactName { get; set; }
    public string ContactMobile { get; set; }
    public string ContactEmail { get; set; }
    public string ContactAddress { get; set; }
    public string ContactState { get; set; }
    public string ContactCountry { get; set; }
    public string ContactPincode { get; set; }
    public bool IsInvoiceFormat { get; set; }
    public bool IsKYC { get; set; }
    public string StateCode { get; set; }
  }
}
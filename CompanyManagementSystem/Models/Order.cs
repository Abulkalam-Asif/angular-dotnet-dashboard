namespace CompanyManagementSystem.Models
{
  public class Order
  {
    // WO details
    public int Id { get; set; }
    public string ClientOrderNo { get; set; }
    public int? ClientId { get; set; }
    public Client? ClientName { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Remarks { get; set; }
    public string Status { get; set; }
    // Invoicing terms
    public string InvoicingTerms { get; set; }
    // Contact details
    public string ContactName { get; set; }
    public string ContactNo { get; set; }
    public string ContactEmail { get; set; }
    public string ContactFaxNo { get; set; }
    // Others
    public string OtherRemarks { get; set; }
  }
}
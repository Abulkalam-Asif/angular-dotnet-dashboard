using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyManagementSystem.Models;

public class Company
{
    // Company details
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? RegDate { get; set; }
    public string RegNo { get; set; }
    public string PANNo { get; set; }
    public string TANNo { get; set; }
    public string TINNo { get; set; }
    public string CINNo { get; set; }
    public string ServiceTaxNo { get; set; }
    public string ISORemark { get; set; }
    public string GSTNo { get; set; }
    public DateTime? GSTDate { get; set; }
    public DateTime? LicenseStartDate { get; set; }
    public DateTime? LicenseEndDate { get; set; }
    // Address
    public string Address { get; set; }
    public string AddressHtml { get; set; }
    public string BranchAddress { get; set; }
    // Attachments
    public string LogoUrl { get; set; }

}
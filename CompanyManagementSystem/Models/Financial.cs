namespace CompanyManagementSystem.Models
{
    public class Financial
    {
        public int FinancialId { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal Profit { get; set; }
        public int CompanyId { get; set; }
        public required Company Company { get; set; } // Enforce initialization
    }
}
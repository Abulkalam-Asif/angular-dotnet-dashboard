namespace CompanyManagementSystem.Models
{
    public class RegisterModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? CompanyId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
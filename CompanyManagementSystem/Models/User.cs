using Microsoft.AspNetCore.Identity;

namespace CompanyManagementSystem.Models
{
    public class User : IdentityUser
    {
        public int? CompanyId { get; set; } // Nullable for SuperAdmin
        public  Company ? Company { get; set; } // Enforce initialization
    }
}
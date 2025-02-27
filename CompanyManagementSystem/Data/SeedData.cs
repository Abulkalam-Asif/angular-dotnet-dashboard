using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CompanyManagementSystem.Models;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        // Seed roles
        string[] roles = { "SuperAdmin", "CompanyEmployee" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Seed a SuperAdmin user
        var superAdmin = new User
        {
            UserName = "superadmin@example.com",
            Email = "superadmin@example.com"
        };

        if (await userManager.FindByEmailAsync(superAdmin.Email) == null)
        {
            await userManager.CreateAsync(superAdmin, "SuperAdmin123!");
            await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
        }
    }
}


// eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3VwZXJhZG1pbkBleGFtcGxlLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYzVkNGE2Y2MtMTMzNC00ZGM1LWFhMjEtNDc2NTcxZWI3MDkzIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiU3VwZXJBZG1pbiIsImV4cCI6MTc0MDY3Mjg3MywiaXNzIjoiQ29tcGFueU1hbmFnZW1lbnRTeXN0ZW0iLCJhdWQiOiJDb21wYW55TWFuYWdlbWVudEFwcCJ9.LWKSd6RuYINSlOs8LUi2y8AWYW1cwd1UmKn-3cYa3Yw
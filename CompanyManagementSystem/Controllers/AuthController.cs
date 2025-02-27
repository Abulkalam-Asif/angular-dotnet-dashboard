using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CompanyManagementSystem.Data;
using CompanyManagementSystem.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;  // Injecting DbContext for company validation

    public AuthController(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        AppDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _context = context;
    }

    // POST: api/Auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        // Ensure the company exists before proceeding with registration
        var company = await _context.Companies.FindAsync(model.CompanyId);
        if (company == null)
        {
            return BadRequest("Company not found.");
        }

        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            CompanyId = model.CompanyId
        };

        // Create the user with the password
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            // Assign role to the user. If not provided, default to "RegularUser"
            var role = string.IsNullOrEmpty(model.Role) ? "RegularUser" : model.Role;

            // Check if the role exists, and if not, create it
            var roleExist = await _roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                return BadRequest("Role does not exist.");
            }

            await _userManager.AddToRoleAsync(user, role);
            return Ok(new { message = "User registered successfully." });
        }

        return BadRequest(result.Errors);
    }

    // POST: api/Auth/login
    [HttpPost("login")]
    public async Task<Object> Login(LoginModel model)
    {
        // Validate the input model
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        {
            return BadRequest("Email and password are required.");
        }

        // Find the user by email
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            Console.WriteLine(user);
            return Unauthorized("Invalid email or password.");
        }

        // Check the password
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!isPasswordValid)
        {
            Console.WriteLine(isPasswordValid);
            return Unauthorized("Invalid email or password.");
        }

        // Get the user's roles
        var roles = await _userManager.GetRolesAsync(user);
        Console.WriteLine(roles);
        if (roles == null || !roles.Any())
        {
            return Unauthorized("User has no roles assigned.");
        }

        // Generate the JWT token
        var token = GenerateJwtToken(user, roles);
        string userRole = roles.FirstOrDefault() ?? "User";
        // Return the token
        return Ok(new { Token = token, Role = userRole });
    }

    // Generate JWT Token
    private string GenerateJwtToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email ?? string.Empty),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

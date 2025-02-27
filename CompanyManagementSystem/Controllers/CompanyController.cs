using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyManagementSystem.Models;
using CompanyManagementSystem.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;

namespace CompanyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize(Roles = "SuperAdmin")] // Restrict access to SuperAdmin role for creating companies
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Company
        [HttpPost]
        // [Authorize(Roles = "SuperAdmin")] // Restrict access to SuperAdmin role
        public async Task<IActionResult> AddCompany([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest("Company data is required.");
            }

            // Ensure companyId is not set (it will be auto-generated by the database)
            company.Id = 0;

            // Add company to the DbContext
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
        }

        // GET: api/Company
        [HttpGet]
        [AllowAnonymous] // Allow anonymous users to view all companies
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            var companyDtos = companies.Select(c => new
            {
                c.Id,
                c.Name,
                c.RegNo
            }).ToList();
            return Ok(companyDtos);
        }

        // GET: api/Company/{id}
        [HttpGet("{id}")]
        [AllowAnonymous] // Allow anonymous users to view a specific company
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound("Company not found.");
            }

            return Ok(company);
        }

        // DELETE: api/Company/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            Console.WriteLine("Company: " + company);

            if (company == null)
            {
                return NotFound("Company not found.");
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return Ok("Company deleted successfully.");
        }
    }
}

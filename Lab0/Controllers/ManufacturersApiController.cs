using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab0.Controllers;

[Route("api/manufacturers")]
[ApiController]
public class ManufacturersApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public ManufacturersApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string filter)
    {
        var query = _context.Manufacturers.AsQueryable();
        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(m => m.Name.ToLower().Contains(filter.ToLower()));
        }

        return Ok(query.Select(m => new { m.Id, m.Name }).ToList());
    }
}

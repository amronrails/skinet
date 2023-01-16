
namespace API.Controllers;

using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
  private readonly StoreContext _context;
  public ProductsController(StoreContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<List<ProductsController>>> GetProducts()
  {
    var products = await _context.Products.ToListAsync();
    return Ok(products);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<string>> GetAsync(int id)
  {
    var product = await _context.Products.FindAsync(id);
    return Ok(product);
  }
}

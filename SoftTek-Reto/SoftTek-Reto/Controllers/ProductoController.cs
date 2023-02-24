using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using SoftTek_Reto.Models;

namespace SoftTek_Reto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly APPContext _context;
        public ProductoController(APPContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ProductoList() {
            return Ok(_context.Productos.ToList());
        
        }
        [HttpPost]
        public IActionResult Create([FromBody] Producto producto) {
            producto.IdProducto = _context.Productos.Max(p => p.IdProducto) + 1 ;
            _context.Productos.Add(producto);
            return Ok(producto);
        
        }
        [HttpDelete]
        public IActionResult delete(int id) {
            var itemToRemove = _context.Productos.SingleOrDefault(x => x.IdProducto == id); 

            if (itemToRemove != null)
            {
                _context.Productos.Remove(itemToRemove);
                _context.SaveChanges();
            }
            return Ok();
        
        }
    }
}

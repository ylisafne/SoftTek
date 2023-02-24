using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftTek_Reto.Models;
using System.Security.Claims;

namespace SoftTek_Reto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class VentasController : Controller
    {
        private readonly APPContext _context;

        public VentasController(APPContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult get() {
            var identy = HttpContext.User.Identity as ClaimsIdentity;
            if (identy == null || identy.Claims.Count() == 0)
            {
                return Ok( new
                {
                    succes = false,
                    error = "Verficiar Token valido",
                    result = ""
                });
            }
            var IdAsesor = Convert.ToInt32(identy.Claims.FirstOrDefault(x => x.Type == "IdAsesor").Value);
            var rol = identy.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            dynamic result;
            if (rol == "Administrador")
            {
                result = _context.Ventas.Include(x => x.AsesorNav).Select(x => new
                {
                    idVenta = x.IdVenta,
                    fecha = x.Fecha,
                    x.estado,
                    x.IdAsesor,
                    x.IdProducto,
                    x.Margen,
                    x.PrecioVenta,
                    asesor = x.AsesorNav.Nombre + " " + x.AsesorNav.Apellido,
                    producto = x.ProductoNav.Name
                }
            ).ToList();
            }
            else {
                result = _context.Ventas.Include(x => x.AsesorNav).Select(x => new
                {
                    idVenta = x.IdVenta,
                    fecha = x.Fecha,
                    x.estado,
                    x.IdAsesor,
                    x.IdProducto,
                    x.Margen,
                    x.PrecioVenta,
                    asesor = x.AsesorNav.Nombre + " " + x.AsesorNav.Apellido,
                    producto = x.ProductoNav.Name
                }
            ).Where(x=> x.IdAsesor == IdAsesor).ToList();

            }
            return Ok(result);
             
        }
        [HttpPost]
        public IActionResult create([FromBody] Venta venta ) {
            var prod = _context.Productos.FirstOrDefault(x => x.IdProducto == venta.IdProducto);
            venta.IdVenta = _context.Ventas.Max(p => p.IdVenta) + 1;
            venta.estado = (prod.MargenMinimo >= venta.Margen ? "Aprobado" : "Pendiente");
            _context.Ventas.Add(venta);
            return Ok(venta);
        }

        [HttpPost("~/Estado")]
        public IActionResult ActualizaEstado(int IdVenta, string estado)
        {
            var venta = _context.Ventas.Include(x => x.ProductoNav).FirstOrDefault(x => x.IdVenta == IdVenta);
            if (venta != null)
            {
                venta.estado = estado;
                _context.SaveChanges();
            }
            return Ok(venta);
        }
    }
}

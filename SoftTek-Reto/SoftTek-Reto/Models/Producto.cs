using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftTek_Reto.Models
{
    public class Producto
    {
        [Key]
        public int? IdProducto { get; set; }
        public string Name { get; set; }
        public double PrecioSugerido { get; set; }
        public double PrecioCompra { get; set; }
        public double MargenMinimo { get; set; }
        [InverseProperty("ProductoNav")]
        public List<Venta> Ventas { get; set; }

    }
}

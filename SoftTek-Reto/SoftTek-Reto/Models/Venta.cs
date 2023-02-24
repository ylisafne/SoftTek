using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftTek_Reto.Models
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }

        public int IdAsesor { get; set; }
        public int IdProducto { get; set; }
        public double Margen { get; set; }
        public double PrecioVenta { get; set; }
        public string estado { get; set; }
        [ForeignKey("IdAsesor")]
        [InverseProperty("Ventas")]
        public virtual Asesor AsesorNav { get; set; } 
        [ForeignKey("IdProducto")]
        [InverseProperty("Ventas")]
        public virtual Producto ProductoNav { get; set; } = null!;
    }
}

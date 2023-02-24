using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftTek_Reto.Models
{
    public class Asesor
    {
        [Key]
        public int IdAsesor { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [InverseProperty("AsesorNav")]
        public virtual ICollection<Venta> Ventas { get; } = new List<Venta>(); 
    }
}

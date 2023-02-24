using Microsoft.EntityFrameworkCore;

namespace SoftTek_Reto.Models
{
    public class DataGenerator
    {
        //private readonly APPContext _context;
        public DateTime dtnext() { 
            Random gen = new Random();
            //DateTime start = new DateTime(2022, 1, 1);
            var start = DateTime.Now.AddMonths(-4);

            int range = (DateTime.Today.AddDays(7) - start).Days;
            return start.AddDays(gen.Next(range));
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var date = new DataGenerator();
            using (var context = new APPContext(
                serviceProvider.GetRequiredService<DbContextOptions<APPContext>>()))
            {
                //Populate Productos
                if (!context.Productos.Any()) {
                    context.Productos.AddRange(
                        new Producto {
                            IdProducto = 1,
                            Name = "Toyota Avanza",
                            PrecioCompra = 19020 * (1- 0.45),
                            PrecioSugerido = 19020,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 2,
                            Name = "Toyota 4Runner",
                            PrecioCompra = 245560 * (1 - 0.45),
                            PrecioSugerido = 245560,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 3,
                            Name = "Toyota Agya",
                            PrecioCompra = 45060 * (1 - 0.45),
                            PrecioSugerido = 45060,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 4,
                            Name = "Toyota Corolla",
                            PrecioCompra = 92640 * (1 - 0.45),
                            PrecioSugerido = 92640,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 5,
                            Name = "Toyota Corolla Cross",
                            PrecioCompra = 102680 * (1 - 0.45),
                            PrecioSugerido = 102680,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 6,
                            Name = "Toyota Etios",
                            PrecioCompra = 59840 * (1 - 0.45),
                            PrecioSugerido = 59840,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 7,
                            Name = "Toyota Fortuner",
                            PrecioCompra = 183560 * (1 - 0.45),
                            PrecioSugerido = 183560,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 8,
                            Name = "Toyota Hiace",
                            PrecioCompra = 140080 * (1 - 0.45),
                            PrecioSugerido = 140080,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 9,
                            Name = "Toyota Hilux",
                            PrecioCompra = 115520 * (1 - 0.45),
                            PrecioSugerido = 115520,
                            MargenMinimo = 30
                        },
                        new Producto
                        {
                            IdProducto = 10,
                            Name = "Toyota Land Crucier Prado",
                            PrecioCompra = 224800 * (1 - 0.45),
                            PrecioSugerido = 224800,
                            MargenMinimo = 30
                        });
                    context.SaveChanges();
                }
                if (!context.Asesors.Any()) {
                    context.AddRange(
                        new Asesor { 
                            IdAsesor = 1,
                            UserName = "agonzales",
                            Password = "agonzales",
                            Rol = "Vendedor",
                            Nombre = "Angie",
                            Apellido = "Gonzales"
                        },
                        new Asesor
                        {
                            IdAsesor = 2,
                            UserName = "eperez",
                            Password = "eperez",
                            Rol = "Vendedor",
                            Nombre = "Erickson",
                            Apellido = "Perez"
                        },
                        new Asesor
                        {
                            IdAsesor = 3,
                            UserName = "gsilverio",
                            Password = "gsilverio",
                            Rol = "Administrador",
                            Nombre = "Gabriel",
                            Apellido = "Silverio"
                        },
                        new Asesor
                        {
                            IdAsesor = 4,
                            UserName = "aquezada",
                            Password = "aquezada",
                            Rol = "Vendedor",
                            Nombre = "Alex",
                            Apellido = "Quezada"
                        },
                        new Asesor
                        {
                            IdAsesor = 5,
                            UserName = "mespinoza",
                            Password = "mespinoza",
                            Rol = "Vendedor",
                            Nombre = "Melisa",
                            Apellido = "Espinoza"
                        });
                    context.SaveChanges();
                }
                if (!context.Ventas.Any()) {
                    int maxProd = context.Productos.Count();
                    int maxAses = context.Asesors.Count();
                    
                    //Random rnd = new Random();
                    for (int i = 0; i < 100; i++) {
                        Random rnd = new Random();
                        var idPrd = rnd.Next(1, maxProd);
                        var prd = context.Productos.FirstOrDefault(x => x.IdProducto == idPrd);




                        DateTime fecha = date.dtnext();
                        context.Ventas.Add(
                            new Venta { 
                                IdVenta = i+1,
                                IdAsesor = rnd.Next(1, maxAses),
                                IdProducto = rnd.Next(1, maxProd),
                                Fecha = fecha,
                                Margen = 30,
                                PrecioVenta = prd.PrecioSugerido,
                                estado = (fecha > DateTime.Now ? "Pendiente": "Confirmado")
                            });
                    }
                }
                context.SaveChanges();
            }
        }
    }
}

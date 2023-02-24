using Microsoft.EntityFrameworkCore;
using Tienda_Servicios.Api.Libro.Model;

namespace Tienda_Servicios.Api.Libro.ApplicationDBContext
{
    public class LibreriaContexto : DbContext
    {
        public LibreriaContexto(DbContextOptions<LibreriaContexto> options) : base(options) {}

        public DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}

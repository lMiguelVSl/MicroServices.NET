using Microsoft.EntityFrameworkCore;
using Tienda_Servicios.Api.Autor.Model;

namespace Tienda_Servicios.Api.Autor.ApplicationDBContext
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options) { }
        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}

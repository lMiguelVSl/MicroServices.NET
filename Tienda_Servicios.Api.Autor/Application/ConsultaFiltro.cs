using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda_Servicios.Api.Autor.ApplicationDBContext;
using Tienda_Servicios.Api.Autor.Model;

namespace Tienda_Servicios.Api.Autor.Application
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorLibro>
        {
            public string AutorGuid { get; set; }
        }

        public class Handler : IRequestHandler<AutorUnico, AutorLibro>
        {
            private readonly ContextoAutor _contextoAutor;
            public Handler(ContextoAutor contextoAutor)
            {
                _contextoAutor = contextoAutor;
            }

            public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contextoAutor.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if (autor == null) throw new Exception("The Autor was not found");
                return autor;
            }
        }
    }
}

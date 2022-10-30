using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda_Servicios.Api.Autor.ApplicationDBContext;
using Tienda_Servicios.Api.Autor.Model;

namespace Tienda_Servicios.Api.Autor.Application
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorLibro>> { }
        public class Handler : IRequestHandler<ListaAutor, List<AutorLibro>>
        {
            private readonly ContextoAutor _contextoAutor;
            public Handler(ContextoAutor contextoAutor)
            {
                _contextoAutor = contextoAutor;
            }

            public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contextoAutor.AutorLibro.ToListAsync();
                return autores;
            }
        }
    }
}

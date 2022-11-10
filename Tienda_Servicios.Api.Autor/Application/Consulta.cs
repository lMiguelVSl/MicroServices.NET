using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda_Servicios.Api.Autor.ApplicationDBContext;
using Tienda_Servicios.Api.Autor.Model;

namespace Tienda_Servicios.Api.Autor.Application
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorLibroDTO>> { }
        public class Handler : IRequestHandler<ListaAutor, List<AutorLibroDTO>>
        {
            private readonly ContextoAutor _contextoAutor;
            private readonly IMapper _mapper;
            public Handler(ContextoAutor contextoAutor, IMapper mapper)
            {
                _contextoAutor = contextoAutor;
                _mapper = mapper;
            }

            public async Task<List<AutorLibroDTO>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contextoAutor.AutorLibro.ToListAsync();
                var autoresDTO = _mapper.Map<List<AutorLibro>,List<AutorLibroDTO>>(autores);
                return autoresDTO;
            }
        }
    }
}

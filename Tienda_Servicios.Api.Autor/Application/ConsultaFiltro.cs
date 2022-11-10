using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda_Servicios.Api.Autor.ApplicationDBContext;
using Tienda_Servicios.Api.Autor.Model;

namespace Tienda_Servicios.Api.Autor.Application
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorLibroDTO>
        {
            public string AutorGuid { get; set; }
        }

        public class Handler : IRequestHandler<AutorUnico, AutorLibroDTO>
        {
            private readonly ContextoAutor _contextoAutor;
            private readonly IMapper _mapper;
            public Handler(ContextoAutor contextoAutor, IMapper mapper)
            {
                _contextoAutor = contextoAutor;
                _mapper = mapper;
            }

            public async Task<AutorLibroDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contextoAutor.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if (autor == null) throw new Exception("The Autor was not found");
                var autorDTO = _mapper.Map<AutorLibro, AutorLibroDTO>(autor);
                return autorDTO;
            }
        }
    }
}

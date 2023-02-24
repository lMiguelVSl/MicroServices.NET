using FluentValidation;
using MediatR;
using Tienda_Servicios.Api.Libro.ApplicationDBContext;

namespace Tienda_Servicios.Api.Libro.Application
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public Guid? AutorLibro { get; set; }
        }

        public class EjecutaValidator : AbstractValidator<Ejecuta>
        {
            public EjecutaValidator()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly LibreriaContexto _libreriaContexto;
            public Handler(LibreriaContexto libreriaContexto)
            {
                _libreriaContexto = libreriaContexto;
            }

            public Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

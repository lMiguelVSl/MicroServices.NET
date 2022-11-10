using FluentValidation;
using MediatR;
using Tienda_Servicios.Api.Autor.ApplicationDBContext;
using Tienda_Servicios.Api.Autor.Model;

namespace Tienda_Servicios.Api.Autor.Application
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidation : AbstractValidator<Ejecuta>
        {
            public EjecutaValidation()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autor = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

                _contexto.AutorLibro.Add(autor);
                var transaccions = await _contexto.SaveChangesAsync();

                if (transaccions > 0) return Unit.Value;
                throw new Exception("No se pudo insertar el autor del libro");
            }
        }
    }
}

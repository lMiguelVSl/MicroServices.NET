using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tienda_Servicios.Api.Autor.Application;
using Tienda_Servicios.Api.Autor.Model;

namespace Tienda_Servicios.Api.Autor.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AutorController : Controller
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet ("/GetAutor")]
        public async Task<ActionResult<List<AutorLibro>>> Get()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }
        
        [HttpPost ("/CreateAutor")]
        public async Task<ActionResult<Unit>> Create(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
    }
}

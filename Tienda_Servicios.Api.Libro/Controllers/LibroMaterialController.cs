using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tienda_Servicios.Api.Libro.Application;

namespace Tienda_Servicios.Api.Libro.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost ("/createBook")]
        public async Task<ActionResult<Unit>> createBook(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
        
    }
}

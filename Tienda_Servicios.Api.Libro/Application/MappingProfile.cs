using AutoMapper;
using Tienda_Servicios.Api.Libro.Model;

namespace Tienda_Servicios.Api.Libro.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibroMaterial, LibroMaterialDTO>();
        }
    }
}

using AutoMapper;
using MiactlanAPI.DTO;
using MiactlanAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Entidad, EntidadDTO>();
            CreateMap<Estado, EstadoDTO>();
            CreateMap<Entrada, EntradaDTO>()
                .ForMember(x => x.Categorias, y => y.MapFrom(z => z.CategoriasLink.Select(a => a.Categoria).ToList()));
        }
    }
}

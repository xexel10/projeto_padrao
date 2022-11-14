using AutoMapper;
using Padrao.Business.Models;

namespace Padrao.Api.DTOs.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            
            CreateMap<Categoria,CategoriaDTO>().ReverseMap();
        }
    }
}

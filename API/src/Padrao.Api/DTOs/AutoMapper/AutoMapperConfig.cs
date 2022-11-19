using AutoMapper;
using Padrao.Business.Models;
using Padrao.Business.Models.Identity;

namespace Padrao.Api.DTOs.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            
            CreateMap<Categoria,CategoriaDTO>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User,UserLoginDTO>().ReverseMap();
            CreateMap<User,UserUpdateDTO>().ReverseMap();
        }
    }
}

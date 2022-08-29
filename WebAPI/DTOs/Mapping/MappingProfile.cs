using AutoMapper;
using Entidades.Entities;

namespace WebAPI.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ShortLink, ShortLinkDTO>().ReverseMap();

        }
    }
}

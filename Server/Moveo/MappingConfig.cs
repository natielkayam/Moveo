using AutoMapper;
using Moveo.Models;
using Moveo.Models.Dto;

namespace Moveo
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDto>().ReverseMap();
            });

            return mappingConfig;
        }

    }
}

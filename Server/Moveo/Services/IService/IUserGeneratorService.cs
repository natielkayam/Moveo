using Moveo.Models.Dto;

namespace Moveo.Services.IService
{
    public interface IUserGeneratorService
    {
        public Task<UserDto>? GetRandomUser(); 
    }
}

using Moveo.Models;
using Moveo.Models.Dto;

namespace Moveo.Services.IService
{
    public interface IUsersService
    {
        public Task<ResponseDto> Fetch();

        public Task<ResponseDto> Get(Guid id);

        public Task<ResponseDto> Get(string query);

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moveo.Models;
using Moveo.Models.Dto;
using Moveo.Services.IService;

namespace Moveo.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : Controller
    {
        private readonly IUsersService _UsersService;
        private ResponseDto _response;

        public UsersApiController(IUsersService usersService)
        {
            _UsersService = usersService;
            _response = new ResponseDto();
        }

        [HttpPost]
        [Route("Fetch")]
        public async Task<ResponseDto> Fetch()
        {
            return await _UsersService.Fetch();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ResponseDto> Get(Guid id)
        {    
            return await _UsersService.Get(id);
        }

        [HttpGet()]
        public async Task<ResponseDto> Get([FromQuery] string query)
        {
            return await _UsersService.Get(query);
        }
    }
}

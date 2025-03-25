using AutoMapper;
using Moveo.Exceptions;
using Moveo.Models;
using Moveo.Models.Dto;
using Moveo.Services.IService;
using System.Collections.Generic;

namespace Moveo.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserGeneratorService _userGeneratorService;
        private readonly IMapper _mapper;
        private ResponseDto _response;
        private static List<User> _users = new List<User>();

        public UsersService(IUserGeneratorService userGeneratorService, IMapper mapper)
        {
            _userGeneratorService = userGeneratorService;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        public async Task<ResponseDto> Fetch()
        {
            try
            {
                var userDto = await _userGeneratorService.GetRandomUser();

                if (userDto == null)
                {
                    throw new RandomUserGeneratorException();
                }

                User user = _mapper.Map<User>(userDto);

                _users.Add(user);

                _response.Result = userDto;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;

                _response.Message = ex.Message.ToString();
            }

            return _response;
        }

        public async Task<ResponseDto> Get(Guid id)
        {
            try
            {
                User user = _users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    throw new UserNotFoundException(id);
                }

                UserDto userDto = _mapper.Map<UserDto>(user);

                _response.Result = userDto;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;

                _response.Message = ex.Message.ToString();
            }

            return _response;
        }

        public async Task<ResponseDto> Get(string query)
        {
            try
            {
                var matchingUsers = _users
                    .Where(u => u.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                u.LastName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                u.Email.Contains(query, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                
                if (!matchingUsers.Any())
                {
                    throw new UsersNotFoundQueryException(query);
                }

                var userDtos = _mapper.Map<List<UserDto>>(matchingUsers);
                
                _response.Result = userDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;

                _response.Message = ex.Message.ToString();
            }

            return _response;
        }
    }
}

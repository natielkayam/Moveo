using Moveo.Models.Dto;
using Moveo.Services.IService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Moveo.Services
{
    public class UserGeneratorService : IUserGeneratorService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserGeneratorService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserDto>? GetRandomUser()
        {
            try
            {
                var client = _clientFactory.CreateClient("RandomUserGenerator");

                var response = await client.GetAsync("");

                var apiContent = await response.Content.ReadAsStringAsync();

                //var randomUserApiDto = JsonConvert.DeserializeObject<RandomUserApiDto>(apiContent);

                //var userDto = randomUserApiDto.Results.FirstOrDefault();

                var jsonObject = JObject.Parse(apiContent);
                
                var userJson = jsonObject["results"]?.FirstOrDefault();

                if (userJson == null) return null;

                var userDto = new UserDto
                {
                    Id = Guid.Parse(userJson["login"]?["uuid"]?.ToString()),
                    FirstName = userJson["name"]?["first"]?.ToString(),
                    LastName = userJson["name"]?["last"]?.ToString(),
                    Email = userJson["email"]?.ToString(),
                    DateOfBirth = DateTime.Parse(userJson["dob"]?["date"]?.ToString()),
                    Phone = userJson["phone"]?.ToString(),
                    Address = userJson["location"]?["city"]?.ToString(),
                    ProfilePicture = userJson["picture"]?["large"]?.ToString()
                };

                return userDto;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}

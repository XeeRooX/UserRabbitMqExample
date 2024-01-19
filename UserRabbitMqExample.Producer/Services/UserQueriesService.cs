using AutoMapper;
using UserRabbitMqExample.Producer.Dtos;

namespace UserRabbitMqExample.Producer.Services
{
    public class UserQueriesService : IUserQueriesService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserQueriesService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<GetUserOutDto> Get(GetUserInDto user)
        {
            var getResult = await _userService.GetAsync(user.Id);
            return _mapper.Map<GetUserOutDto>(getResult);   
        }
    }
}

using AutoMapper;
using UserRabbitMqExample.Producer.Dtos;
using UserRabbitMqExample.Producer.Models;

namespace UserRabbitMqExample.Producer.Services
{
    public class UserCommandsService : IUserCommandsService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserCommandsService(IUserService userService, IMapper mapper) 
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<GetUserOutDto> Add(AddUserDto user)
        {
            var addResult = await _userService.AddAsync(_mapper.Map<Models.User>(user));
            return _mapper.Map<GetUserOutDto>(addResult);
        }

        public async Task<GetUserOutDto> Delete(GetUserInDto user)
        {
            var deleteResult = await _userService.DeleteAsync(user.Id);
            return _mapper.Map<GetUserOutDto>(deleteResult);
        }

        public async Task<GetUserOutDto> Update(EditUserDto user)
        {
            var editResult = await _userService.UpdateAsync(_mapper.Map<Models.User>(user));
            return _mapper.Map<GetUserOutDto>(editResult);
        }
    }
}

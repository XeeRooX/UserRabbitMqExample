using FluentValidation;
using UserRabbitMqExample.Producer.Dtos;
using UserRabbitMqExample.Producer.Services;

namespace UserRabbitMqExample.Producer.Validators.UserValidators
{
    public class GetUserValidator : AbstractValidator<GetUserInDto>
    {
        public GetUserValidator(IUserService userService)
        {
            RuleFor(u => u.Id).Must(id => userService.IsExistsById(id)).WithMessage("пользователя с таким id не существует");
        }
    }
}

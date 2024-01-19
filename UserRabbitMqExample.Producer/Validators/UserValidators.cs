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

    public class AddUserValidator : AbstractValidator<AddUserDto>
    {
        public AddUserValidator()
        {
            RuleFor(u => u.Firstname).Length(2, 50).WithMessage("имя должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(u => u.Lastname).Length(2, 50).WithMessage("фамилия должна иметь от {MinLength} до {MaxLength} символов");
            When(u => !string.IsNullOrEmpty(u.Surname), () =>
            {
                RuleFor(u => u.Surname).Length(2, 50).WithMessage("отчество должно иметь от {MinLength} до {MaxLength} символов");
            });
            RuleFor(u => u.DateOfBirth).Must(d => d < DateTime.Now).WithMessage("дата рождения не может быть болльше текущей");
        }
    }

    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        public EditUserValidator(IUserService userService)
        {
            RuleFor(u => u.Id).Must(id => userService.IsExistsById(id)).WithMessage("пользователя с таким id не существует");
            RuleFor(u => u.Firstname).Length(2, 50).WithMessage("имя должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(u => u.Lastname).Length(2, 50).WithMessage("фамилия должна иметь от {MinLength} до {MaxLength} символов");
            When(u => !string.IsNullOrEmpty(u.Surname), () =>
            {
                RuleFor(u => u.Surname).Length(2, 50).WithMessage("отчество должно иметь от {MinLength} до {MaxLength} символов");
            });
            RuleFor(u => u.DateOfBirth).Must(d => d < DateTime.Now).WithMessage("дата рождения не может быть болльше текущей");
        }
    }
}

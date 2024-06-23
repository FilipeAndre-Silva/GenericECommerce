using FluentValidation;

namespace GenericEcommerce.Application.Dto.User
{
    public class UpdateUserDto
    {
        public string Username { get; set; }
    }

    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");
        }
    }
}
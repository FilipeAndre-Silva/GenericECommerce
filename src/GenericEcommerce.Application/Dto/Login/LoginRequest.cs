using FluentValidation;

namespace GenericEcommerce.Application.Dto.Login
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(5).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
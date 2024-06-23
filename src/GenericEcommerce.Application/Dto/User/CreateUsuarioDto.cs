using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace GenericEcommerce.Application.Dto.User
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }

    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(5).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
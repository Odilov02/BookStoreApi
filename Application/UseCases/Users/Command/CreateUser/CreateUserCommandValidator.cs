namespace Application.UseCases.Users.Command.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
          .NotEmpty().WithMessage("should be not empty value")
          .Matches("^[a-zA-Z0-9._%+-]+@gmail\\.com$").WithMessage("Email must be in the format exemple@gmail.com");

        RuleFor(x => x.PhoneNumber)
          .NotEmpty().WithMessage("should be not empty value")
          .Matches(@"^\+998(9[0-9])\d{7}$").WithMessage("PhoneNumber should be in the format +99891 234 56 78");

        RuleFor(x => x.FullName).NotEmpty()
           .WithMessage("should be not empty value")
           .MaximumLength(50).WithMessage("fullName must have a maximum length of 50 characters");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("should be not empty value")
            .Matches("@\"^(?=.*[a-zA-Z]{4,})(?=.*\\d{4,}).{8,}$\";")
                 .WithMessage("Password must contain at least 4 letters and 4 numbers");

        RuleFor(x => x.ConfirmPassword).Equal("PasswordHash").WithMessage("confirmpassword is not homogeneous");
    }
}

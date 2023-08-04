namespace Application.UseCases.Users.Command.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserName)
              .NotEmpty().WithMessage("UserName is required.")
              .MaximumLength(50).WithMessage("UserName must have a maximum length of 50 characters.")
              .MinimumLength(5);

        RuleFor(x => x.PhoneNumber)
          .NotEmpty().WithMessage("Phone Number is required.")
          .Matches(@"^\+998(9[0-9])\d{7}$").WithMessage("PhoneNumber should be in the format '+99891 234 56 78'.");

        RuleFor(x => x.FullName).NotEmpty()
           .WithMessage("Full Name is required.")
           .MaximumLength(50).WithMessage("Full Name must have a maximum length of 50 characters.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.");
    }
}

namespace Application.UseCases.Users.Command.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Email)
          .NotEmpty().WithMessage("Email is required")
          .Matches("^[a-zA-Z0-9._%+-]+@gmail\\.com$").WithMessage("Email must be in the format exemple@gmail.com");

        RuleFor(x => x.PhoneNumber)
          .NotEmpty().WithMessage("Phone Number is required.")
          .Matches(@"^\+998(9[0-9])\d{7}$").WithMessage("PhoneNumber should be in the format '+99891 234 56 78'.");

        RuleFor(x => x.FullName).NotEmpty()
           .WithMessage("Full Name is required.")
           .MaximumLength(50).WithMessage("Full Name must have a maximum length of 50 characters.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.")
            .Matches("@\"^(?=.*[a-zA-Z]{4,})(?=.*\\d{4,}).{8,}$\";")
                 .WithMessage("Password must contain at least 4 letters and 4 numbers.");

        RuleFor(x => x.ConfirmPassword).Equal("PasswordHash").WithMessage("Confirm Password is not homogeneous");

    }
}

namespace Application.UseCases.Users.Command.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.UserName)
          .NotEmpty().WithMessage("UserName is required");

        RuleFor(x => x.PhoneNumber)
          .NotEmpty().WithMessage("Phone Number is required.")
          .Matches(@"^\+998(9[0-9])\d{7}$").WithMessage("PhoneNumber should be in the format '+998 91-234-56-78'.");

        RuleFor(x => x.FullName).NotEmpty()
           .WithMessage("Full Name is required.")
           .MaximumLength(50).WithMessage("Full Name must have a maximum length of 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

namespace Application.UseCases.Users.Command.UpdateUser;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string ConfirmPassword { get; set; }
}
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly UserManager<User> _userManager;
    public UpdateUserCommandHandler(UserManager<User> userManager) => _userManager = userManager;

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());
        if (user == null) throw new NotFoundException(typeof(User).Name, request.Id);
        user.FullName = request.FullName;
        user.PhoneNumber = request.PhoneNumber;
        user.Email = request.Email;
        user.PasswordHash = request.PasswordHash.stringHash();
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }
}

namespace Application.UseCases.Users.Command.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest<bool>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly UserManager<User> _userManager;

    public DeleteUserCommandHandler(UserManager<User> userManager) => _userManager = userManager;

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());
        if (user == null) throw new NotFoundException(typeof(User).Name, request.Id);
        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}

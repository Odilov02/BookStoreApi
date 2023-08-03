namespace Application.UseCases.Users.Command.DeleteUser;

public record DeleteUserCommand(string UserName,string Password) : IRequest<ResponseCore<User>>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseCore<User>>
{
    private readonly IUserManigerService<User> _userManager;

    public DeleteUserCommandHandler(IUserManigerService<User> userManager) => _userManager = userManager;

    public async Task<ResponseCore<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==request.UserName&&x.Password==request.Password.stringHash());
        if (user == null) throw new NotFoundException(typeof(User).Name, request.UserName);
        var result = await _userManager.DeleteAsync(user);
        var respone = new ResponseCore<User>()
        {
            Result = user,
            IsSuccess = result.Succeeded,
        };
        result.Errors.ToList().ForEach(eror =>
        {
            respone?.Errors?.ToList().Add(eror.Description);
        });
        return respone;
    }
}

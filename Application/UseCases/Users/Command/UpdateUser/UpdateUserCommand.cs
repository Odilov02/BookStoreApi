namespace Application.UseCases.Users.Command.UpdateUser;
#nullable disable
public class UpdateUserCommand : IRequest<ResponseCore<User>>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseCore<User>>
{
    private readonly IUserManigerService<User> _userManager;
    public UpdateUserCommandHandler(IUserManigerService<User> userManager) => _userManager = userManager;

    public async Task<ResponseCore<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());
        if (user == null) throw new NotFoundException(typeof(User).Name, request.Id);
        user.FullName = request.FullName;
        user.PhoneNumber = request.PhoneNumber;
        user.UserName = request.UserName;
        user.Password = request.Password.stringHash();
        var result = await _userManager.UpdateAsync(user);
        var respone = new ResponseCore<User>()
        {
            Result = user,
            IsSuccess = result.Succeeded,
        };
        result.Errors.ToList().ForEach(eror =>
        {
            respone.Errors.ToList().Add(eror.Description);
        });
        return respone;
    }
}

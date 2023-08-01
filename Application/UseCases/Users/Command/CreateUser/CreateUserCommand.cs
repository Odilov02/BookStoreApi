namespace Application.UseCases.Users.Command.CreateUser;

public class CreateUserCommand : IRequest<bool>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string ConfirmPassword { get; set; }
}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.PasswordHash = user.PasswordHash!.stringHash();
        var result = await _userManager.CreateAsync(user);
        return result.Succeeded;
    }
}
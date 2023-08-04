

namespace Application.UseCases.Users.Command.CreateUser;
#nullable disable

public class CreateUserCommand : IRequest<ResponseCore<User>>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    [Compare("PasswordHash")]
    public string ConfirmPassword { get; set; }
}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseCore<User>>
{
    private readonly UserStore<User> _userManager;
    private readonly IMapper _mapper;



    public CreateUserCommandHandler(UserStore<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<ResponseCore<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        var result = await _userManager.CreateAsync(user, cancellationToken);
        var response = new ResponseCore<User>()
        {
            Result = user,
            IsSuccess = result.Succeeded
        };
        result.Errors.ToList().ForEach(error =>
        {
            response.Errors.Add(error.Description);
        });
        return response;
    }
}
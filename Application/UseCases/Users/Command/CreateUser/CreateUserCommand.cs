using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Users.Command.CreateUser;
#nullable disable

public class CreateUserCommand : IRequest<ResponseCore<User>>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseCore<User>>
{
    private readonly IUserManigerService<User> _userManager;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserManigerService<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<ResponseCore<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.Password = user.Password;
        var result = await _userManager.CreateAsync(user,user.Password);
        var respone = new ResponseCore<User>()
        {
            Result = user,
            IsSuccess = result
        };
        string ss = "sss";
        //result.Errors.ToList().ForEach(eror =>
        //{
        //    respone.Errors.ToList().Add(eror.Description);
        //});
        return respone;
    }
}
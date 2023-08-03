using Application.UseCases.Users.Command.CreateUser;
using Application.UseCases.Users.Command.DeleteUser;
using Application.UseCases.Users.Command.UpdateUser;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IMapper _mapper;
    private readonly IUserManigerService<User> _userManager;

    private readonly IMediator _mediator;
    public UserController(IUserManigerService<User> userManager, IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _userManager = userManager;
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public IActionResult CreateUser(CreateUserCommand command) => Ok(_mediator.Send(command));
    //public async Task<IActionResult> CreateUser(CreateUserCommand command)
    //{
    //    var user = _mapper.Map<User>(command);
    //    user.Password = user.Password;
    //    var result = await _userManager.CreateAsync(user, user.Password);
    //    var respone = new ResponseCore<User>()
    //    {
    //        Result = user,
    //        IsSuccess = result
    //    };
    //    string ss = "sss";
    //    return Ok(respone);
    //}


    [HttpPut("[action]")]
    public IActionResult UpdateUser(UpdateUserCommand command) => Ok(_mediator.Send(command));


    [HttpDelete("[action]")]
    public IActionResult DeleteUser(DeleteUserCommand command) => Ok(_mediator.Send(command));

}
public class CreateUserCommand1 : IRequest<ResponseCore<User>>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
public class CreateUserCommandHandler1 : IRequestHandler<CreateUserCommand1, ResponseCore<User>>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler1(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<ResponseCore<User>> Handle(CreateUserCommand1 request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            FullName = request.FullName,
            Password = request.Password,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
        };
        string rr = "ss";
        var result = await _userManager.CreateAsync(user, user.Password);
        var respone = new ResponseCore<User>()
        {
            Result = user,
            IsSuccess = result.Succeeded
        };
        string ss = "sss";
        //result.Errors.ToList().ForEach(eror =>
        //{
        //    respone.Errors.ToList().Add(eror.Description);
        //});
        return respone;
    }
}
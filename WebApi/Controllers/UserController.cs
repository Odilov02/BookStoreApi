using Application.UseCases.Users.Command.CreateUser;
using Application.UseCases.Users.Command.DeleteUser;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ApiControllerBase
{

    [HttpPost("[action]")]
    public IActionResult CreateUser(CreateUserCommand command) => Ok(_mediator.Send(command));


    [HttpDelete("[action]")]
    public IActionResult DeleteUser(DeleteUserCommand command) => Ok(_mediator.Send(command));

}

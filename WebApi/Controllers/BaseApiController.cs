

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IMediator _mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}

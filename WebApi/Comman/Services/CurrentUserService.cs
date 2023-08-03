using System.Security.Claims;

namespace WebApi.Comman.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

        public string UserName => _contextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}

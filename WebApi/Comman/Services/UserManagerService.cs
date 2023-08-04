using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Comman.Services;

public class UserManagerService : UserStore<User>, IUserManigerService<User>
{
    public UserManagerService(DbContext context, IdentityErrorDescriber? describer = null)
        : base(context, describer)
    {
    }
}

using Microsoft.AspNetCore.Identity;

namespace WebApi.Comman.Services;

public class UserManagerService : IUserManigerService<User>
{
    private readonly UserManager<User> _userManager;

    public UserManagerService(UserManager<User> userManager) => _userManager = userManager;

    public IQueryable<User> Users => _userManager.Users;

    public async Task<bool> CreateAsync(User user, string password)
    {
        string ss = "ss";
        var user2 = new User()
        {
             FullName=user.FullName,
              Password=user.Password,
              UserName=user.UserName,
              PhoneNumber=user.PhoneNumber,
        };
        var users =  _userManager.Users.ToList();
        ss = "sssssssssss";
        return true;
    }

    public async Task<IdentityResult> CreateAsync(User user) => await _userManager.CreateAsync(user);

    public async Task<IdentityResult> DeleteAsync(User user) => await _userManager.DeleteAsync(user);

    public async Task<IdentityResult> UpdateAsync(User user) => await _userManager.UpdateAsync(user);
}

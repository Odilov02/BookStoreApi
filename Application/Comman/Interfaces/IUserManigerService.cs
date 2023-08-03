namespace Application.Comman.Interfaces;

public interface IUserManigerService<TUser> where TUser : class
{
    IQueryable<TUser> Users { get; }
    Task<bool> CreateAsync(TUser user, string password);
    Task<IdentityResult> CreateAsync(TUser user);
    Task<IdentityResult> DeleteAsync(TUser user);
    Task<IdentityResult> UpdateAsync(TUser user);
}


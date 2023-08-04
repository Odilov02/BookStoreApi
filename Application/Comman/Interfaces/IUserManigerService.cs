namespace Application.Comman.Interfaces;

public interface IUserManigerService<TUser> : IUserStore<TUser> where TUser : class
{

}


using Application.UseCases.Users.Command.CreateUser;

namespace Application.Comman.Mappings;

public class UserMapping : Profile
{
    public UserMapping() => UserMap();

    void UserMap()
    {
        CreateMap<CreateUserCommand, User>();
    }
}

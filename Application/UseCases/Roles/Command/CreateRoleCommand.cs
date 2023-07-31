namespace Application.UseCases.Role.Command;

public record CreateRoleCommand(string RoleName) : IRequest<bool>;
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;
    public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.RoleName,
        };
        var result = await _roleManager.CreateAsync(role);
        return result.Succeeded;
    }
}
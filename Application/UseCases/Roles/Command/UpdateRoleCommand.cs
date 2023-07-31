namespace Application.UseCases.Role.Command;

public record UpdateRoleCommand(Guid Id, string RoleName) : IRequest<bool>;
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public UpdateRoleCommandHandler(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;
    public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());
        if (role == null) return false;
        role.Name = request.RoleName;
        var result = await _roleManager.UpdateAsync(role);
        return result.Succeeded;
    }
}

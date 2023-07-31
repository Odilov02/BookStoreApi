namespace Application.UseCases.Role.Command;

public record DeleteRoleCommand(Guid Id) : IRequest<bool>;
public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public DeleteRoleCommandHandler(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;
    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());
        if (role == null) return false;
        var result = await _roleManager.DeleteAsync(role);
        return result.Succeeded;
    }
}

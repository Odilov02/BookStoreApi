namespace Application.UseCases.Roles.Query.GetRole;

public record GetRoleQuery(Guid Id) : IRequest<IdentityRole>;

public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, IdentityRole>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public GetRoleQueryHandler(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;
    public async Task<IdentityRole> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());
        if (role == null) return new IdentityRole();
        return role;
    }
}


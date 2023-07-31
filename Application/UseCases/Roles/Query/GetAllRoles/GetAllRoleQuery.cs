namespace Application.UseCases.Roles.Query.GetAllRoles;

public record GetAllRoleQuery(int PageSize, int PageIndex) : IRequest<PaginatedList<IdentityRole>>;
public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, PaginatedList<IdentityRole>>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public GetAllRoleQueryHandler(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;
    public async Task<PaginatedList<IdentityRole>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleManager.Roles.ToListAsync(cancellationToken);
        var paginatedlist = PaginatedList<IdentityRole>.Create(roles, request.PageSize, request.PageIndex);
        return paginatedlist;
    }
}


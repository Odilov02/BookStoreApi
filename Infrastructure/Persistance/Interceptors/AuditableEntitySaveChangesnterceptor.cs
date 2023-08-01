using Application.Comman.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistance.Interceptors;

public class AuditableEntitySaveChangesnterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;

    public AuditableEntitySaveChangesnterceptor(ICurrentUserService currentUserService)
            => _currentUserService = currentUserService;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    void UpdateEntities(DbContext? context)
    {
        if (context == null) return;
        foreach (var entity in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedBy = _currentUserService.UserName;
                entity.Entity.Created = DateTime.Now;
            }
            if (entity.State == EntityState.Modified)
            {
                entity.Entity.LastedBy = _currentUserService.UserName;
                entity.Entity.Lasted = DateTime.Now;
            }
        }
    }
}

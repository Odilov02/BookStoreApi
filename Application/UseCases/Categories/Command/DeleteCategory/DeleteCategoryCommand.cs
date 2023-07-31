namespace Application.UseCases.Categories.Command.DeleteCategory;

public record DeleteCategoryCommand(Guid Id) : IRequest<bool>;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;

    public DeleteCategoryCommandHandler(IApplicatonDbcontext dbContext) => _dbContext = dbContext;
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (category == null) return false;
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

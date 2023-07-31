namespace Application.UseCases.Categories.Query.GetCategory;

public record GetCategoryQuery(Guid Id) : IRequest<Category>;

public class GetCAtegoryQueryHAndler : IRequestHandler<GetCategoryQuery, Category>
{
    private readonly IApplicatonDbcontext _dbContext;
    public GetCAtegoryQueryHAndler(IApplicatonDbcontext dbContext) => _dbContext = dbContext;

    public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (category == null) return new Category();
        return category;
    }
}
namespace Application.UseCases.Categories.Query.GetAllCategory;

public record GetAllCategoryQuery(int PageSize, int PageIndex) : IRequest<PaginatedList<Category>>;
public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, PaginatedList<Category>>
{
    IApplicatonDbcontext _dbContext;
    public GetAllCategoryQueryHandler(IApplicatonDbcontext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<PaginatedList<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var Categories = _dbContext.Categories.ToList();
        PaginatedList<Category> result = PaginatedList<Category>.Create(Categories, request.PageSize, request.PageIndex);
        return Task.FromResult(result);
    }
}

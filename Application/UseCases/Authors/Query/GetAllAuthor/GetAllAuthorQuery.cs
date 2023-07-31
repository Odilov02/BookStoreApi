namespace Application.UseCases.Authors.Query.GetAllAuthor;

public record GetAllAuthorQuery (int PageSize, int PageIndex) : IRequest<PaginatedList<Author>>;

public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, PaginatedList<Author>>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public GetAllAuthorQueryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public Task<PaginatedList<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        var authors = _dbcontext.Authors.ToList();
        var result = PaginatedList<Author>.Create(authors, request.PageSize, request.PageIndex);
        return Task.FromResult(result);
    }
}

namespace Application.UseCases.Authors.Query.GetAuthor;

public record GetAuthorQuery(Guid Id) : IRequest<Author>;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, Author>
{
    private readonly IApplicatonDbcontext _dbcontext;

    public GetAuthorQueryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;

    public async Task<Author> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    => (await _dbcontext.Authors.FirstOrDefaultAsync(x => x.Id == request.Id))!;
}
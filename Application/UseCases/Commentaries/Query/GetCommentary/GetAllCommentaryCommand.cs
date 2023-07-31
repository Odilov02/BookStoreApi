namespace Application.UseCases.Commentaries.Query.GetCommentary;

public record GetAllCommentaryCommand(int PageSize, int PageIndex) : IRequest<PaginatedList<Commentary>>;

public class GetAllCommentaryCommentaryHandler : IRequestHandler<GetAllCommentaryCommand, PaginatedList<Commentary>>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public GetAllCommentaryCommentaryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public Task<PaginatedList<Commentary>> Handle(GetAllCommentaryCommand request, CancellationToken cancellationToken)
    {
        var commentaries = _dbcontext.Commentaries.ToList();
        var result = PaginatedList<Commentary>.Create(commentaries, request.PageSize, request.PageIndex);
        return Task.FromResult(result);
    }
}

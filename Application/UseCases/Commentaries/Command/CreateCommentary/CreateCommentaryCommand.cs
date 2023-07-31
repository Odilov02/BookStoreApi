namespace Application.UseCases.Commentaries.Command.CreateCommentary;

public record CreateCommentaryCommand(Guid BookId, string Description, string UserId) : IRequest<bool>;
public class CreateCommentaryCommandHandler : IRequestHandler<CreateCommentaryCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;

    public CreateCommentaryCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateCommentaryCommand request, CancellationToken cancellationToken)
    {
        var commentary = _mapper.Map<Commentary>(request);
        if (commentary == null) return false;
        await _dbContext.Commentaries.AddAsync(commentary, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

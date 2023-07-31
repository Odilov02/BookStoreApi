namespace Application.UseCases.Authors.Command.UpdateAuthor;

public record UpdateAuthorCommand(Guid Id, string FullName, string ImgUrl, string Description) : IRequest<bool>;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Author>(request);
        if (author is null) return false;
        if (await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == author.Id) is null) return false;
        _dbContext.Authors.Update(author);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

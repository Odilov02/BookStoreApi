namespace Application.UseCases.Authors.Command.DeleteAuthor;

public record DeleteAuthorCommand(Guid Id) : IRequest<bool>;
public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
{
    private readonly IApplicatonDbcontext _context;
    public DeleteAuthorCommandHandler(IApplicatonDbcontext context) => _context = context;
    public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _context.Authors.ToList().FirstOrDefault(x => x.Id == request.Id);
        if (author != null) return false;
        _context.Authors.Remove(author!);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

namespace Application.UseCases.Orders.Command.DeleteOrder;

public record DeleteOrderCommand(Guid Id) : IRequest<bool>;
public record DeleteOrderCommandhandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public DeleteOrderCommandhandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _dbcontext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (order == null) return false;
        _dbcontext.Orders.Remove(order);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

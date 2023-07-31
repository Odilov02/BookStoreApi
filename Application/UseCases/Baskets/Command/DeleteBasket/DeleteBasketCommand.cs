namespace Application.UseCases.Baskets.Command.DeleteBasket;

public record DeleteBasketCommand(Guid Id) : IRequest<bool>;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public DeleteBasketCommandHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await _dbcontext.Baskets.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (basket == null) return false;
        _dbcontext.Baskets.Remove(basket);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

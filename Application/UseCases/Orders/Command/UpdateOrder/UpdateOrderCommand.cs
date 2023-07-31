namespace Application.UseCases.Orders.Command.UpdateOrder;

public class UpdateOrderCommand : IRequest<bool>
{

    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid BookId { get; set; }
    public decimal Price { get; set; }
    public bool IsDeliver { get; set; }
}
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    public UpdateOrderCommandHandler(IApplicatonDbcontext dbContext) => _dbContext = dbContext;
    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _dbContext.Orders.FirstAsync(x => x.Id == request.Id);
        if (order == null) return false;
        order.Price = request.Price;
        order.IsDeliver = request.IsDeliver;
        order.UserId = request.UserId;
        order.BookId = request.BookId;
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
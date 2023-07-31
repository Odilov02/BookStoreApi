namespace Application.UseCases.Orders.Query.GetOrder;

public record GetOrderQuery(Guid Id) : IRequest<Order>;

public record GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public GetOrderQueryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _dbcontext.Orders.FirstOrDefaultAsync(o => o.Id == request.Id);
        if (order == null) return new Order();
        return order;
    }
}
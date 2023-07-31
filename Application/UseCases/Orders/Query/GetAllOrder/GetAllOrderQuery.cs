namespace Application.UseCases.Orders.Query.GetAllOrder;

public record GetAllOrderQuery(int PageIndex, int PageSize) : IRequest<PaginatedList<Order>>;
public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, PaginatedList<Order>>
{
    private readonly IApplicatonDbcontext _dbContext;
    public GetAllOrderQueryHandler(IApplicatonDbcontext dbContext) => _dbContext = dbContext;
    public async Task<PaginatedList<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var orders = await _dbContext.Orders.ToListAsync(cancellationToken);
        return PaginatedList<Order>.Create(orders, request.PageSize, request.PageIndex);
    }
}



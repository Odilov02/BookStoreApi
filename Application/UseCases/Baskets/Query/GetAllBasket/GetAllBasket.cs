namespace Application.UseCases.Baskets.Query.GetAllBasket;

public record GetAllBasketQuery(int PageIndex, int PageSize) : IRequest<PaginatedList<Basket>>;
public class GetAllBasketQueryHandler : IRequestHandler<GetAllBasketQuery, PaginatedList<Basket>>
{
    private IApplicatonDbcontext _dbcontext;
    public GetAllBasketQueryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<PaginatedList<Basket>> Handle(GetAllBasketQuery request, CancellationToken cancellationToken)
    {
        var baskets = await _dbcontext.Baskets.ToListAsync(cancellationToken); ;
        var PaginatedList = PaginatedList<Basket>.Create(baskets, request.PageSize, request.PageIndex);
        return PaginatedList;
    }
}

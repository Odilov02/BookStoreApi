namespace Application.UseCases.Baskets.Query.GetAllBasket;
public record GetBasketQuery(Guid Id) : IRequest<Basket>;
public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, Basket>
{
    private IApplicatonDbcontext _dbcontext;
    public GetBasketQueryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<Basket> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await _dbcontext.Baskets.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (basket == null) return new Basket();
        return basket;
    }
}

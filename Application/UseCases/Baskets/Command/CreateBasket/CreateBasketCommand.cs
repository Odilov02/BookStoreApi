namespace Application.UseCases.Baskets.Command.CreateBasket;

public class CreateBasketCommand : IRequest<bool>
{
    public string UserId { get; set; }
    public Guid BookId { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
public record CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IApplicatonDbcontext _dbcontext;

    public CreateBasketCommandHandler(IMapper mapper, IApplicatonDbcontext dbcontext)
    {
        _mapper = mapper;
        _dbcontext = dbcontext;
    }

    public async Task<bool> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = _mapper.Map<Basket>(request);
        if (basket == null) return false;
        await _dbcontext.Baskets.AddAsync(basket, cancellationToken);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

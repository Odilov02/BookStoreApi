namespace Application.UseCases.Baskets.Command.UpdateBasket;

public class UpdateBasketCommand : IRequest<bool>
{

    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid BookId { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}

public record UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IApplicatonDbcontext _dbcontext;

    public UpdateBasketCommandHandler(IMapper mapper, IApplicatonDbcontext dbcontext)
    {
        _mapper = mapper;
        _dbcontext = dbcontext;
    }

    public async Task<bool> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = _mapper.Map<Basket>(request);
        if (basket == null) return false;
        _dbcontext.Baskets.Update(basket);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        return true;
    }
}


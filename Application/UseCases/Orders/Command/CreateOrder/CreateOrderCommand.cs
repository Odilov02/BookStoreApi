namespace Application.UseCases.Orders.Command.CreateOrder;

public class CreateOrderCommand : IRequest<bool>
{
    public string UserId { get; set; }
    public Guid BookId { get; set; }
    public decimal Price { get; set; }
    public bool IsDeliver { get; set; }
}
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request);
        if (order == null) return false;
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
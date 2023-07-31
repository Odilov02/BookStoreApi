namespace Application.UseCases.Books.Command.CreateBook;

public class CreateBookCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public int PageCount { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Count { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
}

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
{
    private readonly IApplicatonDbcontext _context;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IApplicatonDbcontext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request);
        if (book == null) return false;
        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
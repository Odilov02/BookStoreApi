namespace Application.UseCases.Books.Command.UpdateBook;

public class UpdateBookCommand : IRequest<bool>
{
    public Guid Id { get; set; }
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
public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IApplicatonDbcontext _dbcontext;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IApplicatonDbcontext dbcontext, IMapper mapper)
    {
        _dbcontext = dbcontext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request);
        if (book == null) return false;
        if (await _dbcontext.Books.FirstOrDefaultAsync(x => x.Id == book.Id) is null) return false;
        _dbcontext.Books.Update(book);
        return true;
    }
}

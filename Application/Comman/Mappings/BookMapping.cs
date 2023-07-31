using Application.UseCases.Books.Command.CreateBook;
using Application.UseCases.Books.Command.UpdateBook;

namespace Application.Comman.Mappings
{
    public class BookMapping : Profile
    {
        public BookMapping()
        {
            BookMap();
        }
        void BookMap()
        {
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
        }
    }
}

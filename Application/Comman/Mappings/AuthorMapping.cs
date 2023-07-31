using Application.UseCases.Authors.Command.CreateAuthor;
using Application.UseCases.Authors.Command.UpdateAuthor;

namespace Application.Comman.Mappings
{
    public class AuthorMapping : Profile
    {
        public AuthorMapping()
        {
            AuthorMap();

        }
        private void AuthorMap()
        {
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
        }
    }
}

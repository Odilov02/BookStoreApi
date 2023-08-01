using Application.UseCases.Commentaries.Command.CreateCommentary;
using Application.UseCases.Commentaries.Command.UpdateCommentary;

namespace Application.Comman.Mappings
{
    public class CommentaryMapping : Profile
    {
        public CommentaryMapping() => CommentaryMap();
        void CommentaryMap()
        {
            CreateMap<CreateCommentaryCommand, Commentary>();
            CreateMap<UpdateCommentaryCommand, Commentary>();
        }
    }
}

using Application.UseCases.Commentaries.Command.CreateCommentary;
using Application.UseCases.Commentaries.Command.UpdateCommentary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comman.Mappings
{
    public class CommentaryMapping:Profile
    {
        public CommentaryMapping()
        {
            CreateMap<CreateCommentaryCommand, Commentary>(); 
            CreateMap<UpdateCommentaryCommand, Commentary>(); 
        }
    }
}

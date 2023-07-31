using Domain.Common;

namespace Domain.Entities;

public class Commentary : BaseEntity
{
    public string Description { get; set; }
    public Guid BookId { get; set; }
    public virtual Book Book { get; set; }
    public string UserId { get; set; }
    public virtual User User { get; set; }
}

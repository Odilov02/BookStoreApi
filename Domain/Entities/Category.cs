using Domain.Common;

namespace Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Descraption { get; set; }
    public virtual ICollection<Book>? Books { get; set; }
}


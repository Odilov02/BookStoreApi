using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Descraption { get; set; }
    public virtual ICollection< Book>? Books { get; set; }
}


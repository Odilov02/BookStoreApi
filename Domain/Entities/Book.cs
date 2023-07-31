using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Book : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public string Language { get; set; }
    public int  PageCount { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Count { get; set; }
    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<Commentary>? commentaries { get; set; }
    public virtual ICollection<Basket>? baskets { get; set; }
}


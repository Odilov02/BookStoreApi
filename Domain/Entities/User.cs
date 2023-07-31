using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public string FullName { get; set; }
    public virtual ICollection<Commentary>? Commentaries { get; set; }
    public virtual ICollection<Basket>? Baskets { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }

}


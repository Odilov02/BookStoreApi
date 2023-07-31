using Domain.Common;

namespace Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}

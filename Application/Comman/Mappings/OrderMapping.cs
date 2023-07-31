using Application.UseCases.Orders.Command.CreateOrder;

namespace Application.Comman.Mappings
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            OrderMap();
        }
        void OrderMap()
        {
            CreateMap<CreateOrderCommand, Order>();
        }
    }
}

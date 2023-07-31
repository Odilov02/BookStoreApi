using Application.UseCases.Baskets.Command.CreateBasket;
using Application.UseCases.Baskets.Command.UpdateBasket;

namespace Application.Comman.Mappings;

public class BasketMapping:Profile
{
    public BasketMapping()
    {
        BasketMap();
    }
        void BasketMap()
        {
            CreateMap<CreateBasketCommand, Basket>();
            CreateMap<UpdateBasketCommand, Basket>();
        }
}

using Northwind.Entities.Concrete;

namespace NorthwindMvc.WebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}

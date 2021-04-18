using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Cart;

namespace Application.Catalog.Cart
{
    public interface ICartService
    {
        Task<CartViewModel> GetCart(Guid userId);

        Task<int> AddToCart(Guid iduser, int mamanga, int quantity);

        Task<int> Remove(Guid iduser, int cartid);
    }
}
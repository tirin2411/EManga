using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.WishList;

namespace Application.WishLists
{
    public interface IWishListService
    {
        Task<List<WishListItemVM>> GetWishListByIdUser(Guid userId);
        Task<int> Create(Guid userId, int mangaId);
        Task<int> Delete(Guid userId, int mangaId);


    }
}

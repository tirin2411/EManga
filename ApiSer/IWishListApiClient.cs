using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.WishList;

namespace ApiSer
{
    public interface IWishListApiClient
    {
        Task<List<WishListItemVM>> GetListMnByIdUser(Guid userId);
    }
}

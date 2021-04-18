using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.System.Users.Address;

namespace Application.System.Users.Address
{
    public interface IAddressService
    {
        Task<List<AddressViewModel>> GetAll();

        Task<AddressViewModel> GetById(int addressId);

        Task<int> Add(Guid iduser, AddressCreate request);

        Task<int> Detele(int addressId);
    }
}
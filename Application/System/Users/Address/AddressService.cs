using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.System.Users.Address;

namespace Application.System.Users.Address
{
    public class AddressService : IAddressService
    {
        private readonly MnDbContext _context;

        public AddressService(MnDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Guid iduser, AddressCreate request)
        {
            var address = new DiaChi()
            {
                Diachi = request.Diachi,
                TinhThanh = request.TinhThanh
            };
            _context.DiaChis.Add(address);
            await _context.SaveChangesAsync();
            return address.Id;
        }

        public async Task<int> Detele(int addressId)
        {
            var address = await _context.DiaChis.FindAsync(addressId);
            if (address == null)
                throw new FMNException($"Cannot find an address with id {addressId}");
            _context.DiaChis.Remove(address);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<AddressViewModel>> GetAll()
        {
            var query = from u in _context.AppUsers
                        select new { u };
            var data = await query.Select(x => new AddressViewModel()
            {
                Ho = x.u.Ho,
                Ten = x.u.Ten,
                UserId = x.u.Id
            }).ToListAsync();

            return data;
        }

        public async Task<AddressViewModel> GetById(int addressId)
        {
            var address = await _context.DiaChis.FindAsync(addressId);
            var addressViewModel = new AddressViewModel()
            {
                Id = address.Id,
                Diachi = address.Diachi,
                TinhThanh = address.TinhThanh
            };
            return addressViewModel;
        }
    }
}
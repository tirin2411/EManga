using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Utilities.Contacts;

namespace Application.Utilities.Contacts
{
    public class ContactService : IContactService
    {
        private readonly MnDbContext _context;

        public ContactService(MnDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ContactCreate request)
        {
            var lienhe = new LienHe()
            {
                HoTen = request.HoTen,
                DiaChi = request.DiaChi,
                SDT = request.SDT,
                NoiDung = request.NoiDung
            };
            _context.LienHes.Add(lienhe);
            await _context.SaveChangesAsync();
            return lienhe.Id;
        }

        public async Task<ContactViewModel> GetById(int idContact)
        {
            var contact = await _context.LienHes.FindAsync(idContact);

            var contactViewModel = new ContactViewModel()
            {
                Id = contact.Id,
                HoTen = contact.HoTen,
                DiaChi = contact.DiaChi,
                SDT = contact.SDT,
                NoiDung = contact.NoiDung,
                NgayGui = contact.NgayGui
            };
            return contactViewModel;
        }

        public async Task<List<ContactViewModel>> GetList()
        {
            return await _context.LienHes.Select(i => new ContactViewModel()
            {
                Id = i.Id,
                HoTen = i.HoTen,
                DiaChi = i.DiaChi,
                SDT = i.SDT,
                NoiDung = i.NoiDung,
                NgayGui = i.NgayGui
            }).ToListAsync();
        }
    }
}
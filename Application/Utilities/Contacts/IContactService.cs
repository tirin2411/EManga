using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Utilities.Contacts;

namespace Application.Utilities.Contacts
{
    public interface IContactService
    {
        Task<List<ContactViewModel>> GetList();

        Task<ContactViewModel> GetById(int idContact);

        Task<int> Create(ContactCreate request);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Utilities.Contacts
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayGui { get; set; }
    }
}
using Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalog.Giohang
{
    public class Giohang : IGiohang
    {
        private readonly MnDbContext _context;

        public Giohang(MnDbContext context)
        {
            _context = context;
        }
    }
}
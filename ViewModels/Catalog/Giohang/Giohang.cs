using Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels.Catalog.Mangas;

namespace ViewModels.Catalog.Giohang
{
    public class Giohang
    {
        private readonly MnDbContext _context;

        public Giohang(MnDbContext context)
        {
            _context = context;
        }

        public int MangaId { get; set; }
        public string Ten { set; get; }
        public string LinkAnh { get; set; }
        public float Gia { set; get; }
        public int soluong { get; set; }
        public int giamgia { get; set; }

        public DiscountBoxModel DiscountBox { get; set; }

        public float Tongtien
        {
            get
            {
                var tongtien = (float)Gia * soluong;
                return (float)Math.Ceiling(tongtien);
            }
        }

        public Giohang(int mangaid)
        {
            MangaId = mangaid;
        }

        public partial class DiscountBoxModel
        {
            public DiscountBoxModel()
            {
                AppliedDiscountsWithCodes = new List<DiscountInfoModel>();
                Messages = new List<string>();
            }

            public List<DiscountInfoModel> AppliedDiscountsWithCodes { get; set; }
            public bool Display { get; set; }
            public List<string> Messages { get; set; }
            public bool IsApplied { get; set; }

            public class DiscountInfoModel
            {
                public string CouponCode { get; set; }
            }
        }
    }
}
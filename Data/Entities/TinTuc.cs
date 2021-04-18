using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class TinTuc
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string HinhAnhtintuc { get; set; }
        public string NoiDungTomTat { get; set; }
        public string NoiDung { get; set; }
        public string Tacgia { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool AnHien { get; set; }
        public string Meta { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string TuaDe { get; set; }
        public string HinhAnhblog { get; set; }
        public string NoiDungBlog { get; set; }

        //public string Tacgia { get; set; }
        public DateTime NgayCapNhat { get; set; }

        public bool AnHien { get; set; }
        public string Meta { get; set; }
    }
}
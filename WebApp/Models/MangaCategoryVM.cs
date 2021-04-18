using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Mangas;
using ViewModels.Catalog.Theloai;
using ViewModels.Common;

namespace WebApp.Models
{
    public class MangaCategoryVM
    {
        public TheloaiViewModel Theloai { get; set; }

        public PagedResult<MangaViewModel> Mangas { get; set; }
    }
}

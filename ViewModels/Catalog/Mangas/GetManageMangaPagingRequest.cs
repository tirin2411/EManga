using ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Mangas
{
    public class GetManageMangaPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int? TheloaiId { get; set; }
    }
}
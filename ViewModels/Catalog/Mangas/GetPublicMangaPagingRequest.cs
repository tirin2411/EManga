using ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Mangas
{
    public class GetPublicMangaPagingRequest : PagingRequestBase
    {
        public int? TheloaiId { get; set; }
    }
}

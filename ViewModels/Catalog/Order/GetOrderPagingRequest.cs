using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Common;

namespace ViewModels.Catalog.Order
{
    public class GetOrderPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
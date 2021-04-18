using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class WishList
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<WishListItem> WishListItems { get; set; }

    }
}

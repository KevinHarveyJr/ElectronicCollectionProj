using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class CollectorWishlist
    {
        [Key]
        public int WishListId { get; set; }
        public string WishList { get; set; }

        [ForeignKey("Collector")]
        public int CollectorId { get; set; }
        public Collector Collector { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string RAWGItemTitle { get; set; }
    }
}

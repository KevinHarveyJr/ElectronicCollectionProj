using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class Item
    {
        [Key]
        
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        
        [Display(Name = "Item Type")]
        public string Type { get; set; }
        
        [Display(Name = "Item Genre")]
        public string Genre { get; set; }

        [Display(Name = "Item's Release Date")]
        public DateTime ReleaseDate { get; set; }
    }
}

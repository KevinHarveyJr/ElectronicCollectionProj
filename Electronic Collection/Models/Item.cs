using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        
        [Display(Name = "Item's Release Date")]
        public DateTime ReleaseDate { get; set; }


        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public GenreObj GenreObj { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public TypeObj TypeObj { get; set; }
    }
}

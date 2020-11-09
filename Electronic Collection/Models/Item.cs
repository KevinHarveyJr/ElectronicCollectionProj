using Newtonsoft.Json;
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
        public string Released { get; set; }
        




        [ForeignKey("GenreObj")]
        public int GenreId { get; set; }
        public GenreObj GenreObj { get; set; }

        [ForeignKey("TypeObj")]
        public int TypeId { get; set; }
        public TypeObj TypeObj { get; set; }

        [ForeignKey("CollectorLikes")]
        public bool IsDislike { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class GenreObj
    {
        [Key]
        public int GenreId { get; set; }

        [Display(Name = "Title of Genre")]
        public string Title { get; set; }
    }
}

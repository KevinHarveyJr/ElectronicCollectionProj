using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class TypeObj
    {
        [Key]
        public int TypeId { get; set; }

        [Display(Name = "Title of Type")]
        public string TypeTitle { get; set; }
    }
}

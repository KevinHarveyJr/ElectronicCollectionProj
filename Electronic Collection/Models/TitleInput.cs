using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class TitleInput
    {
        [Key]
        public int Id { get; set; }
        public string TitleToSearchBy { get; set; }
    }
}

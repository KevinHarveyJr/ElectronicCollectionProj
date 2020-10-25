using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Collector's Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name ="Message Text")]
        public string Text { get; set; }
        public DateTime When { get; set; }
    }
}

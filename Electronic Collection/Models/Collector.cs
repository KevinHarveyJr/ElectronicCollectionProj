using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Models
{
    public class Collector
    {
        [Key]
        public int CollectorId { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Favorite Console")]
        public string Console { get; set; }
        [Display(Name = "Favorite Game")]
        public string Game { get; set; }
        [Display(Name = "Favorite Genre")]
        public string Genre { get; set; }
        [Display(Name = "Favorite Gaming Moment")]
        public string GamingMoment { get; set; }
        [Display(Name = "Full Name")]
        public string PicturePath { get; set; }
        
        
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}

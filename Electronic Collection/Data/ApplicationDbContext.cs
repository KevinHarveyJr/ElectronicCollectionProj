using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Electronic_Collection.Models;

namespace Electronic_Collection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CollectionObj>().HasKey(o => new { o.CollectorId, o.ItemId });
            builder.Entity<CollectorWishlist>().HasKey(w => new { w.CollectorId, w.ItemId });
            builder.Entity<CollectorLikes>().HasKey(l => new { l.CollectorId, l.ItemId });
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Collector",
                NormalizedName = "COLLECTOR"
            }
            );
        }


        public DbSet<Electronic_Collection.Models.Collector> Collector { get; set; }

        public DbSet<Electronic_Collection.Models.Item> Item { get; set; }

        public DbSet<Electronic_Collection.Models.CollectionObj> CollectorCollection { get; set; }

        public DbSet<Electronic_Collection.Models.CollectorLikes> CollectorLikes { get; set; }

        public DbSet<Electronic_Collection.Models.CollectorWishlist> CollectorWishlist { get; set; }

        public DbSet<Electronic_Collection.Models.GenreObj> Genre { get; set; }

        public DbSet<Electronic_Collection.Models.TypeObj> Type { get; set; }

    }
}

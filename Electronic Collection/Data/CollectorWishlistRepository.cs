using Electronic_Collection.Contracts;
using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Data
{
    public class CollectorWishlistRepository : RepositoryBase<CollectorWishlist>, ICollectorWishlistRepository
    {
        public CollectorWishlistRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public CollectorWishlist GetCollectorWishlist(int collectorId, int itemId) => FindByCondition(l => l.CollectorId.Equals(collectorId) && l.ItemId.Equals(itemId)).SingleOrDefault();

        public void CreateCollectorWishlist(CollectorWishlist collectorWishlist) => Create(collectorWishlist);
    }
}

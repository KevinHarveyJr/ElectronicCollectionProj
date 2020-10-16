using Electronic_Collection.Contracts;
using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Data
{
    public class CollectorLikesRepository : RepositoryBase<CollectorLikes>, ICollectorLikesRepository
    {
        public CollectorLikesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public CollectorLikes GetCollectorLikes(int collectorId, int itemId) => FindByCondition(l => l.CollectorId.Equals(collectorId) && l.ItemId.Equals(itemId)).SingleOrDefault();

        public void CreateCollectorLikes(CollectorLikes collectorLikes) => Create(collectorLikes);
    }
}

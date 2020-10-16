using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Contracts
{
    public interface ICollectorLikesRepository : IRepositoryBase<CollectorLikes>
    {
        CollectorLikes GetCollectorLikes(int collectorId, int itemId);
        void CreateCollectorLikes(CollectorLikes collectorLikes);
    }
}

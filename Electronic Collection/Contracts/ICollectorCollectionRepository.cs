using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Contracts
{
    public interface ICollectorCollectionRepository : IRepositoryBase<CollectionObj>
    {
        CollectionObj GetCollectionObj(int collectorId, int itemId);
        void CreateCollectorCollection(CollectionObj collectionObj);
    }
}

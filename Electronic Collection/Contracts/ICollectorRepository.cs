using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Contracts
{
    public interface ICollectorRepository : IRepositoryBase<Collector>
    {
        Collector GetCollector(int collectorId);
        void CreateCollector(Collector collector);
    }
}

using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Contracts
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        Item GetItem(int item);
        void CreateItem(Item item);
    }
}

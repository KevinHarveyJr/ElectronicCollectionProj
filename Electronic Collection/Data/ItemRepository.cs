using Electronic_Collection.Contracts;
using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Data
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public Item GetItem(int itemId) => FindByCondition(i => i.ItemId.Equals(itemId)).SingleOrDefault();

        public void CreateItem(Item item) => Create(item);
    }
}

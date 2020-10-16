using Electronic_Collection.Contracts;
using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Data
{
    public class TypeRepository : RepositoryBase<TypeObj>, ITypeRepository
    {
        public TypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public TypeObj GetTypeObj(int typeId) => FindByCondition(c => c.TypeId.Equals(typeId)).SingleOrDefault();

        public void CreateType(TypeObj typeObj) => Create(typeObj);
    }
}

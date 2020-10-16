using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Contracts
{
    public interface ITypeRepository : IRepositoryBase<TypeObj>
    {
        TypeObj GetTypeObj(int type);
        void CreateType(TypeObj typeObj);
    }
}

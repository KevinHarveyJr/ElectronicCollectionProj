using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Contracts
{
    public interface IGenreRepository : IRepositoryBase<GenreObj>
    {
        GenreObj GetGenreObj(int genre);
        void CreateGenre(GenreObj genreObj);
    }
}

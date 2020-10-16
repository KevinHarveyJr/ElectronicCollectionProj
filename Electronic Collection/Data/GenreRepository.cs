using Electronic_Collection.Contracts;
using Electronic_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_Collection.Data
{
    public class GenreRepository : RepositoryBase<GenreObj>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public GenreObj GetGenreObj(int genreId) => FindByCondition(i => i.GenreId.Equals(genreId)).SingleOrDefault();

        public void CreateGenre(GenreObj genreObj) => Create(genreObj);
    }
}

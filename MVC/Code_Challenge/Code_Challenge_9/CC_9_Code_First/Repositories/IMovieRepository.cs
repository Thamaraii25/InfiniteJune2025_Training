using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_9_Code_First.Repositories
{
    public interface IMovieRepository<T> where T:class
    {
        IEnumerable<T> GetAllMovies();
        T GetById(object id);
        void Create(T obj);
        void Edit(T obj);
        void Delete(object id);
        void save();
    }
}


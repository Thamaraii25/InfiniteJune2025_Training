using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC_9_Code_First.Models;
using System.Data.Entity;

namespace CC_9_Code_First.Repositories
{
    public class MovieRepository<T> : IMovieRepository<T> where T:class
    {
        MoviesContext db;
        DbSet<T> dbset;

        public MovieRepository()
        {
            db = new MoviesContext();
            dbset = db.Set<T>();
        }

        public void Create(T obj)
        {
            dbset.Add(obj);
        }

        public void Delete(object id)
        {
            T itemToDelete = dbset.Find(id);
            dbset.Remove(itemToDelete);
        }

        public void Edit(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<T> GetAllMovies()
        {
            return dbset.ToList();
        }

        public T GetById(object id)
        {
            return dbset.Find(id);
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
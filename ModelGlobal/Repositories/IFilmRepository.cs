using System;
using System.Collections.Generic;
using System.Text;

namespace ModelGlobal.Repositories
{
    public interface IFilmRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetOne(int id);
        void Insert(TEntity t);
        void Update(TEntity t);
        void Delete(int id);
    }
}

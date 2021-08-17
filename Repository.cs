using System;
using System.Collections.Generic;
using System.Linq;


namespace Interview
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {

        private IList<T> _entities;

        public Repository(IList<T> entities)
        {
            _entities = entities;
        }

        public Repository()
        {
            _entities = new List<T>();
        }

        public IEnumerable<T> All()
        {
            return _entities;
        }

        public void Delete(IComparable id)
        {
            var entityToDelete = _entities.FirstOrDefault(x => Equals(x.Id, id));

            _entities.Remove(entityToDelete);
        }

        public T FindById(IComparable id)
        {
            var entity = _entities.FirstOrDefault(x => Equals(x.Id, id));

            return entity;
        }

        public void Save(T item)
        {
            _entities.Add(item);
        }
    }
}


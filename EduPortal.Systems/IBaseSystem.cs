using EduPortal.Core.Entity;
using EduPortal.DAO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Systems
{
    public class IBaseSystem<T> where T:Base
    {
        public T Save(T obj)
        {
            BaseRepository<T> repository = new BaseRepository<T>();
            repository.Add(obj);
            return obj;
        }
        
        public T Save(T obj, string key)
        {
            BaseRepository<T> repository = new BaseRepository<T>(key);
            repository.Add(obj);
            return obj;
        }
        public T Update(T obj)
        {
            BaseRepository<T> repository = new BaseRepository<T>();
            repository.Update(obj, obj.ID);
            return obj;
        }
        public T Update(T obj, string key)
        {
            BaseRepository<T> repository = new BaseRepository<T>(key);
            repository.Update(obj,obj.ID);
            return obj;
        }
        public IEnumerable<T> RetrieveAll()
        {
            BaseRepository<T> repository = new BaseRepository<T>();
            var obj = repository.GetAll();
            return obj;
        }
        public IEnumerable<T> RetrieveAll(string key)
        {
            BaseRepository<T> repository = new BaseRepository<T>(key);
            var obj=repository.GetAll();
            return obj;
        }
        public T RetrieveBy(long id)
        {
            BaseRepository<T> repository = new BaseRepository<T>();
            var obj = repository.Get(id);
            return obj;
        }
        public T RetrieveBy(long id, string key)
        {
            BaseRepository<T> repository = new BaseRepository<T>(key);
            var obj = repository.Get(id);
            return obj;
        }
    }
}

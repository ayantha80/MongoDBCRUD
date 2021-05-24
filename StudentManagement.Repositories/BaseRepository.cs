using MongoDB.Bson;
using MongoDB.Driver;
using StudentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagement.Repositories
{
    /// <summary>
    /// Base repository for CRUD operations.
    /// </summary>
    public class BaseRepository : IBaseRepository
    {   
       
        private readonly IMongoDatabase _db = null;

        public BaseRepository(IMongoClient dbClient)
        {                       
            _db = dbClient.GetDatabase("studentInformation"); 
        }


        internal IMongoCollection<T> GetCollection<T>(string name)
        {
           return _db.GetCollection<T>(name);
        }

       
        public void Delete<T>(string name, FilterDefinition<T> deleteFilter) where T : class, new()
        {            
            var collection = _db.GetCollection<T>(name);

            collection.DeleteOne(deleteFilter);
        }

      
        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression,string name) where T : class, new()
        {
            return All<T>(name).Where(expression).SingleOrDefault();
        }


        public IQueryable<T> All<T>(string name) where T : class, new()
        {
            return _db.GetCollection<T>(name).AsQueryable();
        }

       
        public void Add<T>(T item,string name) where T : class, new()
        {
            _db.GetCollection<T>(name).InsertOne(item);
        }


        public void Update<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression, T item, string name) where T : class, new()
        {
          var x = _db.GetCollection<T>(name).ReplaceOne<T>(expression, item);
                     
        }


        public void AddMany<T>(List<T> item, string name) where T : class, new()
        {
            _db.GetCollection<T>(name).InsertMany(item);
        }

        
    }
}

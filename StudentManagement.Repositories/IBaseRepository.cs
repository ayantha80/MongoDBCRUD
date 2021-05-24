using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StudentManagement.Repositories
{
    /// <summary>
    /// Base repository for CRUD operations.
    /// </summary>
    public interface IBaseRepository 
    {        
        void Delete<T>(string name, FilterDefinition<T> deleteFilter) where T : class, new();       
        T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression, string name) where T : class, new();
        IQueryable<T> All<T>(string name) where T : class, new();
        void Add<T>(T item, string name) where T : class, new();
        void AddMany<T>(List<T> item, string name) where T : class, new();
        void Update<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression, T item, string name) where T : class, new();
        
    }
}

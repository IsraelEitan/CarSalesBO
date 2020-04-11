using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.DomainService
{
    public interface IRepository<TEntity> where TEntity : class
    {  
        //Read Data
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        //Add Data
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Update Data
        void Update(TEntity entity);

        //Delete Data
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatProject.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int id);
        int Add(TEntity entity);
        void Update(int id,TEntity dbEntity);
        void Delete(int entityId);

        void AssignCustomerToBoatNumber(TEntity dbEntity);
    }
}

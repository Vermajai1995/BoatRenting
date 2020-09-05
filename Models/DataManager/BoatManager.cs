using BoatProject.Data;
using BoatProject.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatProject.Models.DataManager
{
    public class BoatManager : IDataRepository<Boat>
    {
        readonly BoatProjectContext _boatContext;
        public BoatManager(BoatProjectContext context)
        {
            _boatContext = context;
        }
        public IQueryable<Boat> GetAll()
        {
            return _boatContext.Boat;
        }
        public Boat Get(int id)
        {
            return _boatContext.Boat
            .FirstOrDefault(e => e.Id == id);
        }
        public int Add(Boat entity)
        {
            entity.CreatedDate = DateTime.Now;
            _boatContext.Boat.Add(entity);
            _boatContext.SaveChanges();
            return entity.Id;
        }

        public void Update(int id,Boat entity)
        {
            Boat oldboat=Get(id);
            oldboat.BoatName = entity.BoatName;
            oldboat.HourlyRate = entity.HourlyRate;
            oldboat.isCurrentlyRented = entity.isCurrentlyRented;
            _boatContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Boat oldboat = Get(id);
            _boatContext.Boat.Remove(oldboat);
            _boatContext.SaveChanges();
        }

        public void AssignCustomerToBoatNumber(Boat entity)
        {
            Boat oldboat = Get(entity.Id);
            oldboat.isCurrentlyRented = true;
            oldboat.RentedByCustomerName = entity.RentedByCustomerName;
            _boatContext.SaveChanges();
        }

        public void RemoveCustomerFromBoatNumber(Boat entity)
        {
            Boat oldboat = Get(entity.Id);
            oldboat.isCurrentlyRented = false;
            oldboat.RentedByCustomerName = "";
            _boatContext.SaveChanges();
        }

    }
}

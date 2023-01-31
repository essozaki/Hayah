using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface ICitiesRep
    {
        IEnumerable<Cities> Get();
        Cities GetById(int id);
        void Creat(Cities obj);
        void Edite(Cities obj);
        void Delete(Cities obj);
    }
    public class CitiesRep : ICitiesRep
    {
        private readonly Pharmacy_DbContext db;
        public CitiesRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Cities> Get()
        {
            var All = db.Cities.Select(a => a);
            return All;
        }
        public Cities GetById(int id)
        {
            var data = db.Cities.Where(x => x.Id == id).Include("Areas").FirstOrDefault();
            return data;
        }

        public void Creat(Cities obj)
        {
            db.Cities.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Cities obj)
        {
            var olddata = db.Cities.Find(obj.Id);
            db.Cities.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Cities obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

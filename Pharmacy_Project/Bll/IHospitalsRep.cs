using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IHospitalsRep
    {
        
        IEnumerable<Hospitals> Get();
        Hospitals GetById(int id);
        void Creat(Hospitals obj);
        void Edite(Hospitals obj);
        void Delete(Hospitals obj);
    }
    public class HospitalsRep : IHospitalsRep
    {
        private readonly Pharmacy_DbContext db;
        public HospitalsRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Hospitals> Get()
        {
            var All = db.Hospitals.Select(a => a).Include("Cities").Include("Areas");
            return All;
        }
        public Hospitals GetById(int id)
        {
            var data = db.Hospitals.Where(x => x.Id == id).Include("Cities").Include("Areas").FirstOrDefault();
            return data;
        }

        public void Creat(Hospitals obj)
        {
            db.Hospitals.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Hospitals obj)
        {
            var olddata = db.Hospitals.Find(obj.Id);
            db.Hospitals.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Hospitals obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

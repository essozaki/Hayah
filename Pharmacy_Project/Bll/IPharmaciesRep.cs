using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IPharmaciesRep
    {
        
        IEnumerable<Pharmacies> Get();
        Pharmacies GetById(int id);
        void Creat(Pharmacies obj);
        void Edite(Pharmacies obj);
        void Delete(Pharmacies obj);
    }
    public class PharmaciesRep : IPharmaciesRep
    {
        private readonly Pharmacy_DbContext db;
        public PharmaciesRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Pharmacies> Get()
        {
            var All = db.Pharmacies.Select(a => a).Include("Cities").Include("Areas");
            return All;
        }
        public Pharmacies GetById(int id)
        {
            var data = db.Pharmacies.Where(x => x.Id == id).Include("Cities").Include("Areas").FirstOrDefault();
            return data;
        }

        public void Creat(Pharmacies obj)
        {
            db.Pharmacies.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Pharmacies obj)
        {
            var olddata = db.Pharmacies.Find(obj.Id);
            db.Pharmacies.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Pharmacies obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

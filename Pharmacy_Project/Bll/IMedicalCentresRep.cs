using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IMedicalCentresRep
    {
        
        IEnumerable<MedicalCentres> Get();
        MedicalCentres GetById(int id);
        void Creat(MedicalCentres obj);
        void Edite(MedicalCentres obj);
        void Delete(MedicalCentres obj);
    }
    public class MedicalCentresRep : IMedicalCentresRep
    {
        private readonly Pharmacy_DbContext db;
        public MedicalCentresRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<MedicalCentres> Get()
        {
            var All = db.MedicalCentres.Select(a => a).Include("Cities").Include("Areas");
            return All;
        }
        public MedicalCentres GetById(int id)
        {
            var data = db.MedicalCentres.Where(x => x.Id == id).Include("Cities").Include("Areas").FirstOrDefault();
            return data;
        }

        public void Creat(MedicalCentres obj)
        {
            db.MedicalCentres.Add(obj);
            db.SaveChanges();

        }

        public void Delete(MedicalCentres obj)
        {
            var olddata = db.MedicalCentres.Find(obj.Id);
            db.MedicalCentres.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(MedicalCentres obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

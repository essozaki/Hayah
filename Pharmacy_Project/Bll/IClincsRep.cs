using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IClincsRep
    {
        
        IEnumerable<Clincs> Get();
        Clincs GetById(int id);
        void Creat(Clincs obj);
        void Edite(Clincs obj);
        void Delete(Clincs obj);
    }
    public class ClincsRep : IClincsRep
    {
        private readonly Pharmacy_DbContext db;
        public ClincsRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Clincs> Get()
        {
            var All = db.Clincs.Select(a => a).Include("Cities").Include("Areas");
            return All;
        }
        public Clincs GetById(int id)
        {
            var data = db.Clincs.Where(x => x.Id == id).Include("Cities").Include("Areas").FirstOrDefault();
            return data;
        }

        public void Creat(Clincs obj)
        {
            db.Clincs.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Clincs obj)
        {
            var olddata = db.Clincs.Find(obj.Id);
            db.Clincs.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Clincs obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

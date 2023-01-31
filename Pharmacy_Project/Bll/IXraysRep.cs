using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IXraysRep
    {
        
        IEnumerable<Xrays> Get();
        Xrays GetById(int id);
        void Creat(Xrays obj);
        void Edite(Xrays obj);
        void Delete(Xrays obj);
    }
    public class XraysRep : IXraysRep
    {
        private readonly Pharmacy_DbContext db;
        public XraysRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Xrays> Get()
        {
            var All = db.Xrays.Select(a => a).Include("Cities").Include("Areas");
            return All;
        }
        public Xrays GetById(int id)
        {
            var data = db.Xrays.Where(x => x.Id == id).Include("Cities").Include("Areas").FirstOrDefault();
            return data;
        }

        public void Creat(Xrays obj)
        {
            db.Xrays.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Xrays obj)
        {
            var olddata = db.Xrays.Find(obj.Id);
            db.Xrays.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Xrays obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}


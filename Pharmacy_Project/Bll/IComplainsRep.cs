using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data;
using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Bll
{
    public interface IComplainsRep
    {
        
        IEnumerable<Complains> Get();
        Complains GetById(int id);
        void Creat(Complains obj);
        void Edite(Complains obj);
        void Delete(Complains obj);
    }
    public class ComplainsRep : IComplainsRep
    {
        private readonly Pharmacy_DbContext db;
        public ComplainsRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Complains> Get()
        {
            var All = db.Complains.Select(a => a);
            return All;
        }
        public Complains GetById(int id)
        {
            var data = db.Complains.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Complains obj)
        {
            db.Complains.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Complains obj)
        {
            var olddata = db.Complains.Find(obj.Id);
            db.Complains.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Complains obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IAreasRep
    {
        
        IEnumerable<Areas> Get();
        Areas GetById(int id);
        void Creat(Areas obj);
        void Edite(Areas obj);
        void Delete(Areas obj);
    }
    public class AreasRep : IAreasRep
    {
        private readonly Pharmacy_DbContext db;
        public AreasRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Areas> Get()
        {
            var All = db.Areas.Select(a => a).Include("Cities");
            return All;
        }
        public Areas GetById(int id)
        {
            var data = db.Areas.Where(x => x.Id == id).Include("Cities").FirstOrDefault();
            return data;
        }


        public void Creat(Areas obj)
        {
            db.Areas.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Areas obj)
        {
            var olddata = db.Areas.Find(obj.Id);
            db.Areas.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Areas obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

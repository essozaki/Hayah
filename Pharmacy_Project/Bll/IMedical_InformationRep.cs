using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IMedical_InformationRep
    {
        
        IEnumerable<Medical_Information> Get();
        Medical_Information GetById(int id);
        void Creat(Medical_Information obj);
        void Edite(Medical_Information obj);
        void Delete(Medical_Information obj);
    }
    public class Medical_InformationRep : IMedical_InformationRep
    {
        private readonly Pharmacy_DbContext db;
        public Medical_InformationRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Medical_Information> Get()
        {
            var All = db.Medical_Information.Select(a => a);
            return All;
        }
        public Medical_Information GetById(int id)
        {
            var data = db.Medical_Information.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Medical_Information obj)
        {
            db.Medical_Information.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Medical_Information obj)
        {
            var olddata = db.Medical_Information.Find(obj.Id);
            db.Medical_Information.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Medical_Information obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

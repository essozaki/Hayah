using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IContactUsRep
    {
        
        IEnumerable<ContactUs> Get();
        ContactUs GetById(int id);
        void Creat(ContactUs obj);
        void Edite(ContactUs obj);
        void Delete(ContactUs obj);
    }
    public class ContactUsRep : IContactUsRep
    {
        private readonly Pharmacy_DbContext db;
        public ContactUsRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<ContactUs> Get()
        {
            var All = db.ContactUs.Select(a => a);
            return All;
        }
        public ContactUs GetById(int id)
        {
            var data = db.ContactUs.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(ContactUs obj)
        {
            db.ContactUs.Add(obj);
            db.SaveChanges();

        }

        public void Delete(ContactUs obj)
        {
            var olddata = db.ContactUs.Find(obj.Id);
            db.ContactUs.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(ContactUs obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

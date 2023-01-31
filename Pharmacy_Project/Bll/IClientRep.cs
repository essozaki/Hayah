using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data;
using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Bll
{
    public interface IClientRep
    {
        IEnumerable<Client> Get();
        Client GetById(int id);
        void Creat(Client obj);
        void Edite(Client obj);
        void Delete(Client obj);
    }
    public class ClientRep : IClientRep
    {
        private readonly Pharmacy_DbContext db;
        public ClientRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Client> Get()
        {
            var All = db.Client.Select(a => a);
            return All;
        }
        public Client GetById(int id)
        {
            var data = db.Client.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(Client obj)
        {
            db.Client.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Client obj)
        {
            var olddata = db.Client.Find(obj.Id);
            db.Client.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(Client obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

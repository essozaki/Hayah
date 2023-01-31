using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data;
using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Bll
{
    public interface IAnalysisLapsRep
    {
        IEnumerable<AnalysisLaps> Get(); 
        AnalysisLaps GetById(int id);
        void Creat(AnalysisLaps obj);
        void Edite(AnalysisLaps obj);
        void Delete(AnalysisLaps obj);
    }
    public class AnalysisLapsRep : IAnalysisLapsRep
    {
        private readonly Pharmacy_DbContext db;
        public AnalysisLapsRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<AnalysisLaps> Get()
        {
            var All = db.AnalysisLaps.Select(a => a).Include("Cities").Include("Areas");
            return All;
        }
        public AnalysisLaps GetById(int id)
        {
            var data = db.AnalysisLaps.Where(x => x.Id == id).Include("Cities").Include("Areas").FirstOrDefault();
            return data;
        }

        public void Creat(AnalysisLaps obj)
        {
            db.AnalysisLaps.Add(obj);
            db.SaveChanges();

        }

        public void Delete(AnalysisLaps obj)
        {
            var olddata = db.AnalysisLaps.Find(obj.Id);
            db.AnalysisLaps.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(AnalysisLaps obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Data;

namespace Pharmacy_Project.Bll
{
    public interface IHomeSliderRep
    {
        
        IEnumerable<HomeSlider> Get();
        HomeSlider GetById(int id);
        void Creat(HomeSlider obj);
        void Edite(HomeSlider obj);
        void Delete(HomeSlider obj);
    }
    public class HomeSliderRep : IHomeSliderRep
    {
        private readonly Pharmacy_DbContext db;
        public HomeSliderRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<HomeSlider> Get()
        {
            var All = db.HomeSlider.Select(a => a);
            return All;
        }
        public HomeSlider GetById(int id)
        {
            var data = db.HomeSlider.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Creat(HomeSlider obj)
        {
            db.HomeSlider.Add(obj);
            db.SaveChanges();

        }

        public void Delete(HomeSlider obj)
        {
            var olddata = db.HomeSlider.Find(obj.Id);
            db.HomeSlider.Remove(olddata);
            db.SaveChanges();
        }

        public void Edite(HomeSlider obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

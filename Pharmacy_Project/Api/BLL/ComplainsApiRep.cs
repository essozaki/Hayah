using Pharmacy_Project.Api.Models;
using Pharmacy_Project.Data;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Bll
{
    public class ComplainsApiRep : IComplainsApiRep
    {
        private readonly Pharmacy_DbContext db;
        public ComplainsApiRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        //public IEnumerable<ComplainsVM> GetAll()
        //{

        //    var data = db.Complains.Select(a => new ComplainsVM
        //    {

        //        Id = a.Id,
        //        Question = a.Question,
        //        Answer = a.Answer,

        //        //CarImgUrl = "/Uploads/Complains/"+a.CarImgUrl,

        //    });

        //    return data;

        //}
        public Complains Creat(ComplainsVM obj)
        {
            Complains ser = new Complains();
            ser.Id = obj.Id;
            ser.Deails = obj.Deails;

            db.Complains.Add(ser);
            db.SaveChanges();

            var data = db.Complains.OrderBy(a => a.Id).LastOrDefault();
            return data;
        }


    }
    public interface IComplainsApiRep
    {
        public Complains Creat(ComplainsVM obj);
        //IEnumerable<ComplainsVM> GetAll();


    }
}
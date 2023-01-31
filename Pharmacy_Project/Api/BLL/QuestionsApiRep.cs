using Pharmacy_Project.Data;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Bll
{
    public class QuestionsApiRep : IQuestionsApiRep
    {
        private readonly Pharmacy_DbContext db;
        public QuestionsApiRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<QuestionsVM> GetAll()
        {

            var data = db.Questions.Select(a => new QuestionsVM
            {

                Id = a.Id,
                Question = a.Question,
                Answer = a.Answer,

                //CarImgUrl = "/Uploads/Questions/"+a.CarImgUrl,

            });

            return data;

        }
        
       
    }
    public interface IQuestionsApiRep
    {
        IEnumerable<QuestionsVM> GetAll();


    }
}
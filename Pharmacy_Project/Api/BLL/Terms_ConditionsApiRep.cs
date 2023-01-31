using Pharmacy_Project.Data;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Bll
{
    public class Terms_ConditionsApiRep : ITerms_ConditionsApiRep
    {
        private readonly Pharmacy_DbContext db;
        public Terms_ConditionsApiRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Terms_ConditionsVM> GetAll()
        {

            var data = db.Terms_Conditions.Select(a => new Terms_ConditionsVM
            {

                Id = a.Id,
                Details = a.Details,

                //CarImgUrl = "/Uploads/Terms_Conditions/"+a.CarImgUrl,

            });

            return data;

        }

    }
    public interface ITerms_ConditionsApiRep
    {
        IEnumerable<Terms_ConditionsVM> GetAll();


    }

}
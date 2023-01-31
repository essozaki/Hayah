using Pharmacy_Project.Data;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Bll
{
    public class ClincsApiRep : IClincsApiRep
    {
        private readonly Pharmacy_DbContext db;
        public ClincsApiRep(Pharmacy_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<ClincsVM> GetAll()
        {

            var data = db.Clincs.Select(a => new ClincsVM
            {

                Id = a.Id,
                Clin_Name = a.Clin_Name,
                Clin_Descriprion = a.Clin_Descriprion,
                Clin_Phone = a.Clin_Phone,
                Clin_LInk = a.Clin_LInk,
                Clin_FacebookLInk = a.Clin_FacebookLInk,
                Clin_YoutubeLInk = a.Clin_YoutubeLInk,
                Clin_InstaLInk = a.Clin_InstaLInk,
                Clin_WhatsappLInk = a.Clin_WhatsappLInk,
                Clin_LocationLInk = a.Clin_LocationLInk,
               
                Area_Id = a.Area_Id,
                Areas = a.Areas,
                Clin_NameImgUrl = "/Uploads/Clincs/" + a.Clin_NameImgUrl,

            });

            return data;

        }
        
    }
    public interface IClincsApiRep
    {
        IEnumerable<ClincsVM> GetAll();


    }

}
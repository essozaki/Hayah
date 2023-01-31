using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class MedicalCentres
    {
        public int Id { get; set; }
        public string Centers_Name { get; set; }
        public string Centers_NameImgUrl { get; set; }
        public string Centers_Descriprion { get; set; }
        public string Centers_Phone { get; set; }
        public string? Centers_rate { get; set; }
        public string? Centers_LInk { get; set; }
        public string? Centers_FacebookLInk { get; set; }
        public string? Centers_YoutubeLInk { get; set; }
        public string? Centers_InstaLInk { get; set; }
        public string? Centers_WhatsappLInk { get; set; }
        public string? Centers_LocationLInk { get; set; }
        //relations
        //City relation

        //public int City_Id { get; set; }
        //[ForeignKey("City_Id")]
        //public Cities Cities { get; set; }

        //Area relation
        public int Area_Id { get; set; }
        [ForeignKey("Area_Id")]
        public Areas Areas { get; set; }
    }
}

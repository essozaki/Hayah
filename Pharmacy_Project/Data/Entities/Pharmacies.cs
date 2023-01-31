using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class Pharmacies
    {
        public int Id { get; set; }
        public string Pharm_Name { get; set; }
        public string Pharm_NameImgUrl { get; set; }
        public string Pharm_Descriprion { get; set; }
        public string Pharm_Phone { get; set; }
        public string? Pharm_rate { get; set; }
        public string? Pharm_LInk { get; set; }
        public string? Pharm_FacebookLInk { get; set; }
        public string? Pharm_YoutubeLInk { get; set; }
        public string? Pharm_InstaLInk { get; set; }
        public string? Pharm_WhatsappLInk { get; set; }
        public string? Pharm_LocationLInk { get; set; }
        //relations
        //City relation

        //public int City_Id { get; set; }
        //[ForeignKey("City_Id")]
        //public Cities Cities { get; set; }

        //Area relation
        public int Area_Id { get; set; }
        [ForeignKey("Area_Id")]
        public Areas Areas { get; set; }

        public List<PharmaciesAppointments> PharmaciesAppointments { get; set; }
    }
}

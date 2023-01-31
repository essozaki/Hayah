using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class Hospitals
    {
        public int Id { get; set; }
        public string Hospt_Name { get; set; }
        public string Hospt_NameImgUrl { get; set; }
        public string Hospt_Descriprion { get; set; }
        public string Hospt_Phone { get; set; }
        public string? Hospt_rate { get; set; }
        public string? Hospt_LInk { get; set; }
        public string? Hospt_FacebookLInk { get; set; }
        public string? Hospt_YoutubeLInk { get; set; }
        public string? Hospt_InstaLInk { get; set; }
        public string? Hospt_WhatsappLInk { get; set; }
        public string? Hospt_LocationLInk { get; set; }
        //relations
        //City relation

        //public int City_Id { get; set; }
        //[ForeignKey("City_Id")]
        //public Cities Cities { get; set; }

        //Area relation
        public int Area_Id { get; set; }
        [ForeignKey("Area_Id")]
        public Areas Areas { get; set; }
        public List<HospitalsAppointments> HospitalsAppointments { get; set; }

    }
}

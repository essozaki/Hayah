using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class Xrays
    {

        public int Id { get; set; }
        public string Xray_Name { get; set; }
        public string Xray_NameImgUrl { get; set; }
        public string Xray_Descriprion { get; set; }
        public string Xray_Phone { get; set; }
        public string? Xray_rate { get; set; }
        public string? Xray_LInk { get; set; }
        public string? Xray_FacebookLInk { get; set; }
        public string? Xray_YoutubeLInk { get; set; }
        public string? Xray_InstaLInk { get; set; }
        public string? Xray_WhatsappLInk { get; set; }
        public string? Xray_LocationLInk { get; set; }

        //relations
        //City relation

        //public int City_Id { get; set; }
        //[ForeignKey("City_Id")]
        //public Cities Cities { get; set; }

        //Area relation
        public int Area_Id { get; set; }
        [ForeignKey("Area_Id")]
        public Areas Areas { get; set; }

        public List<XRaysAppointments> XRaysAppointments { get; set; }

    }
}

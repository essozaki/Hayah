using Pharmacy_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class Clincs
    {
        public int Id { get; set; }
        public string Clin_Name { get; set; }
        public string Clin_NameImgUrl { get; set; }
        public string Clin_Descriprion { get; set; }
        public string Clin_Phone { get; set; }
        public string? Clin_rate { get; set; }
        public string? Clin_LInk { get; set; }
        public string? Clin_FacebookLInk { get; set; }
        public string? Clin_YoutubeLInk { get; set; }
        public string? Clin_InstaLInk { get; set; }
        public string? Clin_WhatsappLInk { get; set; }
        public string? Clin_LocationLInk { get; set; }
       //relations
       ////City relation

       // public int City_Id { get; set; }
       // [ForeignKey("City_Id")]
       // public Cities Cities { get; set; }

        //Area relation
        public int Area_Id { get; set; }
        [ForeignKey("Area_Id")]
        public Areas Areas { get; set; }

        //Apointments
        public  List<ClincsAppointments> ClincsAppointments { get; set; }
    }
}

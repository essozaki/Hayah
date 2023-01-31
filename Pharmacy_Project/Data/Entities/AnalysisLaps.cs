using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class AnalysisLaps
    {
        public int Id { get; set; }
        public string Lap_Name { get; set; }
        public string Lap_ImgUrl { get; set; }
        public string Lap_Descriprion { get; set; }
        public string Lap_Phone { get; set; }
        public string? Lap_rate { get; set; }
        public string? Lap_LInk { get; set; }
        public string? Lap_FacebookLInk { get; set; }
        public string? Lap_YoutubeLInk { get; set; }
        public string? Lap_InstaLInk { get; set; }
        public string? Lap_WhatsappLInk { get; set; }
        public string? Lap_LocationLInk { get; set; }
        //relations
        //City relation

        //public int City_Id { get; set; }
        //[ForeignKey("City_Id")]
        //public Cities Cities { get; set; }

        //Area relation
        public int Area_Id { get; set; }
        [ForeignKey("Area_Id")]
        public Areas Areas { get; set; }

        //Apointments
        public List<AnalysisLapsAppointments> AnalysisLapsAppointments { get; set; }



    }
}

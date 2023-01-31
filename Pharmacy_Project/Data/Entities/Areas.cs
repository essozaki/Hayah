using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class Areas
    {
        public int Id { get; set; }
        public string Area_Name { get; set; }

        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public Cities Cities { get; set; }


        public List<Clincs> Clincs { get; set; }
        public List<Hospitals> Hospitals { get; set; }
        public List<AnalysisLaps> AnalysisLaps { get; set; }
        public List<Xrays> Xrays { get; set; }
        public List<MedicalCentres> MedicalCentres { get; set; }
        public List<Pharmacies> Pharmacies { get; set; }
    }
}

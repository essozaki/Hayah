using Pharmacy_Project.Bll;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        //Weifes

        public string? FirstWife { get; set; }
        public string? SecendWife { get; set; }
        public string? ThirdWife { get; set; }
        public string? FourthWife { get; set; }

        //End wifes

        public string? GrandFatherName { get; set; }
        public string? GrandMotherName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Department { get; set; }
        public string DealOfficer { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string ClientReport { get; set; }
        public string WorkPlan { get; set; }
        public string Notes { get; set; }

        public string Medicense { get; set; }

       


    }
}

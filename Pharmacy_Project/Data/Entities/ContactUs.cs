using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Project.Data.Entities
{
    public class ContactUs
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Location_Link { get; set; }
        public string Website_Link { get; set; }
        public string Facebook_Link { get; set; }
        public string Youtube_Link { get; set; }
        public string Insta_Link { get; set; }
        public string Whatsapp_Link { get; set; }
       
    }
}

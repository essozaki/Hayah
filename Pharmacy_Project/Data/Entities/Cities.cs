namespace Pharmacy_Project.Data.Entities

{
    public class Cities
    {

     
        public int Id { get; set; }
        public string Cite_Name  { get; set; }

        public List<Areas> Areas { get; set; }


    }
}

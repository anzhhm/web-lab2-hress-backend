namespace AirportWebLab.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Aircraft
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

}

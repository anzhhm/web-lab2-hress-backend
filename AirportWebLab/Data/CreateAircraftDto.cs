namespace AirportWebLab.Data
{
    public class CreateAircraftDto
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int ManufacturerId { get; set; }
        public int CompanyId { get; set; }
    }

}

namespace Backend.AppLocation.Entities
{
    public class Location
    {
        public Int64 Id { get; set; }
        public string FsqId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

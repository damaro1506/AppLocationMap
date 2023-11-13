namespace Backend.AppLocation.Entities
{
    public class User
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public List<Location>? Locations { get; set; }
    }
}

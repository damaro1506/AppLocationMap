namespace AppLocationWeb.Models
{
    public class UserModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public List<LocationModel>? Locations { get; set; }

    }
}

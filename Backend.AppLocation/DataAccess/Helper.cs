namespace Backend.AppLocation.DataAccess
{
    public class Helper : IHelper
    {
        private readonly IConfiguration _configuration;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            var connectionString = _configuration.GetConnectionString("PruebasDiego");
            return connectionString;
        }
    }
}

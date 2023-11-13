using Backend.AppLocation.Entities;
using Backend.AppLocation.Repositories;

namespace Backend.AppLocation.Services
{
    public class LocationService
    {
        private LocationRepository _repository;
        private LocationRepository repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new LocationRepository();
                }
                return _repository;
            }
            set
            {
                _repository = value;
            }
        }

        public List<Location> GetLocations()
        {
            return _repository.GetAlLocations();
        }
    }
}

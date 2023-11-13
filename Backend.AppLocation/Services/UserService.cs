//using Backend.AppLocation.Repositories;
using Backend.AppLocation.Entities;
using Backend.AppLocation.Repositories;
using Microsoft.Extensions.Configuration;

namespace Backend.AppLocation.Services
{
    public class UserService 
    {
        

        private UserRepository _myUserRepository;
        private UserRepository myUserRepository
        {
            get
            {
                if (_myUserRepository == null)
                {
                    _myUserRepository = new UserRepository();
                }
                return _myUserRepository;
            }
            set
            {
                _myUserRepository = value;
            }
        }

        public User GetUserByUserNameOrEmail(string value,String connectionString)
        {
            return myUserRepository.GetUserByUserOrEmail(value,connectionString);
        }
    }
}

using AppLocationWeb.Models;
using AutoMapper;
using Backend.AppLocation.DataAccess;
using Backend.AppLocation.Entities;
using Backend.AppLocation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLocationWeb.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;
        private readonly IHelper _helper;
        private UserService _myUserService;
        private UserService myUserService
        {
            get
            {
                if (_myUserService == null)
                    _myUserService = new UserService();
                return _myUserService;
            }
            set
            {
                _myUserService = value;
            }
        }

        public LocationController(ILogger<LocationController> logger, IHelper helper)
        {
            _logger = logger;
            _helper = helper;
        }

        public ActionResult Index()
        {
            var param = "diego.amaror@gmail.com";
            var cs = _helper.Pruebas();
            var user = myUserService.GetUserByUserNameOrEmail(param, cs);
            Console.WriteLine(user);
            return View();
        }

        public ActionResult Location()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            var mapper = new Mapper(config);
            var param = "diego.amaror@gmail.com";
            var cs = _helper.Pruebas();
            var user = myUserService.GetUserByUserNameOrEmail(param, cs);
            UserModel usermodel = mapper.Map<User, UserModel>(user);
            Console.WriteLine(usermodel);
            return View();
        }

        public ActionResult Favorites()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
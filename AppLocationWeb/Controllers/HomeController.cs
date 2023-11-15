using AppLocationWeb.Models;
using Backend.AppLocation.DataAccess;
using Backend.AppLocation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLocationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
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

        public HomeController(ILogger<HomeController> logger,IHelper helper)
        {
            _logger = logger;
            _helper = helper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Location()
        {
            var param = "diego.amaror@gmail.com";
            var cs = _helper.GetConnectionString();
            var user = myUserService.GetUserByUserNameOrEmail(param,cs);
            Console.WriteLine(user);
            return View();
        }

        public ActionResult Privacy()
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
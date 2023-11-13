using AppLocationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Backend.AppLocation.Services;


namespace AppLocationWeb.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;
        private readonly UserService _myUserService;

        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            var param = "diego.amaror@gmail.com";
            var getUsers = _myUserService.GetUserByUserNameOrEmail(param,"");
            Console.WriteLine();
            return View();
        }

    }
}
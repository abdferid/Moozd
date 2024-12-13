using System.Diagnostics;
using Business.Abstract;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moozd.Models;

namespace Moozd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMottoService _mottoService;
        private readonly IAboutService _aboutService;
        private readonly IServiceHeaderService _serviceHeaderService;
        private readonly IServiceService _serviceService;

        public HomeController(ILogger<HomeController> logger, IMottoService mottoService, IAboutService aboutService, IServiceHeaderService serviceHeaderService, IServiceService serviceService)
        {
            _logger = logger;
            _mottoService = mottoService;
            _aboutService = aboutService;
            _serviceHeaderService = serviceHeaderService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var motto = _mottoService.GetAll().Data[0];
            var about = _aboutService.GetAll().Data[0];
            var serviceHeader = _serviceHeaderService.GetAll().Data[0];
            var services = _serviceService.GetAll().Data;
            HomeViewModel homeViewModel = new()
            {
                About = about,
                Motto = motto,
                ServiceHeader = serviceHeader,
                Services = services
            };
            return View(homeViewModel);
        }
    }
}

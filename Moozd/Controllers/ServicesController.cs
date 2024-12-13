using Business.Abstract;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Moozd.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicesTextService _servicesTextService;
        private readonly IServiceService _serviceService;

        public ServicesController(ILogger<HomeController> logger, IServicesTextService servicesTextService, IServiceService serviceService)
        {
            _logger = logger;
            _servicesTextService = servicesTextService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var servicesText = _servicesTextService.GetAll().Data[0];
            var services = _serviceService.GetAll().Data;
            ServicesViewModel servicesViewModel = new()
            {
                ServicesText = servicesText,
                Services = services
            };
            return View(servicesViewModel);
        }

        public IActionResult SingleService(int id)
        {
            var service = _serviceService.GetByID(id).Data;
            var top3Services = _serviceService.GetAll().Data.Take(3).ToList();
            SingleServiceViewModel singleServiceViewModel = new()
            {
                Service = service,
                Top3Services = top3Services
            };
            return View(singleServiceViewModel);
        }
    }
}

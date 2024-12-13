using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete.ViewModel;

namespace Moozd.Controllers
{
	public class PortfolioController : Controller
	{
		private readonly IProjectService _projectService;
		public PortfolioController(IProjectService projectService)
		{
			_projectService = projectService;
		}
		public IActionResult Index()
		{
			var datas = _projectService.GetAll().Data;
			return View(datas);
		}

		public IActionResult SingleProject(int id)
		{
            var project = _projectService.GetByID(id).Data;
            return View(project);
        }
	}
}

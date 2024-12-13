using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Moozd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServicesTextController : Controller
    {
        private readonly IServicesTextService _manager;

        public ServicesTextController(IServicesTextService manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data[0];
            return View(datas);
        }

        [HttpPost]
        public IActionResult Index(ServicesText entity)
        {
            var result = _manager.Update(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.MessageList)
                {
                    ModelState.Remove(result.Data[result.MessageList.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.MessageList.IndexOf(error)], error);
                }
                return View(entity);
            }
        }
    }
}

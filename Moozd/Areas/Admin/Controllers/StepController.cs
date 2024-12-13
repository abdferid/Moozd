using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Moozd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StepController : Controller
    {
        private readonly IStepService _manager;
        private readonly IServiceService _serviceManager;

        public StepController(IStepService manager, IServiceService serviceManager)
        {
            _manager = manager;
            _serviceManager = serviceManager;
        }

        public IActionResult Index(int id)
        {
            ViewData["ServiceID"] = id;
            var datas = _manager.GetAll().Data.Where(x => x.ServiceID == id && x.Deleted == 0);
            return View(datas);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewData["ServiceID"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Step entity)
        {
            ViewData["ServiceID"] = entity.ServiceID;
            var result = _manager.Add(entity);
            if (result.Success)
            {
                return RedirectToAction("Index", new { id = entity.ServiceID});

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

        public IActionResult Delete(int serviceID, int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index", new { id = serviceID});
        }

        public IActionResult Edit(int id)
        {
            var step = _manager.GetByID(id).Data;
            return View(step);
        }

        [HttpPost]
        public IActionResult Edit(Step entity)
        {
            ViewData["ServiceID"] = entity.ServiceID;
            var result = _manager.Update(entity);
            if (result.Success)
            {
                return RedirectToAction("Index", new { id = entity.ServiceID });
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

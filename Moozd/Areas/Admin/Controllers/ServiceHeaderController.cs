using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Moozd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServiceHeaderController : Controller
    {
        private readonly IServiceHeaderService _manager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceHeaderController(IServiceHeaderService manager, IWebHostEnvironment webHostEnvironment)
        {
            _manager = manager;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data[0];
            return View(datas);
        }

        [HttpPost]
        public IActionResult Edit(ServiceHeader entity)
        {
            var oldEntity = _manager.GetByID(entity.ID).Data;

            string fileName = entity.HeaderImgFile != null ? Uploader(entity, "Images", entity.HeaderImgFile)
                                                       : oldEntity.HeaderImg;

            var result = _manager.Update(entity, fileName);
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

        private string Uploader(ServiceHeader entity, string property, IFormFile document)
        {
            if (document != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string folder = property + "/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                entity.HeaderImgFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }
        }
    }
}

using System;
using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moozd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _manager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectController(IProjectService manager, IWebHostEnvironment webHostEnvironment)
        {
            _manager = manager;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data;
            return View(datas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Project entity)
        {
            string fileName = Uploader(entity, "Images", entity.ThumbNailFile);

            var result = _manager.Add(entity, fileName);
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
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var project = _manager.GetByID(id).Data;
            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Project entity)
        {
            var oldEntity = _manager.GetByID(entity.ID).Data;

            string fileName = entity.ThumbNailFile != null ? Uploader(entity, "Images", entity.ThumbNailFile)
                                                       : oldEntity.ThumbNail;

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

        private string Uploader(Project entity, string property, IFormFile document)
        {
            if (document != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string folder = property + "/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                entity.ThumbNailFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }
        }
    }
}

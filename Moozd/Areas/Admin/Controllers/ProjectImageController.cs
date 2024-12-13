using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Moozd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectImageController : Controller
    {
        private readonly IProjectImageService _manager;
        private readonly IProjectService _projectManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectImageController(IProjectImageService manager, IProjectService projectManager, IWebHostEnvironment webHostEnvironment)
        {
            _manager = manager;
            _projectManager = projectManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int id)
        {
            ViewData["ProjectID"] = id;
            var datas = _manager.GetAll().Data.Where(x => x.ProjectID == id && x.Deleted == 0);
            return View(datas);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewData["ProjectID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProjectImage entity)
        {
            ViewData["ProjectID"] = entity.ProjectID;
            string fileName = Uploader(entity, "Images", entity.ProjectImgFile);

            var result = _manager.Add(entity, fileName);
            if (result.Success)
            {
                return RedirectToAction("Index", new { id = entity.ProjectID });
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

        public IActionResult Delete(int projectID, int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index", new { id = projectID });
        }

        public IActionResult Edit(int id)
        {
            var projectIMG = _manager.GetByID(id).Data;
            return View(projectIMG);
        }

        [HttpPost]
        public IActionResult Edit(ProjectImage entity)
        {
            ViewData["ProjectID"] = entity.ProjectID;
            var oldEntity = _manager.GetByID(entity.ID).Data;

            string fileName = entity.ProjectImgFile != null ? Uploader(entity, "Images", entity.ProjectImgFile)
                                                       : oldEntity.ProjectImg;

            var result = _manager.Update(entity, fileName);
            if (result.Success)
            {
                return RedirectToAction("Index", new { id = entity.ProjectID });
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
        private string Uploader(ProjectImage entity, string property, IFormFile document)
        {
            if (document != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string folder = property + "/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                entity.ProjectImgFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }
        }
    }
}

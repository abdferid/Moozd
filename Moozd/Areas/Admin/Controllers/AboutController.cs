using Business.Abstract;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moozd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService _manager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutController(IAboutService manager, IWebHostEnvironment webHostEnvironment)
        {
            _manager = manager;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data[0];
            if(datas is not null) 
            { 
                return View(datas);
            }
            else
            {
                About about = new()
                {
                    Text = "<h2 class=\"mil-up mil-mb-60\">Discover <br>Our <span class=\"mil-thin\">Studio</span></h2>\r\n                                    <p class=\"mil-up mil-mb-30\">At our design studio, we are a collective of talented individuals ignited by our unwavering passion for transforming ideas into reality. With a harmonious blend of diverse backgrounds and a vast array of skill sets, we join forces to create compelling solutions for our esteemed clients.</p>\r\n\r\n                                    <p class=\"mil-up mil-mb-60\">Collaboration is at the heart of what we do. Our team thrives on the synergy that arises when unique perspectives converge, fostering an environment of boundless creativity. By harnessing our collective expertise, we produce extraordinary results that consistently surpass expectations.</p>",
                    AboutImg = string.Empty,
                };
                return View(about);
            }
        }

        [HttpPost]
        public IActionResult Index(About entity)
        {
            var oldEntity = _manager.GetByID(entity.ID).Data;

            string fileName = entity.AboutImgFile != null ? Uploader(entity, "Images", entity.AboutImgFile)
                                                       : oldEntity.AboutImg;

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

        private string Uploader(About entity, string property, IFormFile document)
        {
            if (document != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string folder = property + "/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                entity.AboutImgFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }
        }


    }
}

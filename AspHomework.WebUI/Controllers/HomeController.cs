using System.Diagnostics;
using AspHomework.DAL.Repositories.Interfaces;
using AspHomework.WebUI.ViewModels.Home;
using AspHomework.WebUI.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AspHomework.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public HomeController(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult Index(bool showSuccess = false)
        {
            IndexViewModel model = new IndexViewModel();

            model.Rooms = _roomRepository.GetAll();
            model.ShowSuccess = showSuccess;

            return View(model);
        }

        public IActionResult Privacy()
        {
            PrivacyViewModel model = new PrivacyViewModel();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ErrorViewModel model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(model);
        }
    }
}

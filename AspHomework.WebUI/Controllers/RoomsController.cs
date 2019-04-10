using AspHomework.DAL.Repositories.Interfaces;
using AspHomework.WebUI.ViewModels.Rooms;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspHomework.WebUI.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            model.Rooms = _roomRepository.GetAll();

            return View(model);
        }

    }
}

using System.Collections.Generic;
using AspHomework.DAL.Entities;
using AspHomework.WebUI.ViewModels.Shared;

namespace AspHomework.WebUI.ViewModels.Rooms
{
    public class IndexViewModel: BaseViewModel
    {
        public IndexViewModel()
        {
            this.PageTitle = "Rooms";
        }

        public IEnumerable<Room> Rooms { get; set; }
    }
}

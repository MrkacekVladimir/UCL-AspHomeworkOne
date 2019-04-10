using System.Collections.Generic;
using AspHomework.DAL.Entities;
using AspHomework.WebUI.ViewModels.Shared;

namespace AspHomework.WebUI.ViewModels.Home
{
    public class IndexViewModel: BaseViewModel
    {
        public IndexViewModel()
        {
            this.PageTitle = "Home";
        }

        public IEnumerable<Room> Rooms { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspHomework.DAL.Entities;
using AspHomework.WebUI.ViewModels.Shared;
using AspHomework.Core.Modules.Reservation.Models;

namespace AspHomework.WebUI.ViewModels.Reservations
{
    public class NewReservationViewModel: BaseViewModel
    {
        public NewReservationViewModel()
        {
            this.PageTitle = "New reservation";
        }

        [DataType(DataType.Date)]
        [Required]
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime SelectedReservationTime { get; set; }
        
        public Room Room { get; set; } = new Room();
        public long RoomId { get; set; }
        public List<ReservationDateTime> Dates { get; set; } = new List<ReservationDateTime>();       
    }
}

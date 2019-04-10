using System.Collections.Generic;
using AspHomework.Core.Modules.Reservation.Models;

namespace AspHomework.Core.Modules.API.DTO
{
    public class RoomInfoDto
    {
        public DAL.Entities.Room Room { get; set; }
        public List<ReservationDateTime> AvailableTimes { get; set; }
    }
}
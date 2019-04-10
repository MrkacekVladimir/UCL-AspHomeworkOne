using System;
using System.Collections.Generic;
using System.Linq;
using AspHomework.Core.Modules.API.DTO;
using AspHomework.Core.Modules.API.ModelBinders;
using AspHomework.Core.Modules.Reservation.Services.Interfaces;
using AspHomework.DAL.Entities;
using AspHomework.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspHomework.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationService _reservationService;

        public RoomsController(IRoomRepository roomRepository, IReservationRepository reservationRepository, IReservationService reservationService)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
            _reservationService = reservationService;
        }

        // GET: api/rooms
        [HttpGet("{date}")]
        public ActionResult<IEnumerable<RoomInfoDto>> Get([ModelBinder(typeof(SimpleDateTimeModelBinder))]DateTime date)
        {
            if (date < DateTime.Today)
            {
                return BadRequest();
            }
            
            IEnumerable<Room> rooms = _roomRepository.GetAllWithReservations();
            
            List<RoomInfoDto> dtoList = new List<RoomInfoDto>();
            foreach (var room in rooms)
            {
                RoomInfoDto dto = new RoomInfoDto();
                dto.Room = room;                
                dto.AvailableTimes = _reservationService.GetReservationDateTimes(
                    date.Date.AddHours(room.OpenFrom),
                    date.Date.AddHours(room.OpenTo), 
                    room.Reservations?.Select(x => x.ReservedFrom));
                //Do not include reservations in the DTO
                dto.Room.Reservations = null;
                
                dtoList.Add(dto);
            }                        
            
            return Ok(dtoList);
        }

        // GET api/rooms/7.4.2019/5
        [HttpGet("{date}/{id:long}")]
        public ActionResult<RoomInfoDto> Get([ModelBinder(typeof(SimpleDateTimeModelBinder))]DateTime date, long id)
        {
            if (date < DateTime.Today)
            {
                return BadRequest();
            }
            
            Room room = _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            var unavailableDates = _reservationRepository.GetUnavailableDates(room.Id, date);
            
            RoomInfoDto dto = new RoomInfoDto();
            dto.Room = room;
            dto.AvailableTimes = _reservationService.GetReservationDateTimes(
                date.Date.AddHours(room.OpenFrom), 
                date.Date.AddHours(room.OpenTo),
                unavailableDates);

            return Ok(dto);
        }
    }
}

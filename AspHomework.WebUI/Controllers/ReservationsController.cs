using System;
using System.Collections.Generic;
using AspHomework.Core.Modules.Reservation.Models;
using AspHomework.Core.Modules.Reservation.Services.Interfaces;
using AspHomework.DAL.Entities;
using AspHomework.DAL.Repositories.Interfaces;
using AspHomework.WebUI.ViewModels.Reservations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspHomework.WebUI.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationRepository reservationRepository,
            IRoomRepository roomRepository,
            IUserRepository userRepository,
            IReservationService reservationService)
        {
            this._reservationRepository = reservationRepository;
            this._roomRepository = roomRepository;
            this._userRepository = userRepository;
            this._reservationService = reservationService;
        }       

        [HttpGet]
        public IActionResult New(long id)
        {
            Room room = _roomRepository.GetById(id);
            if(room == null)
            {
                return RedirectToAction("Index", "Rooms");
            }

            List<ReservationDateTime> dates = _reservationService.GetReservationDateTimes(
                DateTime.Today.AddHours(room.OpenFrom),
                DateTime.Today.AddHours(room.OpenTo),
                _reservationRepository.GetUnavailableDates(room.Id, DateTime.Today));

            NewReservationViewModel model = new NewReservationViewModel();
            model.Room = room;
            model.RoomId = room.Id;
            model.Dates = dates;            
            
            return View(model);
        }

        [HttpPost]
        public IActionResult GetDates(long roomId, DateTime dateWhen)
        {
            Room room = _roomRepository.GetById(roomId);
            if(room == null)
            {
                return NotFound();
            }
            
            List<ReservationDateTime> dates = _reservationService.GetReservationDateTimes(
                dateWhen.Date.AddHours(room.OpenFrom),
                dateWhen.Date.AddHours(room.OpenTo),
                _reservationRepository.GetUnavailableDates(room.Id, dateWhen.Date));

            return PartialView("_ReservationTimeList", dates);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New([FromForm]NewReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_reservationRepository.IsDateAvailable(model.RoomId, model.SelectedReservationTime))
                {
                    TempData["ErrorMessage"] = "Selected date is not available. Please choose another time.";                    
                }
                else
                {
                    return RedirectToAction(nameof(Confirmation), new { roomId = model.RoomId, reservationDate = model.SelectedReservationTime });    
                }                
            }

            Room room = _roomRepository.GetById(model.RoomId);
            
            List<ReservationDateTime> dates = _reservationService.GetReservationDateTimes(
                DateTime.Today.AddHours(room.OpenFrom),
                DateTime.Today.AddHours(room.OpenTo),
                _reservationRepository.GetUnavailableDates(room.Id, DateTime.Today));
            model.Dates = dates;
            model.Room = room;
            model.RoomId = room.Id;                        
                        
            return View(model);
        }                

        [HttpGet]
        public IActionResult Confirmation(long roomId, DateTime reservationDate)
        {
            Room room = _roomRepository.GetById(roomId);
            if (room == null)
            {
                return RedirectToAction("Index","Rooms");
            }
            
            if(!_reservationRepository.IsDateAvailable(room.Id, reservationDate))
            {
                return RedirectToAction("New","Reservations", new { id = roomId });
            }
            
            ConfirmationViewModel model = new ConfirmationViewModel();
            model.Room = room;
            model.ReservationDate = reservationDate;
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirmation([FromForm]ConfirmationViewModel model)
         {                        
            if (ModelState.IsValid)
            {
                Room room = _roomRepository.GetById(model.RoomId);
                if (room == null)
                {
                    return RedirectToAction("Index", "Rooms");
                }

                if(!_reservationRepository.IsDateAvailable(room.Id, model.ReservationDate))
                {
                    TempData["ErrorMessage"] = "Selected date is already booked. Please choose another time."; 
                    return RedirectToAction("New","Reservations", new { id = room.Id });
                }

                User user = _userRepository.GetByEmail(model.Email);
                if (user == null)
                {                    
                    user = _userRepository.Create(model.FirstName, model.LastName, model.Email, model.Phone);
                }

                _reservationRepository.Create(room.Id, user.Id, model.ReservationDate, model.ReservationDate.AddHours(1).AddMilliseconds(-1), model.Note);
                return RedirectToAction("Index", "Home", new { showSuccess = true });
            }

            return View(model);
        }
                
    }
}

using System;
using System.Collections.Generic;
using AspHomework.Core.Modules.API.DTO;
using AspHomework.Core.Modules.Reservation.Models;
using AspHomework.Core.Modules.Reservation.Services.Interfaces;
using AspHomework.DAL.Entities;
using AspHomework.DAL.Repositories.Interfaces;
using AspHomework.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspHomework.Tests.UnitTests.API
{
    [TestClass]
    public class TestRoomsController
    {
        [TestMethod]
        public void TestGetWithDateParameter()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room()
            {
                Id = 1,
                Description = "Lorem lorem",
                Name = "Test Chamber",
                OpenFrom = 4,
                OpenTo = 16,
                Reservations = null
            });
            
            rooms.Add(new Room()
            {
                Id = 2,
                Description = "Lorem lorem",
                Name = "UCL Room 1.1",
                OpenFrom = 0,
                OpenTo = 24,
                Reservations = null
            });
            
            rooms.Add(new Room()
            {
                Id = 3,
                Description = "Lorem lorem",
                Name = "2 hour room",
                OpenFrom = 10,
                OpenTo = 12,
                Reservations = null
            });

            var mockReservationRepo = new Mock<IReservationRepository>();
            
            var mockRoomRepo = new Mock<IRoomRepository>();
            mockRoomRepo.Setup(repo => repo.GetAllWithReservations()).Returns(rooms);

            var mockService = new Mock<IReservationService>();
            mockService.Setup(s => s.GetReservationDateTimes(DateTime.Today.AddHours(6),
                    DateTime.Today.AddHours(10),
                    new List<DateTime>()))
                .Returns(new List<ReservationDateTime>()
                {
                    new ReservationDateTime(DateTime.Today.AddHours(6), true),
                    new ReservationDateTime(DateTime.Today.AddHours(7), true),
                    new ReservationDateTime(DateTime.Today.AddHours(8), true),
                    new ReservationDateTime(DateTime.Today.AddHours(9), true),
                });
  
            RoomsController roomsController = new RoomsController(mockRoomRepo.Object, mockReservationRepo.Object, mockService.Object);                        
  
            ActionResult<IEnumerable<RoomInfoDto>> result = roomsController.Get(DateTime.Today);
            
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<RoomInfoDto>>));                                                
        }
    }
}
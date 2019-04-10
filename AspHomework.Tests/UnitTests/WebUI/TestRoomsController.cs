using System.Collections.Generic;
using System.Linq;
using AspHomework.DAL.Entities;
using AspHomework.DAL.Repositories.Interfaces;
using AspHomework.WebUI.Controllers;
using AspHomework.WebUI.ViewModels.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspHomework.Tests.UnitTests.WebUI
{
    [TestClass]
    public class TestRoomsController
    {
        [TestMethod]
        public void TestIndexViewModel()
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
  
            var mock = new Mock<IRoomRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(rooms);
  
            RoomsController roomsController = new RoomsController(mock.Object);                        
  
            IActionResult result = roomsController.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(IndexViewModel));
            IndexViewModel viewModel = (IndexViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(3, viewModel.Rooms.Count());
        }
    }
}
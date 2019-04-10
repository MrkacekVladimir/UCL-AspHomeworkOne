using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AspHomework.Core.Modules.API.DTO;
using AspHomework.DAL;
using AspHomework.DAL.Entities;
using AspHomework.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspHomework.Tests.IntegrationTests
{
    [TestClass]
    public class WebApiIntegrationTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void Initialize()
        {
            TestsWebApplicationFactory<Startup> factory = new TestsWebApplicationFactory<Startup>();
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [TestMethod]
        public void TestGetRoomInfoWithIdOne()
        {
            DateTime now = DateTime.Today;
            HttpResponseMessage response = _client.GetAsync($"/api/rooms/{now.Day}.{now.Month}.{now.Year}/1").Result;
            response.EnsureSuccessStatusCode();

            RoomInfoDto roomInfoDto = response.Content.ReadAsAsync<RoomInfoDto>().Result;

            List<Room> rooms = TestDbInitializer.GetTestRooms();
                        
            Assert.IsTrue(rooms.FirstOrDefault(r => r.Id == 1)?.Name == roomInfoDto.Room.Name);
        }
    }
}

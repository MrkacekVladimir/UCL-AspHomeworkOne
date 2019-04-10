using System.Collections.Generic;
using System.Linq;
using AspHomework.DAL.Entities;
  
namespace AspHomework.DAL
{
    public static class TestDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Rooms.Any())
            {
                return;
            }
            context.Rooms.AddRange(GetTestRooms());
            context.SaveChanges();
        }

        public static List<Room> GetTestRooms()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room()
            {
                Id = 1,
                Name = "UCL Room",
                Description = "Lorem ipsum dolor sit amet.",
                OpenFrom = 7,
                OpenTo = 24
            });
            rooms.Add(new Room()
            {
                Id = 2,
                Name = "Hujahuja Room",
                Description = "Lorem ipsum dolor sit amet.",
                OpenFrom = 14,
                OpenTo = 18
            });

            rooms.Add(new Room()
            {
                Id = 3,
                Name = "Ratatatat Room",
                Description = "Lorem ipsum dolor sit amet.",
                OpenFrom = 10,
                OpenTo = 12
            });
            return rooms;
        }
    }
}
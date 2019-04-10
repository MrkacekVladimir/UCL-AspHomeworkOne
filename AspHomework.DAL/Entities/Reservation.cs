using System;
namespace AspHomework.DAL.Entities
{
    public class Reservation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoomId { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public string Note { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }
    }
}

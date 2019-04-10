using System.Collections.Generic;

namespace AspHomework.DAL.Entities
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte OpenFrom { get; set; }
        public byte OpenTo { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}

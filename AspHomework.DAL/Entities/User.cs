using System.Collections.Generic;

namespace AspHomework.DAL.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}

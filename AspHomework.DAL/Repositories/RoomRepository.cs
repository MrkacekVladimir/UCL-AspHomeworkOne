using System.Collections.Generic;
using System.Linq;
using AspHomework.DAL.Entities;
using AspHomework.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspHomework.DAL.Repositories
{
    public class RoomRepository: IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public IEnumerable<Room> GetAllWithReservations()
        {
            return _context.Rooms.Include(x => x.Reservations).ToList();
        }
        
        public Room GetById(long id)
        {
            return _context.Rooms.FirstOrDefault(x => x.Id == id);
        }

    }
}

using System.Collections.Generic;
using AspHomework.DAL.Entities;

namespace AspHomework.DAL.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        IEnumerable<Room> GetAllWithReservations();
        Room GetById(long id);                
    }
}

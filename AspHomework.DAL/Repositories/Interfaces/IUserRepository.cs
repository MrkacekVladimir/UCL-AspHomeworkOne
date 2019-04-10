using System.Collections.Generic;
using AspHomework.DAL.Entities;

namespace AspHomework.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(long id);
        User GetByEmail(string email);
        User Create(User user);
        User Create(string firstName, string lastName, string email, string phone);
    }
}

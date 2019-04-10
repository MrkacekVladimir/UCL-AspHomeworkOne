using System.Collections.Generic;
using System.Linq;
using AspHomework.DAL.Entities;
using AspHomework.DAL.Repositories.Interfaces;

namespace AspHomework.DAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        
        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            
            return user;
        }

        public User Create(string firstName, string lastName, string email, string phone)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.Phone = phone;
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
        
    }
}

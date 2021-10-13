using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAppLoginPage.Models.Data;
using WebAppLoginPage.Models.Models;
using WebAppLoginPage.Services.Interface;

namespace WebAppLoginPage.Services.Implementation
{
    internal class UserService : IUserService
    {
        private readonly ILoginDbContext _dbContext;
        public UserService(ILoginDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }

        public void Delete(Guid id)
        {
            _dbContext.Users.Remove(Get(id));
        }

        public User Get(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return _dbContext.Users;
        }

        public void Update(User user)
        {
            int userIndex = _dbContext.Users.IndexOf(Get(user.Id));

            _dbContext.Users[userIndex] = user;

        }
    }
}

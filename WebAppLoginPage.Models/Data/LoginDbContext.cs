using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAppLoginPage.Models.Models;

namespace WebAppLoginPage.Models.Data
{
    internal class LoginDbContext : ILoginDbContext
    {
        public List<User> Users { get; set; }

        public LoginDbContext()
        {
            Users = new List<User>();
        }
    }

    public interface ILoginDbContext
    {
        List<User> Users { get; set; }
    }
}

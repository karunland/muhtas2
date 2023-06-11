using DataAccesss.Abstract;
using Entity.DbModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.EntityFramework
{
    public class EfUserNoDbDal : IUserDal
    {
        public static List<User> _user = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Harun",
                LastName = "Admin",
                Mail = "deneme@gmail.com",
                Password = "password"
            }
        };

        public async Task<int> Add(User Model)
        {
            if (Model == null) throw new ArgumentNullException();
            var p = _user.FirstOrDefault(x => x.Id == Model.Id);
            if (p != null)
            {
                p.FirstName = Model.FirstName;
                p.LastName = Model.LastName;
                p.Mail = Model.Mail;
                return 0;
            }
            _user.Add(Model);
            return 0;
        }

        public async Task<User> GetUser(string Mail)
        {
            return _user.FirstOrDefault(x => x.Mail == Mail);
        }

        public Task<int> IsUser(User Model)
        {
            var person = _user.FirstOrDefault(x => x.Mail == Model.Mail && x.Password == Model.Password);
            if (person == null) return Task.FromResult(1);
            return Task.FromResult(0);
        }
    }
}

using DataAccesss.Abstract;
using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.EntityFramework
{
    public class EfLoginDal : ILoginDal
    {
        private readonly IHttpContextAccessor _context;
        public EfLoginDal(IHttpContextAccessor context)
        {
            _context = context;
        }

        public User GetLoginUser()
        {
            var mail = _context.HttpContext?.User;
            var person = mail.Claims.FirstOrDefault();
            if (person == null)
                return new User { isAdmin = false, Id = 0 };
            using (var context = new Context())
            {
                var person1 =  context.User.Where(x => x.Mail == person.Value).FirstOrDefault();
                return person1;
            }
        }
    }
}

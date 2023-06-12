using DataAccesss.Abstract;
using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.EntityFramework
{
    public class EfLoginNoDbDal : ILoginDal
    {
        private readonly IHttpContextAccessor _context;
        public EfLoginNoDbDal(IHttpContextAccessor context)
        {
            _context = context;
        }

        public User GetLoginUser()
        {
            var mail = _context.HttpContext?.User;
            var person = mail.Claims.FirstOrDefault();
            if (person == null)
                return new User { isAdmin = false, Id = 0 };
            var context = EfUserNoDbDal._user;
            var person1 = context.Where(x => x.Mail == person.Value).FirstOrDefault();
            return person1;
        }
    }
}

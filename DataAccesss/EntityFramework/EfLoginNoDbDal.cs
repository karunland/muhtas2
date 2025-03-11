using Entity.DbModel;
using Microsoft.AspNetCore.Http;

namespace DataAccesss.EntityFramework;

public class EfLoginNoDbDal(IHttpContextAccessor _context)
{

    public User GetLoginUser()
    {
        var mail = _context.HttpContext?.User;
        var person = mail.Claims.FirstOrDefault();
        if (person == null)
            return new User { isAdmin = false, Id = 0 };
        var person1 = EfUserNoDbDal._user.Where(x => x.Mail == person.Value).FirstOrDefault();
        return person1;
    }
}

using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccesss.EntityFramework;

public class EfLoginDal(Context _context)
{

    public User GetUser(string username, string password)
    {
        var user = _context.User.FirstOrDefault(x => x.Mail == username && x.Password == password);
        return user;
    }

    public User GetLoginUser()
    {
        var mail = _context.User;
        var person = mail.FirstOrDefault();
        if (person == null)
            return new User { isAdmin = false, Id = 0 };
        var person1 = _context.User.Where(x => x.Mail == person.Mail).FirstOrDefault();
        return person1;
    }
}

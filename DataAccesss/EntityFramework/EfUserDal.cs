using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccesss.EntityFramework;

public class EfUserDal(Context _context)
{

    public async Task<int> Add(User Model)
    {
        if (Model == null) throw new ArgumentNullException();
        if (Model.Id == 0)
            await _context.AddAsync(Model);
            else
            {
                var person = _context.User.Where(x => x.Id == Model.Id).FirstOrDefault();
                person.FirstName = Model.FirstName;
                person.LastName = Model.LastName;
                person.Mail = Model.Mail;
                _context.User.Update(person);
        }
        await _context.SaveChangesAsync();
        return 0;
    }

    public async Task<User> GetUser(string Mail)
    {
        var person = await _context.User.AsNoTracking().Where(x => x.Mail == Mail && x.IsDeleted == false).FirstOrDefaultAsync();
        if (person == null) throw new ArgumentNullException();
        return person;
    }

    public async Task<int> IsUser(User Model)
    {
        var person = await _context.User.AsNoTracking().Where(x => x.Mail == Model.Mail && !x.IsDeleted).FirstOrDefaultAsync();
        if (person == null) return 1;
        return 0;
    }
}

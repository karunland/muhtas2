using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        public async Task<int> Add(User Model)
        {
            if (Model == null) throw new ArgumentNullException();
            using (var context = new Context())
            {
                if (Model.Id == 0)
                    await context.AddAsync(Model);
                else
                    context.User.Update(Model);
                await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<User> GetUser(string Mail)
        {
            using (var context = new Context())
            {
                var person = await context.User.AsNoTracking().Where(x => x.Mail == Mail && x.IsDeleted == false).FirstOrDefaultAsync();
                if (person == null) throw new ArgumentNullException();
                return person;
            }
        }

        public async Task<int> IsAdminUser(User Model)
        {
            using (var context = new Context())
    {
                var person = await context.User.AsNoTracking().Where(x => x.Mail == Model.Mail && !x.IsDeleted).FirstOrDefaultAsync();
                if (person == null) return 1;
                return 0;
            }
        }
    }
}

using Entity.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Abstract
{
    public interface IUserDal
    {
        /// <summary>
        /// adds user
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        Task<int> Add(User Model);

        /// <summary>
        /// gets user by Mail
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<User> GetUser(string Mail);

        /// <summary>
        /// returns 0 if person is admin, 1 if it's not
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        Task<int> IsUser(User Model);
    }
}

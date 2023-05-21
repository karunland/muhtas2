using Entity.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Abstract
{
    public interface ILoginDal
    {
        /// <summary>
        /// gets logged in user from httpcontext
        /// </summary>
        /// <returns></returns>
        Task<User> GetLoginUser();
    }
}

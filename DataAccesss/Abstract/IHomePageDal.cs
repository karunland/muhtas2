using Entity.DbModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Abstract
{
    public interface IHomePageDal
    {
        /// <summary>
        /// returns what will be shown in home page
        /// </summary>
        /// <returns></returns>
        Task<MonitorShow> GetHomePageSettings();

        /// <summary>
        /// adds homePage setting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddHomePageSettings(MonitorShow model);
    }
}

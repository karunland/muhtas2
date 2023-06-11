using DataAccesss.Abstract;
using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.EntityFramework
{
    public class EfHomePageDal : IHomePageDal
    {
        public async Task<MonitorShow> GetHomePageSettings()
        {
            using (var context = new Context())
            {
                var item = await context.MonitorShow.FirstOrDefaultAsync();
                if (item == null)
                    return new MonitorShow() { RgbSection = true, DistanceSection = true, DetailsSection = true };
                return item;
            }
        }

        public async Task<int> AddHomePageSettings(MonitorShow model)
        {
            if (model == null)
                return 1;
            using (var context = new Context())
            {
                var oldModel = context.MonitorShow.FirstOrDefault();
                oldModel.DistanceSection = model.DistanceSection;
                oldModel.RgbSection = model.RgbSection;

                await context.SaveChangesAsync();
                return 0;
            }
        }
    }
}

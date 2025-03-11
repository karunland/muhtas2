using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccesss.EntityFramework;

public class EfHomePageDal(Context _context)
{
    public async Task<MonitorShow> GetHomePageSettings()
    {
        var item = await _context.MonitorShow.FirstOrDefaultAsync();
        if (item == null)
            return new MonitorShow() { RgbSection = true, DistanceSection = true, DetailsSection = true };
        return item;
    }

    public async Task<int> AddHomePageSettings(MonitorShow model)
    {
        if (model == null)
            return 1;
        var oldModel = _context.MonitorShow.FirstOrDefault();
        oldModel.DistanceSection = model.DistanceSection;
        oldModel.RgbSection = model.RgbSection;

        await _context.SaveChangesAsync();
        return 0;
    }
}

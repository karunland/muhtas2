using Entity.DbModel;

namespace DataAccesss.EntityFramework;

public class EfHomePageNoDbDal
{
    public static MonitorShow _monitorShow = new MonitorShow() { RgbSection = true, DistanceSection = true, DetailsSection = true };
    public async Task<int> AddHomePageSettings(MonitorShow model)
    {
        if (model == null)
            return 1;
        _monitorShow.DistanceSection = model.DistanceSection;
        _monitorShow.RgbSection = model.RgbSection;
        return 0;
    }

    public async Task<MonitorShow> GetHomePageSettings()
    {
        return _monitorShow;
    }
}

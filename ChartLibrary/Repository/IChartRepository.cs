using ChartLibrary.DTOModel;

namespace ChartLibrary.Repository
{
    public interface IChartRepository
    {
        IEnumerable<ChartData> GetAll();

        IEnumerable<ChartData> GetUserDataByUserId(string userId);

        string GetEntityNameByUserId(string userId);
    }
}

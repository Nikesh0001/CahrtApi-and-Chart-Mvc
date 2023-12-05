using ChartLibrary.DTOModel;

namespace ChartLibrary.Repository
{
    public class ChartRepository : IChartRepository
    {
        List<ChartData> chartdata;
        public ChartRepository()
        {
            this.chartdata = new List<ChartData>()
            {
                new ChartData()
                {

                    EntityName = "Stock",
                    EntityId = 101,
                    FeatureName = "Tata",
                    FeatureId = 201,
                    Value = "200",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 0,
                    FeatureDataType = "int",
                    UserId="Admin"

                },
                new ChartData()
                {

                    EntityName = "Stock",
                    EntityId = 102,
                    FeatureName = "Tesla",
                    FeatureId = 202,
                    Value = "4520",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 1,
                    FeatureDataType = "String",
                    UserId="DataScientist1"


                },
                    new ChartData()
                {

                    EntityName = "Stock",
                    EntityId = 103,
                    FeatureName = "Apple",
                    FeatureId = 203,
                    Value = "2020",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 2,
                    FeatureDataType = "String",
                    UserId="DataScientist1"

                },
                    new ChartData()
                {

                    EntityName = "Stock",
                    EntityId = 104,
                    FeatureName = "Amazon",
                    FeatureId = 204,
                    Value = "7545",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 2,
                    FeatureDataType = "String",
                    UserId="DataScientist1"

                },
                    new ChartData()
                {

                    EntityName = "Stock",
                    EntityId = 105,
                    FeatureName = "BlueOrgin",
                    FeatureId = 205,
                    Value = "6542",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 1,
                    FeatureDataType = "int",
                    UserId="DataScientist1"

                },
                      new ChartData()
                {

                    EntityName = "Stock",
                    EntityId = 106,
                    FeatureName = "Fidelity",
                    FeatureId = 206,
                    Value = "6522",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 0,
                    FeatureDataType = "int",
                    UserId="DataScientist1"

                },
                       new ChartData()
                {

                    EntityName = "Character",
                    EntityId = 107,
                    FeatureName = "Height",
                    FeatureId = 20,
                    Value = "5'11",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 0,
                    FeatureDataType = "int",
                    UserId="DataScientist2"

                }, new ChartData()
                {

                    EntityName = "Character",
                    EntityId = 108,
                    FeatureName = "Weight",
                    FeatureId = 208,
                    Value = "50",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 1,
                    FeatureDataType = "int",
                    UserId="DataScientist2"

                },
                       new ChartData()
                {

                    EntityName = "Driver",
                    EntityId = 109,
                    FeatureName = "TripsToday",
                    FeatureId = 209,
                    Value = "11",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 3,
                    FeatureDataType = "int",
                    UserId="Raju"

                },new ChartData()
                {

                    EntityName = "Driver",
                    EntityId = 110,
                    FeatureName = "Rating",
                    FeatureId = 210,
                    Value = "4.5",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 3,
                    FeatureDataType = "int",
                    UserId="Raju"

                },new ChartData()
                {

                    EntityName = "Employee",
                    EntityId = 111,
                    FeatureName = "Salary",
                    FeatureId = 211,
                    Value = "50000",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 0,
                    FeatureDataType = "int",
                    UserId="Raju"

                },new ChartData()
                {

                    EntityName = "Employee",
                    EntityId = 112,
                    FeatureName = "Salary",
                    FeatureId = 212,
                    Value = "40000",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 1,
                    FeatureDataType = "int",
                    UserId="Raju"

                },new ChartData()
                {

                    EntityName = "Student",
                    EntityId = 113,
                    FeatureName = "Result",
                    FeatureId = 213,
                    Value = "Pass",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 1,
                    FeatureDataType = "int",
                    UserId="Raju"

                },new ChartData()
                {

                    EntityName = "Student",
                    EntityId = 114,
                    FeatureName = "Result",
                    FeatureId = 214,
                    Value = "Fail",
                    CreatedAt = DateTime.Now,
                    ApprovalStatus = 1,
                    FeatureDataType = "int",
                    UserId="Raju"
                }
            };
        }

        public IEnumerable<ChartData> GetAll()
        {
            return chartdata.ToList();
        }


        public IEnumerable<ChartData> GetUserDataByUserId(string userId)
        {
            return chartdata.Where(data => data.UserId == userId).ToList();
        }


        public string GetEntityNameByUserId(string userId)
        {
            try
            {
                var entityNames = chartdata
                    .Where(c => c.UserId == userId)
                    .Select(c => c.EntityName)
                    .ToList();

                return entityNames.Any() ? entityNames.First() : null;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching EntityNames: {ex.Message}");
                return null;
            }
        }
    }
}

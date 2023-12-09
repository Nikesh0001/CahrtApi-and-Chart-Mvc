using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChartMVC.ViewModel
{
    public class FeatureDto
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string Value { get; set; }
        public string FeatureDataType { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte ApprovalStatus { get; set; }
        public string AdminComments { get; set; }
        public string UserID { get; set; }
        public string EntityName { get; set; }

    }
}

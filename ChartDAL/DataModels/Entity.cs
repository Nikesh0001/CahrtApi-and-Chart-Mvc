using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDAL.DataModels
{

    [Table("EntityTbl")]
    public partial class EntityTbl
    {
        [Key]
        public string EntityName { get; set; } = null!;

        public string Description { get; set; } = null!;

        [InverseProperty("EntityNameNavigation")]
        public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
    }
}

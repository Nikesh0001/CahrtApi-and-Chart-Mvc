using ChartDAL.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChartDAL.Repository
{
    public class ChartRepository : IRepository<Feature>
    {
        ChartDbContext context;
        public ChartRepository(ChartDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Feature> GetAll()
        {
              var features =context.Features.ToList();

            foreach (var feature in features)
            {
                if(feature.AdminComments==null)
                {
                    feature.AdminComments = "No Comment ";
                }
            }

            return features;
          
        }

        public IEnumerable<Feature> GetById(string username)
        {
            return context.Features.Where(x => x.UserName == username).ToList();
        }
    }
}

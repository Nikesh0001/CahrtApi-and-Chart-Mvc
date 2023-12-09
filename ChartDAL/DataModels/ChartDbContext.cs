using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDAL.DataModels
{
    public class ChartDbContext : DbContext
    {
        public ChartDbContext(DbContextOptions<ChartDbContext> options) : base(options)
        {

        }
        public DbSet<EntityTbl> Entities { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feature>()
                .Property(f => f.AdminComments)
                .IsRequired(false); 

            base.OnModelCreating(modelBuilder);
        }

    }
}

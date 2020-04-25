using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPassportApi.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HealthPassportApi.Data
{
    public class HealthDatabaseContext : DbContext
    {
        public HealthDatabaseContext(DbContextOptions<HealthDatabaseContext> options) :
            base(options)
        {
        }

        public DbSet<DiseaseDescription> DiseaseDescriptions { get; set; }
        public DbSet<DiseaseUsefulUrl> UsefulReferences { get; set; }
        public DbSet<ImmuntisationStatus> ImmuntisationStatus { get; set; }
        public DbSet<InteractionTracking> InteractionTracking { get; set; }
    }

    public class HealthDatabaseFactory : IDesignTimeDbContextFactory<HealthDatabaseContext>
    {
        public HealthDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HealthDatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=EPCZPRAW0231;Initial Catalog=eu-vs-virus;Integrated Security=True",
                x => x.UseNetTopologySuite());

            return new HealthDatabaseContext(optionsBuilder.Options);
        }
    }
}

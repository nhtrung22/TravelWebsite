using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess.EF
{
    public class TravelDbContextFactory : IDesignTimeDbContextFactory<TravelDbContext>
    {
        public TravelDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TravelDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<TravelDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TravelDbContext(optionsBuilder.Options);
        }
    }
}

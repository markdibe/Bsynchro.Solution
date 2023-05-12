using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Bsynchro.EntityFramework.Core
{
    public class RJPContextFactory : IDesignTimeDbContextFactory<RJPDbContext>
    {
       
        public RJPDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RJPDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Bsynchro.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<RJPDbContext>();
            var connectionString = configuration.GetConnectionString("RJPConnection");
            builder.UseSqlServer(connectionString);
            return new RJPDbContext(builder.Options);
        }
    }
}

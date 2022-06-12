using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Linq;
using Things03.Module.BusinessObjects;

namespace Things03.Module.Functions
{
    public static class DataFunctions
    {

        public static Things03EFCoreDbContext MakeDbContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<Things03EFCoreDbContext>()
                .UseSqlServer(connectionString);
            return new Things03EFCoreDbContext(optionsBuilder.Options);
        }

        
    }
}

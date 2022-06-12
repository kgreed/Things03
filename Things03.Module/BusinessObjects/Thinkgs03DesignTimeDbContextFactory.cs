using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Things03.Module.BusinessObjects
{
    //This factory creates DbContext for design-time services. For example, it is required for database migration.
    public class Things03DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Things03EFCoreDbContext>
    {
        public Things03EFCoreDbContext CreateDbContext(string[] args)
        {
            throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
            //var optionsBuilder = new DbContextOptionsBuilder<Things03EFCoreDbContext>();
            //optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Things03");
            //return new Things03EFCoreDbContext(optionsBuilder.Options);
        }
    }
}

using DevExpress.ExpressApp.EFCore.DesignTime;
using Microsoft.EntityFrameworkCore;
using System;

namespace Things03.Module.BusinessObjects
{
    // This code allows our Model Editor to get relevant EF Core metadata at design time.
    // For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
    public class Things03ContextInitializer : DbContextTypesInfoInitializerBase
    {
        protected override DbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Things03EFCoreDbContext>()
                .UseSqlServer(@";");
            return new Things03EFCoreDbContext(optionsBuilder.Options);
        }
    }
}

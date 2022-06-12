using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using Microsoft.EntityFrameworkCore;
using System;

namespace Things03.Module.BusinessObjects
{
    [TypesInfoInitializer(typeof(Things03ContextInitializer))]
    public class Things03EFCoreDbContext : DbContext
    {
        public Things03EFCoreDbContext(DbContextOptions<Things03EFCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Thing> Things { get; set; }
        public DbSet<ModuleInfo> ModulesInfo { get; set; }
         
    }
}

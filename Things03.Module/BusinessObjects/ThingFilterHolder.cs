using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Things03.Module.Functions;

namespace Things03.Module.BusinessObjects
{
    [NavigationItem("Hidden")] // dont access via the navigation panel
    [DomainComponent]
    public class ThingFilterHolder
    {
        public ThingFilterHolder() {
            ThingFilter = new ThingFilter();
            ApplyFilter();

        }
        [Browsable(false)]
        [Key]
        public int Id { get; set; }
        public ThingFilter ThingFilter { get; set; }

        public virtual List<Thing> Things { get; set; }

        public void ApplyFilter()
        {
            var search = StringFunctions.SafeString( ThingFilter.Search);
            var sql = $"select Id, Name from Things where Name like '%{search}%'";
            var db = DataFunctions.MakeDbContext();
            Things = db.Things.FromSqlRaw(sql).ToList();
            
        }
    }
}

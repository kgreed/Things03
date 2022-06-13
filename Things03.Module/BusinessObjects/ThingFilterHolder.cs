﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Things03.Module.Functions;

namespace Things03.Module.BusinessObjects
{
    [NavigationItem("OldWayUseRibbonInstead")]
    [DomainComponent]
    public class ThingFilterHolder 
    {
        public ThingFilterHolder()
        {
            ThingFilter = new ThingFilter();
            ApplyFilter();

        }
        [Browsable(false)]
        [Key]
        public int Id { get; set; }
        public ThingFilter ThingFilter { get; set; }

        public virtual List<Thing> Things { get; set; }

        [Browsable(false)] public IObjectSpace ObjectSpace { get; set; }

        public void ApplyFilter()
        {
            var search = StringFunctions.SafeString(ThingFilter.Search);
            var sql = $"select Id, Name from Things where Name like '%{search}%'";
            var db = DataFunctions.MakeDbContext();
            var things1 = db.Things.FromSqlRaw(sql).ToList();
            Things = new List<Thing>();
            if (ObjectSpace == null) return;
            foreach (Thing t in things1)
            {
                Thing t2 = ObjectSpace.GetObject<Thing>(t);
                Things.Add(t2);
            
            }

            

        }
    }
}

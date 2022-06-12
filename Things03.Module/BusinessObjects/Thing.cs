using DevExpress.Persistent.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Things03.Module.BusinessObjects
{
  
    public class Thing
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

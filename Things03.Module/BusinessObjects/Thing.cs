using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Things03.Module.BusinessObjects
{
  
    public class Thing :IXafEntityObject
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public void OnCreated()
        {
             
        }

        public void OnLoaded()
        {
             
        }

        public void OnSaving()
        {
             
        }
    }
}

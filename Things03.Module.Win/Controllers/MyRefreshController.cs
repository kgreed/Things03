using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using System.Linq;
using Things03.Module.BusinessObjects;

namespace Things03.Module.Win.Controllers
{
    public class MyRefreshController : RefreshController
    {
        public MyRefreshController() : base()
        {

        }

        protected override void Refresh()
        {

            var holder = View.CurrentObject as ThingFilterHolder;
            holder.ApplyFilter();
            View.Refresh();
            base.Refresh();
        }
    }
}

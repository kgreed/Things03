using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using System.Linq;

namespace Things03.Module.Win.Controllers
{
    public class MyDeleteController : DeleteObjectsViewController
    {
        public MyDeleteController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.

        }

        protected override void Delete(SimpleActionExecuteEventArgs args)
        {
            base.Delete(args);
            View.ObjectSpace.CommitChanges();
        }

    }
}

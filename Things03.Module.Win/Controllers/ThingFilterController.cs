using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win;
using System.Linq;
using Things03.Module.BusinessObjects;

namespace Things03.Module.Win.Controllers
{
    public class ThingFilterController : ViewController
    {
        SimpleAction actThingScreen;
        public ThingFilterController() : base()
        {
            TargetViewNesting = Nesting.Root;
            actThingScreen = new SimpleAction(this, "Things", "View");
            actThingScreen.Execute += actThingScreen_Execute;
        }
        private void actThingScreen_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var holder = new ThingFilterHolder();
            var holderType = holder.GetType();
            var viewId = Application.FindDetailViewId(holderType);
            if (SwitchToViewIfOpen(Application, viewId)) return;

            var os = Application.CreateObjectSpace(typeof(Thing));  // any valid type would have done
            var detailView = Application.CreateDetailView(os, holder);
            holder.ObjectSpace = os;
            

            e.ShowViewParameters.CreatedView = detailView;
            e.ShowViewParameters.TargetWindow = TargetWindow.NewWindow;
            e.ShowViewParameters.NewWindowTarget = NewWindowTarget.MdiChild;
        }

        private bool SwitchToViewIfOpen(XafApplication application, string viewId)
        {
            if (!(application.ShowViewStrategy is WinShowViewStrategyBase strategy)) return false;
            foreach (var win in strategy.Windows.ToArray())
            {
                if (win.View == null) continue;
                if (!win.View.Id.Equals(viewId)) continue;
                win.Show();
                return true;
            }
            return false;
        }
    }
}

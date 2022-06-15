using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win;
using System.Linq;
using Things03.Module.BusinessObjects;
using Things03.Module.Functions;

namespace Things03.Module.Win.Controllers
{
    public class ThingFilterController : ViewController
    {
        SimpleAction actionAdd100Records;
        SimpleAction actThingScreen;
        public ThingFilterController() : base()
        {
            TargetViewNesting = Nesting.Root;
            actThingScreen = new SimpleAction(this, "Things", "View");
            actThingScreen.Execute += actThingScreen_Execute;


            actionAdd100Records = new SimpleAction(this, "Add100Records", "View");
            actionAdd100Records.Execute += actionAdd100Records_Execute;
            
        }
        private void actionAdd100Records_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var db = DataFunctions.MakeDbContext();
            var startNum = db.Things.Count()+1;
            for (int i = 0; i < 100; i++)
            {

                var thing = new Thing
                {
                    Name = $"Name  {i + startNum}"
                };
                db.Things.Add(thing);
            }
            db.SaveChanges();
           
            View.Refresh(); // doesnt work
            View.RefreshDataSource(); // doesnt work
           
            var o = View.CurrentObject as ThingFilterHolder;
            o.ApplyFilter(); // doesnt work
           
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

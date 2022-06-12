using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Things03.Module.BusinessObjects;

namespace Things03.Module.Win.Editors
{
    [PropertyEditor(typeof(ThingFilter), true)]
    public class ThingsFilterEditor : WinPropertyEditor 
    {
        public ThingsFilterEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
        public override bool IsCaptionVisible => false;

        protected override void ReadValueCore()
        {
            base.ReadValueCore();
            SetControlValue();

        }

        protected override object CreateControlCore()
        {
            var filter = (ThingFilter)PropertyValue;
            var control = new ThingFilterControl
            {
                Filter = filter
            };
            control.ApplyFilter += Control_ApplyFilter;
            return control;
        }
        private void SetControlValue()
        {
            if (PropertyValue is not  ThingFilter filter) return;
            var control = Control as ThingFilterControl;
            control.Filter = filter;
        }
        private void Control_ApplyFilter()
        {
            var holder = View.CurrentObject as ThingFilterHolder;
            holder.ApplyFilter();
            View.Refresh();
        }

        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            ReadValue();
        }

        protected override object GetControlValueCore()
        {
            var control = Control as ThingFilterControl;
            return control?.Filter;
        }
    }
}

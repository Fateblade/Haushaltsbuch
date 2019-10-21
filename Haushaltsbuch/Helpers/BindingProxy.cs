using System.Windows;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Helpers
{
    //sourced from: https://thomaslevesque.com/2011/03/21/wpf-how-to-bind-to-data-when-the-datacontext-is-not-inherited/
    public class BindingProxy : Freezable
    {
        //properties
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
        public object Data
        {
            get => (object)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }



        //overrides
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }
    }
}

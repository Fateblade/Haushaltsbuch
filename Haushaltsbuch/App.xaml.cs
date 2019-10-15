using System;
using System.Windows;
using Fateblade.Haushaltsbuch.Registrations.Mappings;
using Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.CommonDialogs;
using Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.DomainDialogs;
using Prism.Ioc;
using Prism.Ninject;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App :  PrismApplication
    {
        public App()
        {
        }

        protected override Window CreateShell()
        {
            return new MainShell();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            new KernelInitializer().Initialize(containerRegistry, Container);
            containerRegistry.RegisterInstance(typeof(CommonDialogRequestHandler), Container.Resolve<CommonDialogRequestHandler>());
            containerRegistry.RegisterInstance(typeof(DomainDialogRequestHandler), Container.Resolve<DomainDialogRequestHandler>());
        }


        //https://www.davidbritch.com/2013/06/changing-default-conventions-used-in.html
        protected override void ConfigureViewModelLocator() //view and viewmodel have to be in the same folder (XXX.xaml XXXViewModel.cs)
        {
            base.ConfigureViewModelLocator();
            Prism.Mvvm.ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                (viewType) =>
                {
                    string viewModelTypeName = $"{viewType.Namespace}.{viewType.Name}ViewModel, {viewType.Assembly}";
                    Type viewModelType = Type.GetType(viewModelTypeName);
                    return viewModelType;
                }
            );
        }
    }

//Shell.g.cs will not compile without this. something went wrong in the refactoring to UI.Haushaltsbuch
}